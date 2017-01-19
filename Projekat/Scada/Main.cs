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
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            dataConcentratorManager.saveXML();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.Equals(Keys.Enter))
            //{
            //    List<AnalogInput> myClass = dataGridView1.DataSource as List<AnalogInput>;
            //    dataConcentratorManager.analogs_i.Clear();
            //    dataConcentratorManager.analogs_i = myClass.ToList();
            //}
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
