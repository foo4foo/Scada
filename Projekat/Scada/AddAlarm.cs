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
    public partial class AddAlarm : Form
    {
        DataConcentratorManager dataConcentratorManager;

        public AddAlarm(DataConcentratorManager dataConcentratorManager)
        {
            this.dataConcentratorManager = dataConcentratorManager;

            InitializeComponent();
        }

        private void add_more_Click(object sender, EventArgs e)
        {
            tag_textbox.Text = "";
            message_textbox.Text = "";
            value_textbox.Text = "";
            bound_combo.ResetText();
        }

        private void submit_Click(object sender, EventArgs e)
        {
            dataConcentratorManager.Add_Alarm(
                new lib.Alarm(
                    generateID().GetHashCode().ToString(),
                    tag_textbox.Text,
                    message_textbox.Text,
                    DateTime.Now.ToString("yyyy - MM - dd hh: mm:ss"),
                    (string)bound_combo.SelectedItem == "Above" ? true : false,
                    int.Parse(value_textbox.Text)
                    )
                );
        }

        private String generateID()
        {
            StringBuilder id = new StringBuilder(tag_textbox.Text);

            id.Append(message_textbox.Text);
            id.Append(value_textbox.Text);
            id.Append(bound_combo.SelectedItem.ToString());
            id.Append(DateTime.Now.ToString());

            return id.ToString();
        }
    }
}
