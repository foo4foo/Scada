using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Data;
using lib;
using DataConcentrator;
using MySql.Data.MySqlClient;

namespace Scada
{
    public partial class Main : Form
    {
        DataConcentratorManager dataConcentratorManager;
        Thread nit;

        public Main(DataConcentratorManager dataConcentratorManager)
        {


            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.dataConcentratorManager = dataConcentratorManager;
            this.dataConcentratorManager.AlarmOccured += new AlarmOccurredEventHandler(alarm_occurred);

            InitializeComponent();

            //alarm_checker = new KeyValuePair<string, double>();

            nit = new Thread(checker);

            nit.Start();
        }

        public Alarm read_from_database(String id)
        {
            //MessageBox.Show("Iz read_from_database: ", id);
            Alarm alarm = null;

            MySqlConnection conn = null;
    
            try
            {
                conn = new MySqlConnection("Server=localhost; database=mysql; UID=root; password=nemamzicu");
                conn.Open();

                string query = String.Format("SELECT * FROM alarms.alarm WHERE ID = {0}", id == null ? "qwerty" : id).ToString();

                MySqlCommand cmd = new MySqlCommand(query, conn);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    alarm = new Alarm();

                    alarm.Id = reader.GetString(0);
                    alarm.Tag = reader.GetString(1);
                    alarm.Message = reader.GetString(2);
                    alarm.setTime(reader.GetString(3));
                    alarm.Above = reader.GetInt32(4) == 1 ? true : false;
                    alarm.Limit_value = reader.GetInt32(5);
                }

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                //pass
            }
            catch (System.InvalidOperationException ex)
            {
                //pass
            } finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
                
            

            if (alarm == null)
                return new Alarm();
            return alarm;
        }

        public void checker()
        {
            while (true)
            {
                if (dataConcentratorManager.CatchAlarms().Value)
                {
                    //MessageBox.Show("Iz checkera: ", dataConcentratorManager.CatchAlarms().Key);

                    Alarm al = read_from_database(dataConcentratorManager.CatchAlarms().Key);

                    //istitaj iz baze alarm i prosledi string u event
                    this.dataConcentratorManager.AlarmOccuredFoo(
                        String.Format("Alarm (ID: {0}) occurred. {1}",
                        al.Id,
                        al.Message).ToString());

                    this.dataConcentratorManager.AlarmOccured -= (AlarmOccurredEventHandler)alarm_occurred;

                    MessageBox.Show("Posle alarma",
                            dataConcentratorManager.plcSimulatorManager.alarm_occured[
                                dataConcentratorManager.CatchAlarms().Key].ToString());

                    //ako ukonim iz alarm_occured ponovo ce se generisati jer je while petlji

                    /*TODO: ukloni alarm iz liste, zatim pamti da ga vratis kad vrednost ode
                    do druge granice !!!!*/

                    if (dataConcentratorManager.plcSimulatorManager.alarms.TryRemove(al.Tag, out al))
                    {
                        bool tmp;

                        if (dataConcentratorManager.plcSimulatorManager.alarm_occured.TryRemove(
                            al.Id, out tmp))
                        {
                            //*************************************
                            MessageBox.Show("USPEO SAM !");
                            //*************************************
                            /*TODO:IDEJA-kreirati novi dictionary u plcSim koji ce pamtiti da
                             se alarm desiti i drzati ga disejblovanog dok ponovo ne dodje
                             do te vrednosti*/
                        }
                    }

                }

                //try
                //{
                //    dataConcentratorManager.plcSimulatorManager.t5.Abort();
                //    dataConcentratorManager.plcSimulatorManager.t5.Start();
                //}
                //catch (System.Threading.ThreadStateException tex)
                //{
                //    //
                //}
            }
        }

        public void alarm_occurred(String name)
        {
            MessageBox.Show(updateMsg(name));
        }

        public String updateMsg(String name)
        {
            return this.dataConcentratorManager.getAlarmID(name);
        }

        private void add_tag_Click(object sender, EventArgs e)
        {
            AddForm add_form = new AddForm(dataConcentratorManager, this);
            add_form.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            tag_selector.SelectedItem = "Analog Input";
            dataConcentratorManager.loadXML();
        }

