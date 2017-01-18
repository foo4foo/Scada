using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PLCSimulator;
using lib;

namespace DataConcentrator
{
    public class DataConcentratorManager
    {
        PLCSimulatorManager plcSimulatorManager;
        public List<Alarm> alarms;
        public List<AnalogInput> analogs_i;
        public List<AnalogOutput> analogs_o;
        public List<DigitalInput> digitals_i;
        public List<DigitalOutput> digitals_o;

        public DataConcentratorManager()
        {
            plcSimulatorManager = new PLCSimulatorManager();
            plcSimulatorManager.StartPLCSimulator();

            analogs_i = new List<AnalogInput>();
            analogs_o = new List<AnalogOutput>();
            digitals_i = new List<DigitalInput>();
            digitals_o = new List<DigitalOutput>();
        }

        public void Add_Tag(Object obj, String type)
        {
            switch (type)
            {
                case "Analog Input":
                    analogs_i.Add((AnalogInput)obj);
                    break;

                case "Analog Output":
                    analogs_o.Add((AnalogOutput)obj);
                    break;

                case "Digital Input":
                    digitals_i.Add((DigitalInput)obj);
                    break;

                case "Digital Output":
                    digitals_o.Add((DigitalOutput)obj);
                    break;

                default:
                    break;
            }
        }

        public void Remove_Tag(Object obj, String type)
        {

        }

        public void Add_Alarm(Alarm alarm)
        {

        }

        public void Remove_Alarm(Alarm alarm)
        {

        }

    }
}
