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
    public partial class KBEditForm : Form
    {
        private Form motherForm;
        private DBWorker dbWorker;


        public KBEditForm(Form f, DBWorker dbWorker)
        {
            InitializeComponent();
            this.motherForm = f;
            this.dbWorker = dbWorker;

            refreshDGVquestion();
            refreshDGVoutcome();

            dgvQuestion.Columns[0].HeaderText = "#";
            dgvQuestion.Columns[0].Width = 25;
            //dgvQuestion.Columns[0].Visible = false;
            dgvQuestion.Columns[1].HeaderText = "Вопрос";
            dgvQuestion.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvQuestion.ReadOnly = true;

            dgvOutcome.Columns[0].HeaderText = "#";
            dgvOutcome.Columns[0].Width = 25;
            //dgvQuestion.Columns[0].Visible = false;
            dgvOutcome.Columns[1].HeaderText = "Вывод";
            dgvOutcome.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvOutcome.Columns[2].Visible = false;
            dgvOutcome.ReadOnly = true;
        }


        private void btnAddQuestion_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            AddQuestionForm aqf = new AddQuestionForm(this, this.dbWorker);
            aqf.Visible = true;
        }

        private void btnEndOfWork_Click(object sender, EventArgs e)
        {
            motherForm.Enabled = true;
            this.Close();
        }

        private void QuestionEditForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            motherForm.Enabled = true;
        }

        private void refreshDGVquestion()
        {
            this.dgvQuestion.DataSource = this.dbWorker.getDataTable(@"Question");
        }

        private void btnDeleteQuestion_Click(object sender, EventArgs e)
        {
            int selectedId = (int)dgvQuestion.SelectedRows[0].Cells[0].Value;
            string questionPhrase = (string)dgvQuestion.SelectedRows[0].Cells[1].Value;
            try
            {
                dbWorker.deleteQuestion(selectedId);
                refreshDGVquestion();
            }
            catch(Exception ex) {
                MessageBox.Show("Ошибка при удалении вопроса!\n" + ex.Message);
            }
            MessageBox.Show("Вопрос '" + questionPhrase + "' был успешно удален");
        }

        private void btnAddQuestion_EnabledChanged(object sender, EventArgs e)
        {
            refreshDGVquestion();
            refreshDGVoutcome();
        }

        private void refreshDGVoutcome()
        {
            this.dgvOutcome.DataSource = this.dbWorker.getDataTable(@"Outcome");
        }

        private void btnAddOutcome_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            AddOutcomeForm aof = new AddOutcomeForm(this, this.dbWorker);
            aof.Visible = true;
        }

        private void btnDeleteOutcome_Click(object sender, EventArgs e)
        {
            int selectedId = (int)dgvOutcome.SelectedRows[0].Cells[0].Value;
            string outcomePhrase = (string)dgvOutcome.SelectedRows[0].Cells[1].Value;

            try
            {
                dbWorker.deleteOutcome(selectedId);
                refreshDGVoutcome();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении вывода!\n" + ex.Message);
            }
            MessageBox.Show("Вывод '" + outcomePhrase + "' был успешно удален");
        }
    }

}
