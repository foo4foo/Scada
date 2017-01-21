using System;

using MySql;
using MySql.Data;

using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Linq;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using Data;
using PLCSimulator;
using lib;
using MySql.Data.MySqlClient;

namespace DataConcentrator
{
    public delegate void TagValueChangedEventHanlder(String msg);
    public delegate void AlarmOccurredEventHandler(String msg);
    public class DataConcentratorManager
    {

        public PLCSimulatorManager plcSimulatorManager;

        public KeyValuePair<string, bool> ALARM;

        public event TagValueChangedEventHanlder TagValueChanged;
        public event AlarmOccurredEventHandler AlarmOccured;

        ManualResetEvent _pauseEvent = new ManualResetEvent(true);

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
            
            alarms = new List<Alarm>();
            analogs_i = new List<AnalogInput>();
            analogs_o = new List<AnalogOutput>();
            digitals_i = new List<DigitalInput>();
            digitals_o = new List<DigitalOutput>();

            //OnTagValueChanged();

            loadXML();

            ALARM = new KeyValuePair<string, bool>();

            plcSimulatorManager.loadAlarms(alarms);
            plcSimulatorManager.loadTags(analogs_i);
            
            plcSimulatorManager.StartPLCSimulator();
            plcSimulatorManager.t5.Start();

        }

        public Alarm getAlarm(String id)
        {
            Alarm a = new Alarm();

            foreach(Alarm alarm in alarms)
            {
                if (alarm.Id.Equals(id))
                {
                    a.Id = alarm.Id;
                    a.Tag = alarm.Tag;
                    a.Message = alarm.Message;
                    a.setTime(DateTime.Now.ToString("yyyy - MM - dd hh: mm:ss"));
                    a.Above = alarm.Above;
                    a.Limit_value = alarm.Limit_value;

                    //return a;
                }
            }

            return a;
        }

        public void save_to_database(Alarm alarm)
        {
            //upisi u mysql bazu
            var db_conn = DBConnection.Instance();
            db_conn.DatabaseName = "mysql";

            if (db_conn.IsConnect())
            {
                try
                {
                    string cmdText = "INSERT INTO alarms.alarm VALUES (@id,@tag,@msg,@time,@above,@limit)";
                    MySqlCommand cmd = new MySqlCommand(cmdText, db_conn.Connection);
                    cmd.Parameters.Add("@id", alarm.Id);
                    cmd.Parameters.Add("@tag", alarm.Tag);
                    cmd.Parameters.Add("@msg", alarm.Message);
                    cmd.Parameters.Add("@time", alarm.getTime());
                    cmd.Parameters.Add("@above", alarm.Above == true ? 1 : 0);
                    cmd.Parameters.Add("@limit", alarm.Limit_value);
                    cmd.ExecuteNonQuery();
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    //pass
                }
                catch (System.InvalidOperationException ex)
                {
                    //pass
                }
            }

            try
            {
                db_conn.Close();
            }
            catch (Exception e)
            {
                //pass
            }
        }

        public KeyValuePair<string, bool> CatchAlarms()
        {
            //ovde je bag
            foreach(KeyValuePair<string, bool> pair in plcSimulatorManager.alarm_occured)
            {
                Thread.Sleep(200);

                if (pair.Value == true)
                {
                    Alarm alarm = getAlarm(pair.Key);

                    save_to_database(alarm);

                    //posalji event na formu7
                    //*********************************************************
                    //postavi staticko polje koje primati vrednost da je alarm uhvacen
                    //ALARM = pair;
                    //*********************************************************

                    //_pauseEvent.WaitOne(Timeout.Infinite);
                    //plcSimulatorManager.alarm_occured[pair.Key] = false;
                    //_pauseEvent.Set();

                    return new KeyValuePair<string, bool>(pair.Key, true);
                    //}
                
                }
            }

            return new KeyValuePair<string, bool>();
        }

        public void TagChanged(String msg)
        {
            OnTagValueChanged(msg);
        }

        protected virtual void OnTagValueChanged(String msg)
        {
            if (TagValueChanged != null)
            {
                TagValueChanged(msg);
            }
        }

        public void AlarmOccuredFoo(String msg)
        {
            OnAlarmOccuredChange(msg);
        }

        protected virtual void OnAlarmOccuredChange(String msg)
        {
            if (AlarmOccured != null)
                AlarmOccured(msg);
        }

        public String getAlarmID(String st)
        {
            return st;
        }

        public void Add_Tag(Object obj, String type)
        {
            switch (type)
            {
                case "Analog Input":
                    AnalogInput ai = (AnalogInput) obj;

                    analogs_i.Add(ai);
                    plcSimulatorManager.ainputs.TryAdd(ai.TagName, ai);
                    plcSimulatorManager.addresses.TryAdd(ai.IO_address1, 0);

                    break;

                case "Analog Output":
                    analogs_o.Add((AnalogOutput)obj);
                    plcSimulatorManager.addresses.TryAdd(analogs_o[analogs_o.Count - 1].IO_address1, 0);
                    break;

                case "Digital Input":
                    digitals_i.Add((DigitalInput)obj);
                    plcSimulatorManager.addresses.TryAdd(digitals_i[digitals_i.Count - 1].IO_address1, 0);
                    break;

                case "Digital Output":
                    digitals_o.Add((DigitalOutput)obj);
                    plcSimulatorManager.addresses.TryAdd(digitals_o[digitals_o.Count - 1].IO_address1, 0);
                    break;

                default:
                    break;
            }
        }

        public void write_alarm_info()
        {
            //snimi u bazu
        }

