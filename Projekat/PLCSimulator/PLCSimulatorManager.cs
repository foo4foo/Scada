using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading;

namespace PLCSimulator
{
    public class PLCSimulatorManager
    {
        public ConcurrentDictionary<string, double> addresses;
        public ConcurrentDictionary<string, lib.AnalogInput> ainputs;
        public ConcurrentDictionary<string, lib.Alarm> alarms;
        public ConcurrentDictionary<string, bool> alarm_occured;

        //flagovi indikatori da li su threadovi zavrsili cilkus for petlje
        public bool flag_t1, flag_t2, flag_t3, flag_t4, flag_t5;
        
        public Thread t1, t2, t3, t4, t5; // t1-t4 - generisanje vrednosti velicina
                                          // t5 - provera alarma

        private object locker = new object();

        public PLCSimulatorManager()
        {
            addresses = new ConcurrentDictionary<string, double>();
            ainputs = new ConcurrentDictionary<string, lib.AnalogInput>();
            alarms = new ConcurrentDictionary<string, lib.Alarm>();
            alarm_occured = new ConcurrentDictionary<string, bool>();
        }

        public void StartPLCSimulator()
        {
            flag_t1 = true;

            t1 = new Thread(GeneratingAnalogInputs);
            t1.Start();

            flag_t2 = true;

            t2 = new Thread(GeneratingDigitalInputs);
            t2.Start();

            flag_t3 = true;

            t3 = new Thread(GeneratingAnalogOutputs);
            t3.Start();

            flag_t4 = true;

            t4 = new Thread(GeneratingDigitalOutputs);
            t4.Start();

            flag_t5 = true;

            t5 = new Thread(CheckAlarms); //nit koja ce proveravati da li se alarm desava
        }

        private void CheckAlarms()
        {
            while (flag_t5)
            {
                lock (locker)
                {
                    foreach(KeyValuePair<string, lib.Alarm> alarm in alarms)
                    {
                        foreach(KeyValuePair<string, lib.AnalogInput> ai in ainputs)
                        {
                            if (alarm.Value.Tag.Equals(ai.Value.TagName))
                            {
                                String boundary = alarm.Value.Above == true ? "Above" : "Below";

                                if (boundary.Equals("Above"))
                                {
                                    foreach (KeyValuePair<string, double> pair in addresses) {
                                        if (pair.Key.Equals(ai.Value.IO_address1))
                                        {
                                            if (addresses[pair.Key] > alarm.Value.Limit_value)
                                            {
                                                alarm_occured[alarm.Value.Id] = true;
                                            }
                                        }
                                    }
                                }   
                            } else
                            {
                                String boundary = alarm.Value.Above == true ? "Above" : "Below";

                                if (boundary.Equals("Below"))
                                {
                                    foreach (KeyValuePair<string, double> pair in addresses)
                                    {
                                        if (pair.Key.Equals(ai.Value.IO_address1))
                                        {
                                            if (addresses[pair.Key] < alarm.Value.Limit_value)
                                            {
                                                alarm_occured[alarm.Value.Id] = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    flag_t5 = false;
                }
                Thread.Sleep(200);

                flag_t5 = true;
            }
        }

        private void GeneratingAnalogInputs()
        {
            while (flag_t1)
            {
                lock (locker)
                {
                    foreach (KeyValuePair<string, double> pair in addresses)
                    {
                        addresses[pair.Key] = 100 * Math.Sin((double)DateTime.Now.Second / 60 * Math.PI);
                    }
                    flag_t1 = false;
                }

                Thread.Sleep(200);

                flag_t1 = true;
            }
        }

        private void GeneratingDigitalInputs()
        {
            while (flag_t2)
            {
                lock (locker)
                {
                    foreach (KeyValuePair<string, double> pair in addresses) {
                        if (addresses[pair.Key] == 0)
                        {
                            addresses[pair.Key] = 1;
                        }
                        else
                        {
                            addresses[pair.Key] = 0;
                        }
                    }
                    flag_t2 = false;
                }

                Thread.Sleep(200);

                flag_t2 = true;
            }
        }

        private void GeneratingAnalogOutputs()
        {
            while (flag_t3)
            {
                lock (locker)
                {
                    foreach (KeyValuePair<string, double> pair in addresses)
                    {
                        addresses[pair.Key] = 100 * DateTime.Now.Second / 60;
                    }
                    flag_t3 = false;
                }
                Thread.Sleep(200);

                flag_t3 = true;
            }
        }

        private void GeneratingDigitalOutputs()
        {
            while (flag_t4)
            {
                
                lock (locker)
                {
                    foreach (KeyValuePair<string, double> pair in addresses)
                    {
                        if (addresses[pair.Key] == 0)
                        {
                            addresses[pair.Key] = 1;
                        }
                        else
                        {
                            addresses[pair.Key] = 0;
                        }
                    }
                    flag_t4 = false;
                }
                Thread.Sleep(200);

                flag_t4 = true;
            }
        }

        public void loadAlarms(List<lib.Alarm> alarms)
        {
            foreach (lib.Alarm alarm in alarms)
            {
                this.alarms.TryAdd(alarm.Tag, alarm);
            }
        }

        public void loadTags(List<lib.AnalogInput> ainputs)
        {
            foreach(lib.AnalogInput ainput in ainputs)
            {
                this.ainputs.TryAdd(ainput.IO_address1, ainput);
            }

            foreach (KeyValuePair<string, lib.AnalogInput> ai in this.ainputs)
            {
                addresses[ai.Key] = 0;
            }
        }

    }
}
