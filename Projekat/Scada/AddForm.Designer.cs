namespace Scada
{
    partial class AddForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.submit = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.analog_digital_io = new System.Windows.Forms.ComboBox();
            this.tag_name = new System.Windows.Forms.Label();
            this.description = new System.Windows.Forms.Label();
            this.io_address = new System.Windows.Forms.Label();
            this.scan_time = new System.Windows.Forms.Label();
            this.initial_value = new System.Windows.Forms.Label();
            this.units = new System.Windows.Forms.Label();
            this.tag_name_textbox = new System.Windows.Forms.TextBox();
            this.description_textbox = new System.Windows.Forms.TextBox();
            this.io_address_textbox = new System.Windows.Forms.TextBox();
            this.scan_time_textbox = new System.Windows.Forms.TextBox();
            this.init_value_textbox = new System.Windows.Forms.TextBox();
            this.units_textbox = new System.Windows.Forms.TextBox();
            this.add_alarms = new System.Windows.Forms.Button();
            this.alarms = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // submit
            // 
            this.submit.Location = new System.Drawing.Point(160, 301);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(75, 23);
            this.submit.TabIndex = 0;
            this.submit.Text = "Submit";
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(52, 301);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 1;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // analog_digital_io
            // 
            this.analog_digital_io.DisplayMember = "Analog";
            this.analog_digital_io.FormattingEnabled = true;
            this.analog_digital_io.Items.AddRange(new object[] {
            "Analog Input",
            "Analog Output",
            "Digital Input",
            "Digital Output"});
            this.analog_digital_io.Location = new System.Drawing.Point(75, 12);
            this.analog_digital_io.Name = "analog_digital_io";
            this.analog_digital_io.Size = new System.Drawing.Size(121, 21);
            this.analog_digital_io.TabIndex = 3;
            this.analog_digital_io.Text = "Analog/Digital IO";
            this.analog_digital_io.SelectedIndexChanged += new System.EventHandler(this.analog_digital_io_SelectedIndexChanged_1);
            // 
            // tag_name
            // 
            this.tag_name.AutoSize = true;
            this.tag_name.Location = new System.Drawing.Point(24, 66);
            this.tag_name.Name = "tag_name";
            this.tag_name.Size = new System.Drawing.Size(58, 13);
            this.tag_name.TabIndex = 4;
            this.tag_name.Text = "Tag name:";
            // 
            // description
            // 
            this.description.AutoSize = true;
            this.description.Location = new System.Drawing.Point(24, 93);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(63, 13);
            this.description.TabIndex = 5;
            this.description.Text = "Description:";
            // 
            // io_address
            // 
            this.io_address.AutoSize = true;
            this.io_address.Location = new System.Drawing.Point(24, 120);
            this.io_address.Name = "io_address";
            this.io_address.Size = new System.Drawing.Size(67, 13);
            this.io_address.TabIndex = 6;
            this.io_address.Text = "I/O Address:";
            // 
            // scan_time
            // 
            this.scan_time.AutoSize = true;
            this.scan_time.Location = new System.Drawing.Point(49, 177);
            this.scan_time.Name = "scan_time";
            this.scan_time.Size = new System.Drawing.Size(57, 13);
            this.scan_time.TabIndex = 7;
            this.scan_time.Text = "Scan time:";
            this.scan_time.Visible = false;
            // 
            // initial_value
            // 
            this.initial_value.AutoSize = true;
            this.initial_value.Location = new System.Drawing.Point(42, 214);
            this.initial_value.Name = "initial_value";
            this.initial_value.Size = new System.Drawing.Size(64, 13);
            this.initial_value.TabIndex = 8;
            this.initial_value.Text = "Initial Value:";
            this.initial_value.Visible = false;
            // 
            // units
            // 
            this.units.AutoSize = true;
            this.units.Location = new System.Drawing.Point(72, 248);
            this.units.Name = "units";
            this.units.Size = new System.Drawing.Size(34, 13);
            this.units.TabIndex = 9;
            this.units.Text = "Units:";
            this.units.Visible = false;
            // 
            // tag_name_textbox
            // 
            this.tag_name_textbox.Location = new System.Drawing.Point(101, 65);
            this.tag_name_textbox.Name = "tag_name_textbox";
            this.tag_name_textbox.Size = new System.Drawing.Size(149, 20);
            this.tag_name_textbox.TabIndex = 10;
            // 
            // description_textbox
            // 
            this.description_textbox.Location = new System.Drawing.Point(101, 91);
            this.description_textbox.Name = "description_textbox";
            this.description_textbox.Size = new System.Drawing.Size(149, 20);
            this.description_textbox.TabIndex = 11;
            // 
            // io_address_textbox
            // 
            this.io_address_textbox.Location = new System.Drawing.Point(101, 117);
            this.io_address_textbox.Name = "io_address_textbox";
            this.io_address_textbox.Size = new System.Drawing.Size(149, 20);
            this.io_address_textbox.TabIndex = 12;
            // 
            // scan_time_textbox
            // 
            this.scan_time_textbox.Location = new System.Drawing.Point(125, 170);
            this.scan_time_textbox.Name = "scan_time_textbox";
            this.scan_time_textbox.Size = new System.Drawing.Size(149, 20);
            this.scan_time_textbox.TabIndex = 13;
            this.scan_time_textbox.Visible = false;
            // 
            // init_value_textbox
            // 
            this.init_value_textbox.Location = new System.Drawing.Point(125, 214);
            this.init_value_textbox.Name = "init_value_textbox";
            this.init_value_textbox.Size = new System.Drawing.Size(149, 20);
            this.init_value_textbox.TabIndex = 14;
            this.init_value_textbox.Visible = false;
            // 
            // units_textbox
            // 
            this.units_textbox.Location = new System.Drawing.Point(125, 245);
            this.units_textbox.Name = "units_textbox";
            this.units_textbox.Size = new System.Drawing.Size(149, 20);
            this.units_textbox.TabIndex = 15;
            this.units_textbox.Visible = false;
            // 
            // add_alarms
            // 
            this.add_alarms.Location = new System.Drawing.Point(121, 141);
            this.add_alarms.Name = "add_alarms";
            this.add_alarms.Size = new System.Drawing.Size(75, 23);
            this.add_alarms.TabIndex = 16;
            this.add_alarms.Text = "Add";
            this.add_alarms.UseVisualStyleBackColor = true;
            this.add_alarms.Visible = false;
            this.add_alarms.Click += new System.EventHandler(this.add_alarms_Click);
            // 
            // alarms
            // 
            this.alarms.AutoSize = true;
            this.alarms.Location = new System.Drawing.Point(45, 150);
            this.alarms.Name = "alarms";
            this.alarms.Size = new System.Drawing.Size(41, 13);
            this.alarms.TabIndex = 17;
            this.alarms.Text = "Alarms:";
            this.alarms.Visible = false;
            // 
            // AddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 336);
            this.Controls.Add(this.alarms);
            this.Controls.Add(this.add_alarms);
            this.Controls.Add(this.units_textbox);
            this.Controls.Add(this.init_value_textbox);
            this.Controls.Add(this.scan_time_textbox);
            this.Controls.Add(this.io_address_textbox);
            this.Controls.Add(this.description_textbox);
            this.Controls.Add(this.tag_name_textbox);
            this.Controls.Add(this.units);
            this.Controls.Add(this.initial_value);
            this.Controls.Add(this.scan_time);
            this.Controls.Add(this.io_address);
            this.Controls.Add(this.description);
            this.Controls.Add(this.tag_name);
            this.Controls.Add(this.analog_digital_io);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.submit);
            this.Name = "AddForm";
            this.Text = "Scada";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button submit;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.ComboBox analog_digital_io;
        private System.Windows.Forms.Label tag_name;
        private System.Windows.Forms.Label description;
        private System.Windows.Forms.Label io_address;
        private System.Windows.Forms.Label scan_time;
        private System.Windows.Forms.Label initial_value;
        private System.Windows.Forms.Label units;
        private System.Windows.Forms.TextBox tag_name_textbox;
        private System.Windows.Forms.TextBox description_textbox;
        private System.Windows.Forms.TextBox io_address_textbox;
        private System.Windows.Forms.TextBox scan_time_textbox;
        private System.Windows.Forms.TextBox init_value_textbox;
        private System.Windows.Forms.TextBox units_textbox;
        private System.Windows.Forms.Button add_alarms;
        private System.Windows.Forms.Label alarms;
    }
}

