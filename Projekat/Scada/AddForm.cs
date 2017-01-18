﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataConcentrator;
using lib;

namespace Scada
{
    public partial class AddForm : Form
    {
        DataConcentratorManager dataConcentratorManager;

        public AddForm(DataConcentratorManager dataConcentratorManager)
        {
            this.dataConcentratorManager = dataConcentratorManager;
            InitializeComponent();
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            if(analog_digital_io.SelectedIndex >= 0)
            {
                switch (analog_digital_io.SelectedItem.ToString())
                {
                    case "Analog Input":
                        dataConcentratorManager.Add_Tag(new AnalogInput(
                            ), "Analog Input");
                        break;

                    case "Analog Output":

                        break;

                    case "Digital Input":
                        dataConcentratorManager.Add_Tag(new DigitalInput(
                            this.tag_name_textbox.Text,
                            this.description_textbox.Text,
                            this.io_address_textbox.Text,
                            int.Parse(this.scan_time_textbox.Text)
                            ), "Digital Input");
                        break;

                    case "Digital Output":

                        break;

                    default:
                        break;
                }
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void analog_digital_io_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            alarms.Hide();
            add_alarms.Hide();

            scan_time.Hide();
            scan_time_textbox.Hide();

            units.Hide();
            units_textbox.Hide();

            initial_value.Hide();
            init_value_textbox.Hide();

            if (analog_digital_io.SelectedIndex >= 0)
            {
                if (analog_digital_io.SelectedItem.Equals("Analog Input"))
                {

                    scan_time_textbox.Location = new System.Drawing.Point(101, 143);
                    scan_time.Location = new System.Drawing.Point(24, 147);

                    alarms.Location = new System.Drawing.Point(24, 174);
                    add_alarms.Location = new System.Drawing.Point(101, 169);

                    units_textbox.Location = new System.Drawing.Point(101, 198);
                    units.Location = new System.Drawing.Point(24, 201);

                    alarms.Show();
                    add_alarms.Show();

                    scan_time_textbox.Show();
                    scan_time.Show();

                    units_textbox.Show();
                    units.Show();
                }
                else if (analog_digital_io.SelectedItem.Equals("Analog Output"))
                {
                    init_value_textbox.Location = new System.Drawing.Point(101, 143);
                    initial_value.Location = new System.Drawing.Point(24, 147);

                    units_textbox.Location = new System.Drawing.Point(101, 169);
                    units.Location = new System.Drawing.Point(24, 172);

                    init_value_textbox.Show();
                    initial_value.Show();

                    units_textbox.Show();
                    units.Show();
                }
                else if (analog_digital_io.SelectedItem.Equals("Digital Input"))
                {
                    scan_time_textbox.Location = new System.Drawing.Point(101, 143);
                    scan_time.Location = new System.Drawing.Point(24, 147);

                    scan_time_textbox.Show();
                    scan_time.Show();
                }
                else
                {
                    init_value_textbox.Location = new System.Drawing.Point(101, 143);
                    initial_value.Location = new System.Drawing.Point(24, 147);

                    init_value_textbox.Show();
                    initial_value.Show();
                }
            }
        }

        private void add_alarms_Click(object sender, EventArgs e)
        {
            AddAlarm alarm = new AddAlarm(this.dataConcentratorManager);
            alarm.Show();
        }
    }
}