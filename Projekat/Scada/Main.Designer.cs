namespace Scada
{
    partial class Main
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.add_tag = new System.Windows.Forms.Button();
            this.tag_selector = new System.Windows.Forms.ComboBox();
            this.remove_tag = new System.Windows.Forms.Button();
            this.remove_alarm = new System.Windows.Forms.Button();
            this.add_alarm = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tag_name_textbox = new System.Windows.Forms.TextBox();
            this.edit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(543, 208);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            // 
            // add_tag
            // 
            this.add_tag.Location = new System.Drawing.Point(12, 255);
            this.add_tag.Name = "add_tag";
            this.add_tag.Size = new System.Drawing.Size(114, 23);
            this.add_tag.TabIndex = 1;
            this.add_tag.Text = "Add Tag";
            this.add_tag.UseVisualStyleBackColor = true;
            this.add_tag.Click += new System.EventHandler(this.add_tag_Click);
            // 
            // tag_selector
            // 
            this.tag_selector.FormattingEnabled = true;
            this.tag_selector.Items.AddRange(new object[] {
            "Analog Input",
            "Analog Output",
            "Digital Input",
            "Digital Output"});
            this.tag_selector.Location = new System.Drawing.Point(434, 10);
            this.tag_selector.Name = "tag_selector";
            this.tag_selector.Size = new System.Drawing.Size(121, 21);
            this.tag_selector.TabIndex = 3;
            this.tag_selector.SelectedIndexChanged += new System.EventHandler(this.tag_selector_SelectedIndexChanged);
            // 
            // remove_tag
            // 
            this.remove_tag.Location = new System.Drawing.Point(182, 289);
            this.remove_tag.Name = "remove_tag";
            this.remove_tag.Size = new System.Drawing.Size(102, 23);
            this.remove_tag.TabIndex = 4;
            this.remove_tag.Text = "Remove Tag";
            this.remove_tag.UseVisualStyleBackColor = true;
            this.remove_tag.Click += new System.EventHandler(this.remove_tag_Click);
            // 
            // remove_alarm
            // 
            this.remove_alarm.Location = new System.Drawing.Point(454, 255);
            this.remove_alarm.Name = "remove_alarm";
            this.remove_alarm.Size = new System.Drawing.Size(102, 23);
            this.remove_alarm.TabIndex = 5;
            this.remove_alarm.Text = "Remove Alarm";
            this.remove_alarm.UseVisualStyleBackColor = true;
            this.remove_alarm.Click += new System.EventHandler(this.remove_alarm_Click);
            // 
            // add_alarm
            // 
            this.add_alarm.Location = new System.Drawing.Point(345, 255);
            this.add_alarm.Name = "add_alarm";
            this.add_alarm.Size = new System.Drawing.Size(102, 23);
            this.add_alarm.TabIndex = 6;
            this.add_alarm.Text = "Add Alarm";
            this.add_alarm.UseVisualStyleBackColor = true;
            this.add_alarm.Click += new System.EventHandler(this.add_alarm_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(339, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Select Tag Type:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 294);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Tag Name:";
            // 
            // tag_name_textbox
            // 
            this.tag_name_textbox.Location = new System.Drawing.Point(76, 290);
            this.tag_name_textbox.Name = "tag_name_textbox";
            this.tag_name_textbox.Size = new System.Drawing.Size(100, 20);
            this.tag_name_textbox.TabIndex = 10;
            // 
            // edit
            // 
            this.edit.Location = new System.Drawing.Point(291, 289);
            this.edit.Name = "edit";
            this.edit.Size = new System.Drawing.Size(95, 23);
            this.edit.TabIndex = 11;
            this.edit.Text = "Edit Tag";
            this.edit.UseVisualStyleBackColor = true;
            this.edit.Click += new System.EventHandler(this.edit_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 335);
            this.Controls.Add(this.edit);
            this.Controls.Add(this.tag_name_textbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.add_alarm);
            this.Controls.Add(this.remove_alarm);
            this.Controls.Add(this.remove_tag);
            this.Controls.Add(this.tag_selector);
            this.Controls.Add(this.add_tag);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Main";
            this.Text = "Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button add_tag;
        private System.Windows.Forms.ComboBox tag_selector;
        private System.Windows.Forms.Button remove_tag;
        private System.Windows.Forms.Button remove_alarm;
        private System.Windows.Forms.Button add_alarm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tag_name_textbox;
        private System.Windows.Forms.Button edit;
    }
}