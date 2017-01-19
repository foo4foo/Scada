using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading;

namespace PLCSimulator
{
    /// <summary>
    /// PLC Simulator
    /// 
    /// 4 x ANALOG INPUT : ADDR001 - ADDR004
    /// 4 x ANALOG OUTPUT: ADDR005 - ADDR008
    /// 1 x DIGITAL INPUT: ADDR009
    /// 1 x DIGITAL OUTPUT: ADDR010
    /// </summary>
    public class PLCSimulatorManager
    {
        public ConcurrentDictionary<string, double> addresses;
        public ConcurrentDictionary<string, lib.AnalogInput> ainputs;
        public ConcurrentDictionary<string, lib.Alarm> alarms;
        public ConcurrentDictionary<string, bool> alarm_occured;

        public Thread t5; //

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
            Thread t1 = new Thread(GeneratingAnalogInputs);
            t1.Start();

            Thread t2 = new Thread(GeneratingDigitalInputs);
            t2.Start();

            Thread t3 = new Thread(GeneratingAnalogOutputs);
            t3.Start();

            Thread t4 = new Thread(GeneratingDigitalOutputs);
            t4.Start();

            t5 = new Thread(CheckAlarms); //nit koja ce proveravati da li se alarm desava
        }

        private void CheckAlarms()
        {
            while (true)
            {
                Thread.Sleep(1000);

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

                                if (boundary.Equals("Above"))
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
                }
            }
        }

        private void GeneratingAnalogInputs()
        {
            while (true)
            {
                Thread.Sleep(500);

                lock (locker)
                {
                    foreach (KeyValuePair<string, double> pair in addresses)
                    {
                        addresses[pair.Key] = 100 * Math.Sin((double)DateTime.Now.Second / 60 * Math.PI);
                    }

                }
            }
        }

        private void GeneratingDigitalInputs()
        {
            while (true)
            {
                Thread.Sleep(5000);

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
                }
            }
        }

        private void GeneratingAnalogOutputs()
        {
            while (true)
            {
                Thread.Sleep(1000);

                lock (locker)
                {
                    foreach (KeyValuePair<string, double> pair in addresses)
                    {
                        addresses[pair.Key] = 100 * DateTime.Now.Second / 60;
                        //t5.Start();
                    }
                }
            }
        }

        private void GeneratingDigitalOutputs()
        {
            while (true)
            {
                Thread.Sleep(8000);

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
                }
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
