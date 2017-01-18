using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            this.dataConcentratorManager = dataConcentratorManager;
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void add_tag_Click(object sender, EventArgs e)
        {
            AddForm add_form = new AddForm(dataConcentratorManager);
            add_form.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = this.dataConcentratorManager.digitals_i;
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = this.dataConcentratorManager.digitals_i;
        }
    }
}