        private void tag_selector_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            if (tag_selector.SelectedIndex >= 0)
            {
                if (tag_selector.SelectedItem.Equals("Analog Input"))
                    dataGridView1.DataSource = this.dataConcentratorManager.analogs_i;
                else if (tag_selector.SelectedItem.Equals("Analog Output"))
                    dataGridView1.DataSource = this.dataConcentratorManager.analogs_o;
                else if (tag_selector.SelectedItem.Equals("Digital Input"))
                    dataGridView1.DataSource = this.dataConcentratorManager.digitals_i;
                else
                    dataGridView1.DataSource = this.dataConcentratorManager.digitals_o;
            }
        }

        private void add_alarm_Click(object sender, EventArgs e)
        {
            AddAlarm addAlarm = new AddAlarm(this.dataConcentratorManager);
            addAlarm.Show();
        }

        public void refresh()
        {
            dataGridView1.DataSource = null;
            if (tag_selector.SelectedIndex >= 0)
            {
                if (tag_selector.SelectedItem.Equals("Analog Input"))
                    dataGridView1.DataSource = this.dataConcentratorManager.analogs_i;
                else if (tag_selector.SelectedItem.Equals("Analog Output"))
                    dataGridView1.DataSource = this.dataConcentratorManager.analogs_o;
                else if (tag_selector.SelectedItem.Equals("Digital Input"))
                    dataGridView1.DataSource = this.dataConcentratorManager.digitals_i;
                else
                    dataGridView1.DataSource = this.dataConcentratorManager.digitals_o;
            }
        }

        private void remove_tag_Click(object sender, EventArgs e)
        {
            if (tag_selector.SelectedIndex >= 0)
            {
                dataConcentratorManager.Remove_Tag(tag_selector.SelectedItem.ToString(),
                    tag_name_textbox.Text);
                tag_name_textbox.Text = "";

                refresh();
            }
            else
            {
                MessageBox.Show("Please select Tag type first.");
            }
        }

        private void remove_alarm_Click(object sender, EventArgs e)
        {
            RemoveAlarmForm raf = new RemoveAlarmForm(this.dataConcentratorManager);
            raf.Show();
            //proveri da li se brise alarm
            MessageBox.Show(dataConcentratorManager.plcSimulatorManager.alarms.Count.ToString());
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            dataConcentratorManager.saveXML();

            if (!dataConcentratorManager.plcSimulatorManager.flag_t1)
            {
                dataConcentratorManager.plcSimulatorManager.t1.Abort();
            }

            if (!dataConcentratorManager.plcSimulatorManager.flag_t2)
            {
                dataConcentratorManager.plcSimulatorManager.t2.Abort();
            }

            if (!dataConcentratorManager.plcSimulatorManager.flag_t3)
            {
                dataConcentratorManager.plcSimulatorManager.t3.Abort();
            }

            if (!dataConcentratorManager.plcSimulatorManager.flag_t4)
            {
                dataConcentratorManager.plcSimulatorManager.t4.Abort();
            }

            if (!dataConcentratorManager.plcSimulatorManager.flag_t5)
            {
                dataConcentratorManager.plcSimulatorManager.t5.Abort();
            }
            
            Environment.Exit(0);
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*if (e.Equals(Keys.Enter))
            {
                List<AnalogInput> myClass = dataGridView1.DataSource as List<AnalogInput>;
                dataConcentratorManager.analogs_i.Clear();
                dataConcentratorManager.analogs_i = myClass.ToList();
            }*/
        }

        private void edit_Click(object sender, EventArgs e)
        {
            if(tag_selector.SelectedIndex >= 0)
            {
                if (tag_name_textbox.Text != "")
                {
                    EditTagForm et = new EditTagForm(tag_selector.Text, tag_name_textbox.Text,
                        this.dataConcentratorManager, this);
                    if (et.tag_exists())
                    {
                        et.display_content();
                        et.Show();
                    }
                    else
                        MessageBox.Show("Tag doesn't exists.");
                } else
                {
                    MessageBox.Show("Please enter tag name.");
                }
            } else
            {
                MessageBox.Show("Please select tag type.");
            }
        }
    }
}
