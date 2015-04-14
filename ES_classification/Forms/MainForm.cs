using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.OleDb;

namespace ES_classification
{

    public partial class MainForm : Form
    {    
        private enum Answer{YES, NO, DONTKNOW, NOMATTER}

        private int currentQuestionId = 0;
        private pair currentPair;
        private DBWorker dbWorker;
        private DataSet dSet;
        private DataTable dtProbList;

        public int getIdOfOutcome = -1;
        private int questionCountBeforeAnswer = 5;
        private int currentQuestionCount = 0;

        private struct pair 
        {
            public int questionId;
            public Answer answer;
        }

        private ArrayList session = new ArrayList();

        private void getDataSetAndResetDGVquestion()
        {
             dSet = dbWorker.getDataSet();

            dgvQuestion.DataSource = dSet.Tables["Question"];

            #region получить и установить таблицу вопросов
                dgvQuestion.Columns[0].HeaderText = "#";
                dgvQuestion.Columns[0].Width = 25;
                dgvQuestion.Columns[1].HeaderText = "Вопрос";
                dgvQuestion.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


                if (dSet.Tables["Question"].Rows.Count == 0)
                {
                    MessageBox.Show("База знаний пуста(отсутствуют вопросы). Рекомендуется перейти к редактированию Базы Знаний");
                    btn_start.Enabled = false;
                }
                
            #endregion
        }

        public MainForm(DBWorker dbWorker)
        {
            InitializeComponent();
            this.dbWorker = dbWorker;

            refreshAllData();
        }

        public MainForm()
        {
            InitializeComponent();
            this.dbWorker = new DBWorker();

            getDataSetAndResetDGVquestion();
            getProbListAndSetIntoDGV();
        }

        private void getProbListAndSetIntoDGV()
        {
            #region получить и установить вероятностный список
            dtProbList = new DataTable("ProbabilityList");

            DataColumn outcomeId = new DataColumn("outcomeId", typeof(int));
            outcomeId.Caption = "id сущности";

            DataColumn outcomeName = new DataColumn("outcomeName", typeof(string));
            outcomeName.Caption = "Имя сущности";

            DataColumn currentProbability = new DataColumn("currentProbability", typeof(float));
            currentProbability.Caption = "Текущая вероятность";

            DataColumn сommonProbability = new DataColumn("сommonProbability", typeof(float));
            сommonProbability.Caption = "Априорная вероятность";

            dtProbList.Columns.AddRange(new DataColumn[] { outcomeId, outcomeName, currentProbability, сommonProbability });

            dgvProbList.DataSource = dtProbList;

            dgvProbList.Columns[0].HeaderText = "#";
            dgvProbList.Columns[0].Width = 25;
            dgvProbList.Columns[1].HeaderText = "Вывод";
            dgvProbList.Columns[2].HeaderText = "Текущая вероятность";

            DataTableReader dtEReader = dSet.Tables["Outcome"].CreateDataReader();

            if (dtEReader.HasRows == false)
            {
                MessageBox.Show("База знаний пуста(отсутствуют выводы). Рекомендуется перейти к редактированию Базы Знаний");
                btn_start.Enabled = false;
            }
            else
            {


                object o = dSet.Tables["Outcome"].Compute("Sum(countClassification)", "");
                int countClassification = Int32.Parse(o.ToString());
                while (dtEReader.Read())
                {
                    DataRow dRow = dtProbList.NewRow();
                    dRow[0] = dtEReader.GetInt32(0);//OutcomeId
                    dRow[1] = dtEReader.GetString(1);//OutcomeName
                    dRow[2] = (float)dtEReader.GetInt32(2) / countClassification; ;//curProb
                    dRow[3] = (float)dtEReader.GetInt32(2) / countClassification;//commonProb

                    dtProbList.Rows.Add(dRow);
                }
                dtEReader = null;
            }
            #endregion
        }

