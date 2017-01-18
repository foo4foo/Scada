using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using PLCSimulator;
using lib;

namespace DataConcentrator
{
    public class DataConcentratorManager
    {
        PLCSimulatorManager plcSimulatorManager;

        public const String xml_analogs_i = "analogs_i.xml";
        public const String xml_analogs_o = "analogs_o.xml";
        public const String xml_digitals_i = "digitals_i.xml";
        public const String xml_digitals_o = "digitals_o.xml";

        public List<Alarm> alarms;
        public List<AnalogInput> analogs_i;
        public List<AnalogOutput> analogs_o;
        public List<DigitalInput> digitals_i;
        public List<DigitalOutput> digitals_o;

        public DataConcentratorManager()
        {
            plcSimulatorManager = new PLCSimulatorManager();
            plcSimulatorManager.StartPLCSimulator();

            alarms = new List<Alarm>();
            analogs_i = new List<AnalogInput>();
            analogs_o = new List<AnalogOutput>();
            digitals_i = new List<DigitalInput>();
            digitals_o = new List<DigitalOutput>();

            //loadXML();
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
            this.alarms.Add(alarm);
        }

        public void Remove_Alarm(Alarm alarm)
        {

        }

        public void loadXML()
        {
            //ucitaj u alarms listu sve iz ostalih velicina

        }

        public void saveXML()
        {
            XmlSerializer xs_analog_i = new XmlSerializer(analogs_i.GetType());
            using (TextWriter analog_i_writer = new StreamWriter(xml_analogs_i))
            {
                xs_analog_i.Serialize(analog_i_writer, analogs_i);
            }

            XmlSerializer xs_analog_o = new XmlSerializer(analogs_o.GetType());
            using (TextWriter analog_o_writer = new StreamWriter(xml_analogs_o))
            {
                xs_analog_o.Serialize(analog_o_writer, analogs_o);
            }

            XmlSerializer xs_digital_i = new XmlSerializer(digitals_i.GetType());
            using (TextWriter digital_i_writer = new StreamWriter(xml_digitals_i))
            {
                xs_digital_i.Serialize(digital_i_writer, digitals_i);
            }

            XmlSerializer xs_digital_o = new XmlSerializer(digitals_o.GetType());
            using (TextWriter digital_o_writer = new StreamWriter(xml_digitals_o))
            {
                xs_digital_o.Serialize(digital_o_writer, digitals_o);
            }
        }

    }
}