        public bool check_if_tag_exists(String type, String tagName)
        {
            switch (type)
            {
                case "Analog Input":
                    foreach (AnalogInput ainput in analogs_i)
                    {
                        if (ainput.TagName.Equals(tagName))
                            return true;
                    }
                    break;

                case "Analog Output":
                    foreach (AnalogOutput aoutput in analogs_o)
                    {
                        if (aoutput.TagName.Equals(tagName))
                            return true;
                    }
                    break;

                case "Digital Input":
                    foreach (DigitalInput dinput in digitals_i)
                    {
                        if (dinput.Tag_name.Equals(tagName))
                            return true;
                    }
                    break;

                case "Digital Output":
                    foreach(DigitalOutput doutput in digitals_o)
                    {
                        if (doutput.Tag_name.Equals(tagName))
                            return true;
                    }
                    break;

                default:
                    break;
            }

            return false;
        }

        public void Remove_Tag(String tag_type, String tag)
        {
            switch (tag_type)
            {
                case "Analog Input":
                    for (int i = 0;
                        i < analogs_i.Count; i++)
                    {
                        if (tag.Equals(analogs_i[i].TagName))
                        {
                            AnalogInput ai = analogs_i[i];

                            if (plcSimulatorManager.ainputs.TryRemove(ai.IO_address1, out ai))
                            {
                                //pass
                            }

                            analogs_i.Remove(analogs_i[i]);

                            for (int j = 0; j < alarms.Count; j++)
                            {
                                if (alarms[j].Tag.Equals(ai.TagName))
                                {
                                    Alarm al = alarms[j];

                                    alarms.Remove(alarms[j]);
                                    if (!plcSimulatorManager.flag_t5)
                                    {
                                        plcSimulatorManager.alarms.TryRemove(al.Tag, out al);
                                    }

                                    bool tmp = true;

                                    if (plcSimulatorManager.alarm_occured.TryRemove(al.Id, out tmp))
                                    {
                                        //pass
                                    }
                                }
                            }

                        }
                    }
                    break;

                case "Analog Output":
                    for (int i = 0;
                        i < analogs_o.Count; i++)
                    {
                        if (tag.Equals(analogs_o[i].TagName))
                        {
                            analogs_o.Remove(analogs_o[i]);
                        }
                    }
                    break;

                case "Digital Input":
                    for (int i = 0;
                        i < digitals_i.Count; i++)
                    {
                        if (tag.Equals(digitals_i[i].Tag_name))
                        {
                            digitals_i.Remove(digitals_i[i]);
                        }
                    }
                    break;

                case "Digital Output":
                    for (int i = 0;
                        i < digitals_o.Count; i++)
                    {
                        if (tag.Equals(digitals_o[i].Tag_name))
                        {
                            digitals_o.Remove(digitals_o[i]);
                        }
                    }
                    break;

                default:
                    break;
            }
        }

        public void Add_Alarm(Alarm alarm)
        {
            this.alarms.Add(alarm);
            plcSimulatorManager.alarms.TryAdd(alarm.Tag, alarm);

            for (int i = 0; i < analogs_i.Count; i++)
            {
                if (alarm.Tag.Equals(analogs_i[i].TagName))
                {
                    analogs_i[i].Alarms.Add(alarm); 
                }
            }
        }

        public void Remove_Alarm(String id)
        {
            for (int i = 0; i < alarms.Count; i++)
            {
                if (alarms[i].Id.Equals(id))
                {
                    Alarm rl = alarms[i];

                    if (plcSimulatorManager.alarms.TryRemove(rl.Tag, out rl))
                    {
                        //pass
                    }

                    bool tmp = true;

                    if (plcSimulatorManager.alarm_occured.TryRemove(rl.Id, out tmp))
                    {
                        //pass
                    }

                    alarms.Remove(alarms[i]);

                    foreach (AnalogInput ainput in analogs_i)
                    {
                        for (int j = 0; j < ainput.Alarms.Count; j++)
                        {
                            if (ainput.Alarms[j].Id.Equals(id))
                            {
                               

                                ainput.Alarms.Remove(ainput.Alarms[j]);
                                
                            }
                        }
                    }

                    Console.WriteLine("ALarm je obrisan.");
                }
            }
        }

        public void loadXML()
        {
            //ucitaj u alarms listu sve iz ostalih velicina

            XmlSerializer xs_analog_i = new XmlSerializer(typeof(List<AnalogInput>));
            using (FileStream read_analog_i = new FileStream(xml_analogs_i, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                analogs_i = (List<AnalogInput>)xs_analog_i.Deserialize(read_analog_i);
            }

            XmlSerializer xs_analog_o = new XmlSerializer(typeof(List<AnalogOutput>));
            using (FileStream read_analog_o = new FileStream(xml_analogs_o, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                analogs_o = (List<AnalogOutput>)xs_analog_o.Deserialize(read_analog_o);
            }

            XmlSerializer xs_digital_i = new XmlSerializer(typeof(List<DigitalInput>));
            using (FileStream read_digital_i = new FileStream(xml_digitals_i, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                digitals_i = (List<DigitalInput>)xs_digital_i.Deserialize(read_digital_i);
            }

            XmlSerializer xs_digital_o = new XmlSerializer(typeof(List<DigitalOutput>));
            using (FileStream read_digital_o = new FileStream(xml_digitals_o, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                digitals_o = (List<DigitalOutput>)xs_digital_o.Deserialize(read_digital_o);
            }

            alarms.Clear();

            for (int i = 0; i < analogs_i.Count; i++)
            {
                for (int j = 0; j < analogs_i[i].Alarms.Count; j++)
                {
                    alarms.Add(analogs_i[i].Alarms[j]);
                }
            }
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


