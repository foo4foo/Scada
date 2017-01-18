using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using lib;
using DataConcentrator;

namespace Scada
{
    public partial class Main : Form
    {
        DataConcentratorManager dataConcentratorManager;

        public Main(DataConcentratorManager dataConcentratorManager)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.dataConcentratorManager = dataConcentratorManager;
            InitializeComponent();
        }

        private void add_tag_Click(object sender, EventArgs e)
        {
            AddForm add_form = new AddForm(dataConcentratorManager, this);
            add_form.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = this.dataConcentratorManager.analogs_i;
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
                switch (tag_selector.SelectedItem.ToString())
                {
                    case "Analog Input":
                        for (int i = 0;
                            i < dataConcentratorManager.analogs_i.Count; i++)
                        {
                            if (tag_name_textbox.Text.Equals(dataConcentratorManager.analogs_i[i].TagName))
                            {
                                dataConcentratorManager.analogs_i.Remove(dataConcentratorManager.analogs_i[i]);
                                tag_name_textbox.Text = "";
                            }
                        }
                        break;

                    case "Analog Output":
                        for (int i = 0;
                            i < dataConcentratorManager.analogs_o.Count; i++)
                        {
                            if (tag_name_textbox.Text.Equals(dataConcentratorManager.analogs_o[i].TagName))
                            {
                                dataConcentratorManager.analogs_o.Remove(dataConcentratorManager.analogs_o[i]);
                                tag_name_textbox.Text = "";
                            }
                        }
                        break;

                    case "Digital Input":
                        for (int i = 0;
                            i < dataConcentratorManager.digitals_i.Count; i++)
                        {
                            if (tag_name_textbox.Text.Equals(dataConcentratorManager.digitals_i[i].Tag_name))
                            {
                                dataConcentratorManager.digitals_i.Remove(dataConcentratorManager.digitals_i[i]);
                                tag_name_textbox.Text = "";
                            }
                        }
                        break;

                    case "Digital Output":
                        for (int i = 0;
                            i < dataConcentratorManager.digitals_o.Count; i++)
                        {
                            if (tag_name_textbox.Text.Equals(dataConcentratorManager.digitals_o[i].Tag_name))
                            {
                                dataConcentratorManager.digitals_o.Remove(dataConcentratorManager.digitals_o[i]);
                                tag_name_textbox.Text = "";
                            }
                        }
                        break;

                    default:
                        break;
                }
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
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            dataConcentratorManager.saveXML();
        }
    }
}
