namespace Scada
{
    partial class AddAlarm
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
            this.add_more = new System.Windows.Forms.Button();
            this.tag = new System.Windows.Forms.Label();
            this.message = new System.Windows.Forms.Label();
            this.bound = new System.Windows.Forms.Label();
            this.value = new System.Windows.Forms.Label();
            this.tag_textbox = new System.Windows.Forms.TextBox();
            this.message_textbox = new System.Windows.Forms.TextBox();
            this.value_textbox = new System.Windows.Forms.TextBox();
            this.bound_combo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // submit
            // 
            this.submit.Location = new System.Drawing.Point(58, 215);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(75, 23);
            this.submit.TabIndex = 0;
            this.submit.Text = "Submit";
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // add_more
            // 
            this.add_more.Location = new System.Drawing.Point(149, 215);
            this.add_more.Name = "add_more";
            this.add_more.Size = new System.Drawing.Size(75, 23);
            this.add_more.TabIndex = 1;
            this.add_more.Text = "Add more";
            this.add_more.UseVisualStyleBackColor = true;
            this.add_more.Click += new System.EventHandler(this.add_more_Click);
            // 
            // tag
            // 
            this.tag.AutoSize = true;
            this.tag.Location = new System.Drawing.Point(55, 36);
            this.tag.Name = "tag";
            this.tag.Size = new System.Drawing.Size(29, 13);
            this.tag.TabIndex = 2;
            this.tag.Text = "Tag:";
            // 
            // message
            // 
            this.message.AutoSize = true;
            this.message.Location = new System.Drawing.Point(55, 72);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(53, 13);
            this.message.TabIndex = 3;
            this.message.Text = "Message:";
            // 
            // bound
            // 
            this.bound.AutoSize = true;
            this.bound.Location = new System.Drawing.Point(55, 110);
            this.bound.Name = "bound";
            this.bound.Size = new System.Drawing.Size(41, 13);
            this.bound.TabIndex = 4;
            this.bound.Text = "Bound:";
            // 
            // value
            // 
            this.value.AutoSize = true;
            this.value.Location = new System.Drawing.Point(55, 151);
            this.value.Name = "value";
            this.value.Size = new System.Drawing.Size(37, 13);
            this.value.TabIndex = 5;
            this.value.Text = "Value:";
            // 
            // tag_textbox
            // 
            this.tag_textbox.Location = new System.Drawing.Point(122, 36);
            this.tag_textbox.Name = "tag_textbox";
            this.tag_textbox.Size = new System.Drawing.Size(100, 20);
            this.tag_textbox.TabIndex = 6;
            // 
            // message_textbox
            // 
            this.message_textbox.Location = new System.Drawing.Point(122, 72);
            this.message_textbox.Name = "message_textbox";
            this.message_textbox.Size = new System.Drawing.Size(100, 20);
            this.message_textbox.TabIndex = 7;
            // 
            // value_textbox
            // 
            this.value_textbox.Location = new System.Drawing.Point(122, 151);
            this.value_textbox.Name = "value_textbox";
            this.value_textbox.Size = new System.Drawing.Size(100, 20);
            this.value_textbox.TabIndex = 9;
            // 
            // bound_combo
            // 
            this.bound_combo.FormattingEnabled = true;
            this.bound_combo.Items.AddRange(new object[] {
            "Above",
            "Below"});
            this.bound_combo.Location = new System.Drawing.Point(122, 110);
            this.bound_combo.Name = "bound_combo";
            this.bound_combo.Size = new System.Drawing.Size(100, 21);
            this.bound_combo.TabIndex = 10;
            // 
            // AddAlarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 250);
            this.Controls.Add(this.bound_combo);
            this.Controls.Add(this.value_textbox);
            this.Controls.Add(this.message_textbox);
            this.Controls.Add(this.tag_textbox);
            this.Controls.Add(this.value);
            this.Controls.Add(this.bound);
            this.Controls.Add(this.message);
            this.Controls.Add(this.tag);
            this.Controls.Add(this.add_more);
            this.Controls.Add(this.submit);
            this.Name = "AddAlarm";
            this.Text = "AddAlarm";
            this.Load += new System.EventHandler(this.AddAlarm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button submit;
        private System.Windows.Forms.Button add_more;
        private System.Windows.Forms.Label tag;
        private System.Windows.Forms.Label message;
        private System.Windows.Forms.Label bound;
        private System.Windows.Forms.Label value;
        private System.Windows.Forms.TextBox tag_textbox;
        private System.Windows.Forms.TextBox message_textbox;
        private System.Windows.Forms.TextBox value_textbox;
        private System.Windows.Forms.ComboBox bound_combo;
    }
}