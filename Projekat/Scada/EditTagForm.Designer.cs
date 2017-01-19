namespace Scada
{
    partial class EditTagForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.scan_time = new System.Windows.Forms.Label();
            this.initial_value = new System.Windows.Forms.Label();
            this.units = new System.Windows.Forms.Label();
            this.tag_textbox = new System.Windows.Forms.TextBox();
            this.desc_textbox = new System.Windows.Forms.TextBox();
            this.io_textbox = new System.Windows.Forms.TextBox();
            this.stime_textbox = new System.Windows.Forms.TextBox();
            this.init_textbox = new System.Windows.Forms.TextBox();
            this.units_textbox = new System.Windows.Forms.TextBox();
            this.update = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tag Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Description:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "I/O Address:";
            // 
            // scan_time
            // 
            this.scan_time.AutoSize = true;
            this.scan_time.Location = new System.Drawing.Point(80, 119);
            this.scan_time.Name = "scan_time";
            this.scan_time.Size = new System.Drawing.Size(57, 13);
            this.scan_time.TabIndex = 3;
            this.scan_time.Text = "Scan time:";
            this.scan_time.Visible = false;
            // 
            // initial_value
            // 
            this.initial_value.AutoSize = true;
            this.initial_value.Location = new System.Drawing.Point(64, 145);
            this.initial_value.Name = "initial_value";
            this.initial_value.Size = new System.Drawing.Size(64, 13);
            this.initial_value.TabIndex = 4;
            this.initial_value.Text = "Initial Value:";
            this.initial_value.Visible = false;
            // 
            // units
            // 
            this.units.AutoSize = true;
            this.units.Location = new System.Drawing.Point(80, 169);
            this.units.Name = "units";
            this.units.Size = new System.Drawing.Size(34, 13);
            this.units.TabIndex = 5;
            this.units.Text = "Units:";
            this.units.Visible = false;
            // 
            // tag_textbox
            // 
            this.tag_textbox.Location = new System.Drawing.Point(95, 31);
            this.tag_textbox.Name = "tag_textbox";
            this.tag_textbox.Size = new System.Drawing.Size(126, 20);
            this.tag_textbox.TabIndex = 6;
            // 
            // desc_textbox
            // 
            this.desc_textbox.Location = new System.Drawing.Point(95, 58);
            this.desc_textbox.Name = "desc_textbox";
            this.desc_textbox.Size = new System.Drawing.Size(126, 20);
            this.desc_textbox.TabIndex = 7;
            // 
            // io_textbox
            // 
            this.io_textbox.Location = new System.Drawing.Point(95, 84);
            this.io_textbox.Name = "io_textbox";
            this.io_textbox.Size = new System.Drawing.Size(126, 20);
            this.io_textbox.TabIndex = 8;
            // 
            // stime_textbox
            // 
            this.stime_textbox.Location = new System.Drawing.Point(143, 119);
            this.stime_textbox.Name = "stime_textbox";
            this.stime_textbox.Size = new System.Drawing.Size(126, 20);
            this.stime_textbox.TabIndex = 9;
            this.stime_textbox.Visible = false;
            // 
            // init_textbox
            // 
            this.init_textbox.Location = new System.Drawing.Point(143, 142);
            this.init_textbox.Name = "init_textbox";
            this.init_textbox.Size = new System.Drawing.Size(126, 20);
            this.init_textbox.TabIndex = 10;
            this.init_textbox.Visible = false;
            // 
            // units_textbox
            // 
            this.units_textbox.Location = new System.Drawing.Point(143, 169);
            this.units_textbox.Name = "units_textbox";
            this.units_textbox.Size = new System.Drawing.Size(126, 20);
            this.units_textbox.TabIndex = 11;
            this.units_textbox.Visible = false;
            // 
            // update
            // 
            this.update.Location = new System.Drawing.Point(146, 226);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(75, 23);
            this.update.TabIndex = 12;
            this.update.Text = "Update";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(53, 226);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 13;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // EditTagForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.update);
            this.Controls.Add(this.units_textbox);
            this.Controls.Add(this.init_textbox);
            this.Controls.Add(this.stime_textbox);
            this.Controls.Add(this.io_textbox);
            this.Controls.Add(this.desc_textbox);
            this.Controls.Add(this.tag_textbox);
            this.Controls.Add(this.units);
            this.Controls.Add(this.initial_value);
            this.Controls.Add(this.scan_time);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EditTagForm";
            this.Text = "EditTagForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label scan_time;
        private System.Windows.Forms.Label initial_value;
        private System.Windows.Forms.Label units;
        private System.Windows.Forms.TextBox tag_textbox;
        private System.Windows.Forms.TextBox desc_textbox;
        private System.Windows.Forms.TextBox io_textbox;
        private System.Windows.Forms.TextBox stime_textbox;
        private System.Windows.Forms.TextBox init_textbox;
        private System.Windows.Forms.TextBox units_textbox;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.Button cancel;
    }
}