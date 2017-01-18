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
            AddForm add_form = new AddForm(dataConcentratorManager);
            add_form.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = this.dataConcentratorManager.analogs_i;
            dataConcentratorManager.loadXML();
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show(dataConcentratorManager.digitals_i.Count.ToString());
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

        private void timer_Tick(object sender, EventArgs e)
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

        private void refresh1_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void refresh()
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

        }

        private void remove_alarm_Click(object sender, EventArgs e)
        {

        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            dataConcentratorManager.saveXML();
        }
    }
}