        private void askNextQuestion()//line order of questions
        {
            currentQuestionId++;
            //если вопросы закончились
            if (currentQuestionId > dgvQuestion.RowCount)
            {
                MessageBox.Show("Вопросы закончились");

                DataView dView = new DataView(dtProbList);
                dView.Sort = "currentProbability DESC";
                int idOfOutcomeFromDview = (int)dView[0][0];
                string maxProbOutcomeFromDview = (string)dView[0][1];


                object maxCurProbObj = dtProbList.Compute("Max(currentProbability)", "");
                float maxProb = float.Parse(maxCurProbObj.ToString());

                //string selectStr = "currentProbability = " + maxProb;
                //DataRow[] foundRows = dtProbList.Select(selectStr);

                //string maxProbEntity = foundRows[0][1].ToString();
                //int idOfoutcome = (int)foundRows[0][0];

                DialogResult result = MessageBox.Show(
                    "Это - " + maxProbOutcomeFromDview + 
                    " c вероятностью " + maxProb + 
                    ". Правильно? ", "Вывод", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    updateQuestionaryForOutcome(this.session, idOfOutcomeFromDview);
                    updateCountClassificationForOutcomeInTableOutcome(idOfOutcomeFromDview);

                    btn_stop_Click(null, null);
                }
                if (result == DialogResult.No)
                {
                    SelectOutcomeWindow sew = new SelectOutcomeWindow(this.dbWorker);
                    sew.Owner = this;
                    sew.ShowDialog();

                    updateQuestionaryForOutcome(this.session, getIdOfOutcome);
                    updateCountClassificationForOutcomeInTableOutcome(getIdOfOutcome);

                    btn_stop_Click(null, null);
                }
            }//есть ещё вопросы
            else
            {
                currentPair.questionId = currentQuestionId;

                lbl_currentQuestion.Text = null;
                lbl_currentQuestion.Text = dgvQuestion[1, currentQuestionId - 1].Value.ToString();
            }
        }

        private void askNextQuestion2()//new order
        {
            currentQuestionCount++;

            if (currentQuestionCount > questionCountBeforeAnswer)
            {
                throw new Exception("надо выдать гипотезу!");
            }
            else
            {
                throw new Exception("задать следующий вопрос!");
                int newQuestionId = getNextQuestionId();
            }
 
        }

