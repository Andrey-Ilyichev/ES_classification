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
        private bool isEditingMode;
        private int questionId;
       // private int previousQuestionString;
        private ServiceReferenceForExpertSystem.WebServiceForExpertSystemSoapClient webClient;

        private DataTable dtFunctionalArea;

        public AddQuestionForm(Form f, DBWorker dbWorker, bool isEditingMode, int questionId, string previousQuestionString, ServiceReferenceForExpertSystem.WebServiceForExpertSystemSoapClient wClient)
        {
            InitializeComponent();
            this.motherForm = f;
            this.dbWorker = dbWorker;
            this.webClient = wClient;

            this.isEditingMode = isEditingMode;
            this.questionId = questionId;

            if (isEditingMode == true)
            {
                btnAddQuestion.Text = "Изменить вопрос";
                tbQuestionField.Text = previousQuestionString;
 
            }

            updateCmbFunctionalArea();
        }

        private void updateCmbFunctionalArea()
        {            
            dtFunctionalArea = dbWorker.getDataTable("FunctionalArea");
            cmbFunctionalArea.DataSource = dtFunctionalArea;
            cmbFunctionalArea.DisplayMember = "areaName";
            cmbFunctionalArea.ValueMember = "id";

            if (dtFunctionalArea.Rows.Count == 0)
            {
                dbWorker.addNewFunctionalArea("---");
                updateCmbFunctionalArea();
            }
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
            int functionalAreaId = (int)cmbFunctionalArea.SelectedValue;

            if ( questionString == "")
            {
                MessageBox.Show("Текстовое поле пустое!");
                return;
            }
            try
            {
                if (isEditingMode == false)
                {
                    string result = webClient.dbwAddNewQuestion(questionString, functionalAreaId);
                    //dbWorker.addNewQuestion(questionString, functionalAreaId);
                    MessageBox.Show(result);
                    //MessageBox.Show("Вопрос \"" + questionString + "\" успешно добавлен");
                }
                else 
                {
                    dbWorker.updateQuestion(questionId, functionalAreaId, questionString);
                    MessageBox.Show("Вопрос \"" + questionString + "\" успешно изменен");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка операции! " + ex.Message.ToString());
            }
        }

        private void btnAddFunctionalArea_Click(object sender, EventArgs e)
        {
            AddFunctionalAreaForm afar = new AddFunctionalAreaForm(this.dbWorker);
            this.Enabled = false;

            afar.ShowDialog();
            this.Enabled = true;
            this.updateCmbFunctionalArea();

            cmbFunctionalArea.SelectedIndex = dtFunctionalArea.Rows.Count - 1;
        }

    }
}
