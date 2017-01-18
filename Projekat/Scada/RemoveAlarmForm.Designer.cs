namespace Scada
{
    partial class RemoveAlarmForm
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
            this.listView = new System.Windows.Forms.ListView();
            this.alarmID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.value = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bound = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.alarm_id = new System.Windows.Forms.Label();
            this.alarmID_textbox = new System.Windows.Forms.TextBox();
            this.remove_alarm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.alarmID,
            this.tag,
            this.value,
            this.bound});
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.LabelEdit = true;
            this.listView.Location = new System.Drawing.Point(30, 39);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(302, 185);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // alarmID
            // 
            this.alarmID.Text = "Alarm_ID";
            this.alarmID.Width = 77;
            // 
            // tag
            // 
            this.tag.Text = "Tag";
            this.tag.Width = 101;
            // 
            // value
            // 
            this.value.Text = "Value";
            // 
            // bound
            // 
            this.bound.Text = "Bound";
            // 
            // alarm_id
            // 
            this.alarm_id.AutoSize = true;
            this.alarm_id.Location = new System.Drawing.Point(46, 259);
            this.alarm_id.Name = "alarm_id";
            this.alarm_id.Size = new System.Drawing.Size(50, 13);
            this.alarm_id.TabIndex = 1;
            this.alarm_id.Text = "Alarm ID:";
            // 
            // alarmID_textbox
            // 
            this.alarmID_textbox.Location = new System.Drawing.Point(112, 256);
            this.alarmID_textbox.Name = "alarmID_textbox";
            this.alarmID_textbox.Size = new System.Drawing.Size(100, 20);
            this.alarmID_textbox.TabIndex = 2;
            // 
            // remove_alarm
            // 
            this.remove_alarm.Location = new System.Drawing.Point(229, 254);
            this.remove_alarm.Name = "remove_alarm";
            this.remove_alarm.Size = new System.Drawing.Size(86, 23);
            this.remove_alarm.TabIndex = 3;
            this.remove_alarm.Text = "Remove Alarm";
            this.remove_alarm.UseVisualStyleBackColor = true;
            this.remove_alarm.Click += new System.EventHandler(this.remove_alarm_Click);
            // 
            // RemoveAlarmForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 310);
            this.Controls.Add(this.remove_alarm);
            this.Controls.Add(this.alarmID_textbox);
            this.Controls.Add(this.alarm_id);
            this.Controls.Add(this.listView);
            this.Name = "RemoveAlarmForm";
            this.Text = "RemoveTagForm";
            this.Load += new System.EventHandler(this.RemoveAlarmForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.Label alarm_id;
        private System.Windows.Forms.TextBox alarmID_textbox;
        private System.Windows.Forms.Button remove_alarm;
        private System.Windows.Forms.ColumnHeader alarmID;
        private System.Windows.Forms.ColumnHeader tag;
        private System.Windows.Forms.ColumnHeader value;
        private System.Windows.Forms.ColumnHeader bound;
    }
}