using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ES_classification
{
    public partial class SelectOutcomeWindow : Form
    {
        private MainForm main;
        public SelectOutcomeWindow(DBWorker dbWorker)
        {
            InitializeComponent();
            main = this.Owner as MainForm;
            DataSet dSetOutcome = dbWorker.getDataSetOutcome();
            DataTable dTable = dSetOutcome.Tables[0];
            dgvOutcome.DataSource = dTable;
           // dgvOutcome.DataSource = dbWorker.getDataSetOutcome().Tables[0];
            dgvOutcome.Columns[0].HeaderText = "#";
            dgvOutcome.Columns[0].Width = 25;
            dgvOutcome.Columns[1].HeaderText = "Вывод";
            dgvOutcome.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvOutcome.Columns[2].Visible = false;
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            int selectedRow = dgvOutcome.SelectedCells[0].RowIndex;

            main.getIdOfOutcome = (int)dgvOutcome[0, selectedRow].Value;
            this.Close();
        }

        private void dgvOutput_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnChoose.Enabled = true;
        }

    }
}




