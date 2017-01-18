using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataConcentrator;

namespace Scada
{
    public partial class RemoveAlarmForm : Form
    {
        DataConcentratorManager dataConcentratorManager;

        public RemoveAlarmForm(DataConcentratorManager dataConcentratorManager)
        {
            this.dataConcentratorManager = dataConcentratorManager;
            InitializeComponent();
        }

        private void updateList()
        {
            foreach (lib.Alarm alarm in dataConcentratorManager.alarms)
            {
                ListViewItem item = new ListViewItem(alarm.Id);
                item.SubItems.Add(alarm.Tag);
                item.SubItems.Add(alarm.Limit_value.ToString());
                item.SubItems.Add(alarm.Above == true ? "Above" : "Below");
                listView.Items.Add(item);
            }
        }

        private void remove_alarm_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < dataConcentratorManager.alarms.Count; i++)
            {
                if (dataConcentratorManager.alarms[i].Id.Equals(alarmID_textbox.Text))
                {
                    dataConcentratorManager.alarms.Remove(dataConcentratorManager.alarms[i]);
                }
            }


            listView.Items.Clear();
            updateList();
        }

        private void RemoveAlarmForm_Load(object sender, EventArgs e)
        {
            updateList();
        }
    }
}