        private void updateDtProbList()
        {

            int outcomeCount = dSet.Tables["Outcome"].Rows.Count;

            for (int j = 1; j <= outcomeCount; j++)// все сущности
            {
                string s = "outcomeId = " + j;
                DataRow[] foundRows = dtProbList.Select("outcomeId = " + j);
                if (foundRows.Length == 0)
                    MessageBox.Show("проблема в функции updateDtProbList - не нашли сущность по id");
                float apriorProb = (float)foundRows[0][3];

                float currentOutcomeProb = apriorProb;

                for (int k = 0; k < session.Count; k++)//все элементы в сессии
                {
                    pair curPair = (pair)session[k];
                    int coloumnOfAnswer = getColoumnIdByAnswer(curPair.answer);


                    float conProbAnswer = 0;


                    string selectStr = "outcomeId = " + j + " AND " + " questionId = " + curPair.questionId;
                    DataRow[] foundRowsQuestionary = dSet.Tables["Questionary"].Select(selectStr);
                    if (foundRowsQuestionary.Length == 0)
                    {
                        int maxId;

                        string selectAll = "";
                        DataRow[] foundRowsAll = dSet.Tables["Questionary"].Select(selectAll);
                        if (foundRowsAll.Length == 0)
                            maxId = 0;
                        else
                        {

                            object maxIdObj = dSet.Tables["Questionary"].Compute("Max(id)", "");
                            maxId = int.Parse(maxIdObj.ToString());
                        }

                        DataRow dRow = dSet.Tables["Questionary"].NewRow();

                        dRow["id"] = maxId + 1;
                        dRow["outcomeId"] = j;
                        dRow["questionId"] = curPair.questionId;
                        dRow["yesCount"] = 1;
                        dRow["noCount"] = 1;
                        dRow["dontKnowCount"] = 1;
                        dRow["noMatterCount"] = 1;

                        dSet.Tables["Questionary"].Rows.Add(dRow);
                        dSet.AcceptChanges();

                        maxId++;

                                            string selectStrAg = "outcomeId = " + j + " AND " + " questionId = " + curPair.questionId;
                                             DataRow[] foundRowsQuestionaryAg = dSet.Tables["Questionary"].Select(selectStrAg);
                                             if (foundRowsQuestionaryAg.Length == 0)
                                             { MessageBox.Show("Problem in searching"); }

                                             string sql = "insert into Questionary (id, outcomeId, questionId, yesCount, noCount, dontKnowCount, noMatterCount) " + 
                                                                                    " values ( " + maxId + " , " + j + " , " + curPair.questionId + ", 1, 1, 1, 1)";
                                            OleDbCommand command = new OleDbCommand(sql, dbWorker.connection);
                                            dbWorker.connection.Open();
                                            command.ExecuteNonQuery();
                                            dbWorker.connection.Close();

                        conProbAnswer = 1.0f / 4.0f;
                    }
                    else
                    {
                        int countCallofQuestionForThisOutcome = (int)foundRowsQuestionary[0][3] +
                                                                (int)foundRowsQuestionary[0][4] +
                                                                (int)foundRowsQuestionary[0][5] +
                                                                (int)foundRowsQuestionary[0][6];



                        if (countCallofQuestionForThisOutcome != 0)
                        {
                            int countOfAnswer = (int)foundRowsQuestionary[0][coloumnOfAnswer];
                            conProbAnswer = (float)(countOfAnswer) / countCallofQuestionForThisOutcome;
                        }
                        else
                            conProbAnswer = (float)(1 / 4);
                    }
                    currentOutcomeProb *= conProbAnswer;
                }
                foundRows[0][2] = currentOutcomeProb;


            }


            object sumOfcurrentOutcomeProbObj = dtProbList.Compute("Sum(currentProbability)","");
            float sumOfCurrentOutcomeProb = float.Parse(sumOfcurrentOutcomeProbObj.ToString());

            for (int j = 0; j < outcomeCount; j++)// все сущности
            {
                float curValOfConProb = (float)(dtProbList.Rows[j][2]);
                dtProbList.Rows[j][2] = curValOfConProb/sumOfCurrentOutcomeProb;
            }
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            btn_start.Enabled = false;

            btn_stop.Enabled = true;
            btn_yes.Enabled = true;
            btn_no.Enabled = true;
            btn_dontKnow.Enabled = true;
            btn_noMatter.Enabled = true;

            askNextQuestion();
        }

        private void btn_yes_Click(object sender, EventArgs e)
        {
            currentPair.questionId = currentQuestionId;
            currentPair.answer = Answer.YES;
            session.Add(currentPair);

            updateDtProbList();
            askNextQuestion();
        }

        private void btn_no_Click(object sender, EventArgs e)
        {
            currentPair.questionId = currentQuestionId;
            currentPair.answer = Answer.NO;
            session.Add(currentPair);

            updateDtProbList();
            askNextQuestion();
        }        
        
        private void btn_dontKnow_Click(object sender, EventArgs e)
        {
            currentPair.questionId = currentQuestionId;
            currentPair.answer = Answer.DONTKNOW;
            session.Add(currentPair);

            updateDtProbList();
            askNextQuestion();
        }

        private void btn_noMatter_Click(object sender, EventArgs e)
        {
            currentPair.questionId = currentQuestionId;
            currentPair.answer = Answer.NOMATTER;
            session.Add(currentPair);

            updateDtProbList();
            askNextQuestion();
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            session.Clear();
            currentQuestionId = 0;
            btn_start.Enabled = true;

            btn_stop.Enabled = false;
            btn_yes.Enabled = false;
            btn_no.Enabled = false;
            btn_dontKnow.Enabled = false;
            btn_noMatter.Enabled = false;


            getDataSetAndResetDGVquestion();
            getProbListAndSetIntoDGV();

            lbl_currentQuestion.Text = null;
        }

