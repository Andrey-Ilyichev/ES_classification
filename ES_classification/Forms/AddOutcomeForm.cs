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
    public partial class AddOutcomeForm : Form
    {
        private Form motherForm;
        private DBWorker dbWorker;

        public AddOutcomeForm(Form f, DBWorker dbWorker)
        {
            InitializeComponent();
            this.motherForm = f;
            this.dbWorker = dbWorker;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.motherForm.Enabled = true;
            this.Close();
        }

        private void AddOutcomeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.motherForm.Enabled = true;
        }

        private void btnAddOutcome_Click(object sender, EventArgs e)
        {
            string outcomeString = tbOutcomeField.Text;
            if (outcomeString == "")
            {
                MessageBox.Show("Текстовое поле пустое!");
                return;
            }
            try
            {
                dbWorker.addNewOutcome(outcomeString);
                MessageBox.Show("Вывод \"" + outcomeString + "\" успешно добавлен");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oшибка при добавлении вопроса! " + ex.Message.ToString());
            }
        }
    }
}
