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
    public partial class AddFunctionalAreaForm : Form
    {
        private DBWorker dbWorker;
        public AddFunctionalAreaForm(DBWorker dbw)
        {
            InitializeComponent();
            this.dbWorker = dbw;
        }

        private void btnAddFunctionalArea_Click(object sender, EventArgs e)
        {
            string funcAreaName = tbFunctionalAreaName.Text.ToString();
            try
            {
                dbWorker.addNewFunctionalArea(funcAreaName);
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message);
            }

            MessageBox.Show(string.Format("Функциональная область \"{0}\" была успешно добавлена!", funcAreaName));
            tbFunctionalAreaName.Text = null;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