        private void updateQuestionaryForOutcome(ArrayList thisSession, int idOfOutcome)
        {
            for (int i = 0; i < thisSession.Count; i++)
            {
                pair curPair = (pair)thisSession[i];
                int coloumnId = getColoumnIdByAnswer(curPair.answer);
                //я знаю outcomeId, questionId, answerColoumn
                //определяю id строки questionary и количество ответов текущего типа
                string selectStr = "outcomeId = " + idOfOutcome + " AND " + " questionId = " + curPair.questionId;
                DataRow[] foundRowsQuestionary = dSet.Tables["Questionary"].Select(selectStr);
                int idInQuestionary = (int)foundRowsQuestionary[0][0];
                int answerCount = (int)foundRowsQuestionary[0][coloumnId];
                //выполняю обновление базы
                string updateSql = "update Questionary set " + getColoumnNameByAnswer(curPair.answer) + " = " + (answerCount + 1) + " where id = " + idInQuestionary;
                OleDbCommand command = new OleDbCommand(updateSql, dbWorker.connection);
                dbWorker.connection.Open();
                command.ExecuteNonQuery();
                dbWorker.connection.Close();
            }

            MessageBox.Show("Результат учтен");
        }

        private int getColoumnIdByAnswer(Answer ans) 
        {
            int result = 0;
            switch (ans)
            {
                case Answer.YES:
                    result = 3;
                    break;
                case Answer.NO:
                    result = 4;
                    break;
                case Answer.DONTKNOW:
                    result = 5;
                    break;
                case Answer.NOMATTER:
                    result = 6;
                    break;
                default:
                    result = 0;
                    break;
            }
            if (result == 0)
                MessageBox.Show("Ошибка в private int getColoumnIdByAnswer(Answer ans) ");
            return result;
        }

        private string getColoumnNameByAnswer(Answer ans)
        {
            string result = null;
            switch (ans)
            {
                case Answer.YES:
                    result = "yesCount";
                    break;
                case Answer.NO:
                    result = "noCount";
                    break;
                case Answer.DONTKNOW:
                    result = "dontKnowCount";
                    break;
                case Answer.NOMATTER:
                    result = "noMatterCount";
                    break;
                default:
                    result = null;
                    break;
            }
            if (result == null)
                MessageBox.Show("Ошибка в private string getColoumnNameByAnswer(Answer ans)");
            return result;
        }

        private void updateCountClassificationForOutcomeInTableOutcome(int idOfOutcome)
        {
            string selectStr = "idOutcome = " + idOfOutcome;
            DataRow[] foundRowsOutcome = dSet.Tables["Outcome"].Select(selectStr);

            int oldCountClassification = (int)foundRowsOutcome[0]["countClassification"];

            string updateSql = "update Outcome set countClassification = " + (oldCountClassification + 1) + " where idOutcome = " + idOfOutcome;
            OleDbCommand command = new OleDbCommand(updateSql, dbWorker.connection);
            dbWorker.connection.Open();
            command.ExecuteNonQuery();
            dbWorker.connection.Close();
        }

        private void btnAddQuestion_Click(object sender, EventArgs e)
        {
            KBEditForm qef = new KBEditForm(this, dbWorker);
            qef.Visible = true;
            this.Enabled = false;
        }

        private void MainForm_EnabledChanged(object sender, EventArgs e)
        {
            if (this.Enabled == true)
            {
                refreshAllData();
                btn_start.Enabled = true;
            }
        }

        private void refreshAllData() 
        {
            getDataSetAndResetDGVquestion();
            getProbListAndSetIntoDGV();
        }
    }

}
