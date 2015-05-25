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
        private bool isEditingMode;
        private int outcomeId;
        private string previousOutcomeString;

        public AddOutcomeForm(Form f, DBWorker dbWorker, bool isEditing, int outcomeId, string previousOutcomeName)
        {
            InitializeComponent();
            this.motherForm = f;
            this.dbWorker = dbWorker;

            isEditingMode = isEditing;
            this.outcomeId = outcomeId;

            if (isEditing == true)
            {
                btnAddOutcome.Text = "Изменить вывод";
                tbOutcomeField.Text = previousOutcomeName;
            }
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
                if (isEditingMode == false)
                    dbWorker.addNewOutcome(outcomeString);
                else
                    dbWorker.updateOutcome(outcomeId, outcomeString);
                MessageBox.Show("Изменения внесены успешно");
                //MessageBox.Show("Вывод \"" + outcomeString + "\" успешно добавлен");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oшибка операции! " + ex.Message.ToString());
            }
        }
    }
}
