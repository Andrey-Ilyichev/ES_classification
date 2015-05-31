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
        DataTable dtQuestions;
        DataTable dtOutcome;

        /// <summary>
        /// //////////////////////////////////////////////////////
        /// </summary>
        int nullId = 3;
        /// <summary>
        /// //////////////////////////////////////////////////////

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
            dgvQuestion.Columns[2].Visible = false;

            dgvOutcome.Columns[0].HeaderText = "#";
            dgvOutcome.Columns[0].Width = 25;
            //dgvQuestion.Columns[0].Visible = false;
            dgvOutcome.Columns[1].HeaderText = "Вывод";
            dgvOutcome.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvOutcome.Columns[2].Visible = false;
            dgvOutcome.ReadOnly = true;

            updateCmbFunctionalArea();

            chbAllQuestions_CheckedChanged(null, null);
        }

        private void updateCmbFunctionalArea()
        {
            cmbFunctionalArea.DataSource = dbWorker.getDataTable("FunctionalArea");
            cmbFunctionalArea.DisplayMember = "areaName";
            cmbFunctionalArea.ValueMember = "id";
        }


        private void btnAddQuestion_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            AddQuestionForm aqf = new AddQuestionForm(this, this.dbWorker, false, 0, null);// new AddQuestionForm(this, this.dbWorker);
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

        private void btnDeleteQuestion_Click(object sender, EventArgs e)
        {
            int selectedId = (int)dgvQuestion.SelectedRows[0].Cells[0].Value;

            string questionPhrase = (string)dgvQuestion.SelectedRows[0].Cells[1].Value;
            //try
            //{
            //    dbWorker.deleteQuestion(selectedId);
            //    refreshDGVquestion();
            //}
            //catch(Exception ex) {
            //    MessageBox.Show("Ошибка при удалении вопроса!\n" + ex.Message);
            //}
            //MessageBox.Show("Вопрос '" + questionPhrase + "' был успешно удален");


            this.Enabled = false;
            AddQuestionForm aof = new AddQuestionForm(this, this.dbWorker, true, selectedId, questionPhrase);
            aof.ShowDialog();
        }

        private void btnAddQuestion_EnabledChanged(object sender, EventArgs e)
        {
            refreshDGVquestion();
            refreshDGVoutcome();
        }

        private void refreshDGVoutcome()
        {
            dtOutcome = this.dbWorker.getDataTable(@"Outcome");
            this.dgvOutcome.DataSource = dtOutcome;
        }

        private void refreshDGVquestion()
        {
            dtQuestions = this.dbWorker.getDataTable(@"Question");
            this.dgvQuestion.DataSource = dtQuestions;
        }

        private void btnAddOutcome_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            AddOutcomeForm aof = new AddOutcomeForm(this, this.dbWorker, false, -1, null);
            aof.Visible = true;
        }

        private void btnDeleteOutcome_Click(object sender, EventArgs e)
        {
            int selectedId = (int)dgvOutcome.SelectedRows[0].Cells[0].Value;
            string outcomePhrase = (string)dgvOutcome.SelectedRows[0].Cells[1].Value;

            //try
            //{
            //    dbWorker.deleteOutcome(selectedId);
            //    MessageBox.Show("Вывод '" + outcomePhrase + "' был успешно удален");
            //    refreshDGVoutcome();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Ошибка при удалении вывода!\n" + ex.Message);
            //    throw new Exception("!!!", ex);
            //}
            this.Enabled = false;
            AddOutcomeForm aof = new AddOutcomeForm(this, this.dbWorker, true, selectedId, outcomePhrase);
            aof.ShowDialog();
        }

        private void chbAllQuestions_CheckedChanged(object sender, EventArgs e)
        {

            if (chbAllQuestions.Checked == true)
            {
                cmbFunctionalArea.Enabled = false;
                refreshDGVquestion();
            }
            else
            {
                cmbFunctionalArea.Enabled = true;
                int faId = (int)cmbFunctionalArea.SelectedValue;
                if (faId == nullId)
                    dgvQuestion.DataSource = new DataView(dtQuestions, "functionalAreaId IS NULL", "", DataViewRowState.CurrentRows);

                       // dtQuestions.Select("functionalAreaId IS NULL");
                else
                    dgvQuestion.DataSource = new DataView(dtQuestions, "functionalAreaId = " + faId, "", DataViewRowState.CurrentRows);
                        //dtQuestions.Select(string.Format("functionalAreaId = {0}", faId));
            }
        }

        private void cmbFunctionalArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            chbAllQuestions_CheckedChanged(null, null);
        }

        private void dgvQuestion_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvQuestion.SelectedRows.Count != 0)
            {
                tbQuestion.Text = dgvQuestion.SelectedRows[0].Cells[1].Value.ToString();
                btnInsertStatistic.Enabled = true;
                updateTbYesAnswerProcent();
            }
            else
            {
                tbQuestion.Text = "Не выбран вопрос!";
                btnInsertStatistic.Enabled = false;
            }
        }

        private void dgvOutcome_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOutcome.SelectedRows.Count != 0)
            {
                tbOutcome.Text = dgvOutcome.SelectedRows[0].Cells[1].Value.ToString();
                btnInsertStatistic.Enabled = true;
                updateTbYesAnswerProcent();
            }
            else
            {
                tbOutcome.Text = "Не выбран вывод!";
                btnInsertStatistic.Enabled = false;
            }
        }

        private void btnInsertStatistic_Click(object sender, EventArgs e)
        {
            int questionId = (int)dgvQuestion.SelectedRows[0].Cells[0].Value;
            int outcomeId = (int)dgvOutcome.SelectedRows[0].Cells[0].Value;
            int yesProcent = System.Convert.ToInt32(tbYesAnswerProcent.Text);
            int result = dbWorker.updateStatistic(outcomeId, questionId, yesProcent);

            if (result == 1)
                MessageBox.Show("Статистика учтена успешно");
        }

        private void updateTbYesAnswerProcent()
        {
            if ((dgvOutcome.SelectedRows.Count != 0) && (dgvQuestion.SelectedRows.Count != 0))
            {
                int questionId = (int)dgvQuestion.SelectedRows[0].Cells[0].Value;
                int outcomeId = (int)dgvOutcome.SelectedRows[0].Cells[0].Value;
                DataRow dr = dbWorker.getStatisticOfAnswers(outcomeId, questionId);
                if (dr == null)
                    tbYesAnswerProcent.Text = "25";
                else
                {
                    int sum = 0;
                    for (int i = 3; i < dr.Table.Columns.Count; i++)
                    {
                        sum += (int)dr[i];
                    }
                    //int procent = (int)((float)dr[3] * 100 / sum);
                        int intYesCount = (int)dr[3];
                        float fYesCount = (float)intYesCount;
                        fYesCount /= sum;
                        fYesCount *= 100;

                        int procent = (int)fYesCount;


                        tbYesAnswerProcent.Text = procent.ToString();
                }
            }
            else
                tbYesAnswerProcent.Text = "--";
        }


    }

}
