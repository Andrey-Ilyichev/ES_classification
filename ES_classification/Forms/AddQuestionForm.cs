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
    public partial class AddQuestionForm : Form
    {
        private Form motherForm;
        private DBWorker dbWorker;

        public AddQuestionForm(Form f, DBWorker dbWorker)
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

        private void AddQuestionForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.motherForm.Enabled = true;
        }

        private void btnAddQuestion_Click(object sender, EventArgs e)
        {
            string questionString = tbQuestionField.Text;
            if ( questionString == "")
            {
                MessageBox.Show("Текстовое поле пустое!");
                return;
            }
            try
            {
                dbWorker.addNewQuestion(questionString);
                MessageBox.Show("Вопрос \"" + questionString + "\" успешно добавлен");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oшибка при добавлении вопроса! " + ex.Message.ToString());
            }
        }
    }
}
