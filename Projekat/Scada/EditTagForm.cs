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
    public partial class EditTagForm : Form
    {
        private String tag_type;

        private String previous_name;

        public DataConcentratorManager dataConcentratorManager;
        Main form;

        public EditTagForm(String type, String tag_name, 
            DataConcentratorManager dataConcentratorManager, Main main)
        {

            this.dataConcentratorManager = dataConcentratorManager;
            this.dataConcentratorManager.TagValueChanged += new TagValueChangedEventHanlder(tag_changed);
            //AlarmOccurred += new AlarmOccuredEventHanlder(alarm);
            this.form = main;
            this.previous_name = tag_name;
            this.tag_type = type;

            InitializeComponent();
        }

        public void tag_changed(String name)
        {
            MessageBox.Show(updateMsg(name));
        }

        public String updateMsg(String name)
        {
            return "Tag has been updated";
        }

        public bool tag_exists()
        {
            switch (tag_type)
            {
                case "Analog Input":

                    foreach(lib.AnalogInput ainput in dataConcentratorManager.analogs_i)
                    {
                        if (ainput.TagName.Equals(previous_name))
                            return true;
                    }

                    break;

                case "Analog Output":
                    foreach(lib.AnalogOutput aoutput in dataConcentratorManager.analogs_o)
                    {
                        if (aoutput.TagName.Equals(previous_name))
                            return true;
                    }
                    break;

                case "Digital Input":
                    foreach (lib.DigitalInput dinput in dataConcentratorManager.digitals_i)
                    {
                        if (dinput.Tag_name.Equals(previous_name))
                            return true;
                    }
                    break;

                case "Digital Output":
                    foreach(lib.DigitalOutput doutput in dataConcentratorManager.digitals_o)
                    {
                        if (doutput.Tag_name.Equals(previous_name))
                            return true;
                    }

                    break;

                default:
                    break;
            }

            return false;
        }

        public void display_content()
        {
            //izmeni ime taga u alarmu ako mu se ime promeni
            switch (tag_type)
            {
                case "Analog Input":
                    stime_textbox.Location = new System.Drawing.Point(95, 110);
                    scan_time.Location = new System.Drawing.Point(23, 114);

                    units_textbox.Location = new System.Drawing.Point(95, 136);
                    units.Location = new System.Drawing.Point(23, 141);

                    stime_textbox.Show();
                    scan_time.Show();

                    units_textbox.Show();
                    units.Show();

                    //populate fields

                    //previous tag_name

                    lib.AnalogInput ainput = (lib.AnalogInput)getTag();

                    tag_textbox.Text = ainput.TagName;
                    desc_textbox.Text = ainput.Description;
                    io_textbox.Text = ainput.IO_address1;
                    stime_textbox.Text = ainput.Scan_time.ToString();
                    units_textbox.Text = ainput.Units;

                    //izmeni alarm

                    break;

                case "Analog Output":
                    init_textbox.Location = new System.Drawing.Point(95, 110);
                    initial_value.Location = new System.Drawing.Point(23, 114);

                    units_textbox.Location = new System.Drawing.Point(95, 136);
                    units.Location = new System.Drawing.Point(23, 141);

                    init_textbox.Show();
                    initial_value.Show();

                    units_textbox.Show();
                    units.Show();

                    //populate fields

                    //previous tag_name

                    lib.AnalogOutput aoutput = (lib.AnalogOutput)getTag();

                    tag_textbox.Text = aoutput.TagName;
                    desc_textbox.Text = aoutput.Description;
                    io_textbox.Text = aoutput.IO_address1;
                    init_textbox.Text = aoutput.Initial_value.ToString();
                    units_textbox.Text = aoutput.Units;

                    break;

                case "Digital Input":
                    stime_textbox.Location = new System.Drawing.Point(95, 110);
                    scan_time.Location = new System.Drawing.Point(23, 114);

                    stime_textbox.Show();
                    scan_time.Show();

                    lib.DigitalInput dinput = (lib.DigitalInput)getTag();

                    tag_textbox.Text = dinput.Tag_name;
                    desc_textbox.Text = dinput.Description;
                    io_textbox.Text = dinput.IO_address1;
                    stime_textbox.Text = dinput.Scan_time.ToString();

                    break;

                case "Digital Output":
                    init_textbox.Location = new System.Drawing.Point(95, 110);
                    initial_value.Location = new System.Drawing.Point(23, 114);

                    init_textbox.Show();
                    initial_value.Show();

                    lib.DigitalOutput doutput = (lib.DigitalOutput)getTag();

                    tag_textbox.Text = doutput.Tag_name;
                    desc_textbox.Text = doutput.Description;
                    io_textbox.Text = doutput.IO_address1;
                    init_textbox.Text = doutput.Initial_value.ToString();

                    break;


                default:
                    break;
            }
        }

        private Object getTag()
        {
            switch (tag_type)
            {
                case "Analog Input":
                    foreach(lib.AnalogInput ainput in dataConcentratorManager.analogs_i)
                    {
                        if (ainput.TagName.Equals(previous_name))
                            return ainput;
                    }
                    break;

                case "Analog Output":
                    foreach(lib.AnalogOutput aoutput in dataConcentratorManager.analogs_o)
                    {
                        if (aoutput.TagName.Equals(previous_name))
                            return aoutput;
                    }
                    break;

                case "Digital Input":
                    foreach(lib.DigitalInput dinput in dataConcentratorManager.digitals_i)
                    {
                        if (dinput.Tag_name.Equals(previous_name))
                            return dinput;
                    }
                    break;

                case "Digital Output":
                    foreach(lib.DigitalOutput doutput in dataConcentratorManager.digitals_o)
                    {
                        if (doutput.Tag_name.Equals(previous_name))
                            return doutput;
                    }
                    break;
                default:
                    break;
            }
            return new Object();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void update_Click(object sender, EventArgs e)
        {
            switch (tag_type)
            {
                case "Analog Input":
                    for(int i = 0; i < dataConcentratorManager.analogs_i.Count; i++)
                    {
                        if (dataConcentratorManager.analogs_i[i].TagName.Equals(previous_name))
                        {
                            dataConcentratorManager.analogs_i[i].TagName = tag_textbox.Text;
                            dataConcentratorManager.analogs_i[i].Description = desc_textbox.Text;
                            dataConcentratorManager.analogs_i[i].IO_address1 = io_textbox.Text;
                            dataConcentratorManager.analogs_i[i].Scan_time = int.Parse(stime_textbox.Text);
                            dataConcentratorManager.analogs_i[i].Units = units_textbox.Text;

                            break;
                        }
                    }

                    for(int j = 0; j < dataConcentratorManager.alarms.Count; j++)
                    {
                        if (dataConcentratorManager.alarms[j].Tag.Equals(previous_name))
                        {
                            dataConcentratorManager.alarms[j].Tag = tag_textbox.Text;
                        }
                    }

                    this.form.refresh();

                    this.dataConcentratorManager.TagChanged(updateMsg(""));

                    this.dataConcentratorManager.TagValueChanged -= (TagValueChangedEventHanlder)tag_changed;

                    //dataConcentratorManager.write_alarm_info();

                    break;

                case "Analog Output":
                    for (int i = 0; i < dataConcentratorManager.analogs_o.Count; i++)
                    {
                        if (dataConcentratorManager.analogs_o[i].TagName.Equals(previous_name))
                        {
                            dataConcentratorManager.analogs_o[i].TagName = tag_textbox.Text;
                            dataConcentratorManager.analogs_o[i].Description = desc_textbox.Text;
                            dataConcentratorManager.analogs_o[i].IO_address1 = io_textbox.Text;
                            dataConcentratorManager.analogs_o[i].Initial_value = int.Parse(init_textbox.Text);
                            dataConcentratorManager.analogs_o[i].Units = units_textbox.Text;

                            break;
                        }
                    }

                    this.form.refresh();

                    this.dataConcentratorManager.TagChanged(updateMsg(""));

                    this.dataConcentratorManager.TagValueChanged -= (TagValueChangedEventHanlder)tag_changed;

                    break;

                case "Digital Input":
                    for (int i = 0; i < dataConcentratorManager.digitals_i.Count; i++)
                    {
                        if (dataConcentratorManager.digitals_i[i].Tag_name.Equals(previous_name))
                        {
                            dataConcentratorManager.digitals_i[i].Tag_name = tag_textbox.Text;
                            dataConcentratorManager.digitals_i[i].Description = desc_textbox.Text;
                            dataConcentratorManager.digitals_i[i].IO_address1 = io_textbox.Text;
                            dataConcentratorManager.digitals_i[i].Scan_time = int.Parse(stime_textbox.Text);

                            break;
                        }
                    }

                    this.form.refresh();

                    this.dataConcentratorManager.TagChanged(updateMsg(""));

                    this.dataConcentratorManager.TagValueChanged -= (TagValueChangedEventHanlder)tag_changed;

                    break;

                case "Digital Output":

                    for (int i = 0; i < dataConcentratorManager.analogs_i.Count; i++)
                    {
                        if (dataConcentratorManager.digitals_o[i].Tag_name.Equals(previous_name))
                        {
                            dataConcentratorManager.digitals_o[i].Tag_name = tag_textbox.Text;
                            dataConcentratorManager.digitals_o[i].Description = desc_textbox.Text;
                            dataConcentratorManager.digitals_o[i].IO_address1 = io_textbox.Text;
                            dataConcentratorManager.digitals_o[i].Initial_value = int.Parse(init_textbox.Text);


                            break;
                        }
                    }

                    this.form.refresh();

                    this.dataConcentratorManager.TagChanged(updateMsg(""));

                    this.dataConcentratorManager.TagValueChanged -= (TagValueChangedEventHanlder)tag_changed;

                    break;

                default:
                    break;
            }
        }
    }
}
