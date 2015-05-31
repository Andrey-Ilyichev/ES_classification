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
        private int currentQuestionId = 0;
        //private Pair currentPair;
        private DBWorker dbWorker;
        private DataSet dSet;
        private DataTable dtProbList;

        private DataTable dtSession;

        public int getIdOfOutcome = -1;
        private int questionCountBeforeAnswer = 5;
        private int currentQuestionCount = 0;

        private bool isAutoMode = false;

        //private ArrayList session = new ArrayList();

        private void getDataSetAndResetDGVquestion()
        {
            dSet = dbWorker.getDataSet();

            dgvQuestion.DataSource = dSet.Tables["Question"];

            #region получить и установить таблицу вопросов
            dgvQuestion.Columns[0].HeaderText = "#";
            dgvQuestion.Columns[0].Width = 25;
            dgvQuestion.Columns[1].HeaderText = "Вопрос";
            dgvQuestion.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvQuestion.Columns[2].Visible = false;


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
            setStructureDtSession();
        }

        public MainForm()
        {
            InitializeComponent();
            this.dbWorker = new DBWorker();

            getDataSetAndResetDGVquestion();
            getProbListAndSetIntoDGV();
            setStructureDtSession();
        }

        private void setStructureDtSession()
        {
            dtSession = new DataTable();

            DataColumn questionId = new DataColumn("questionId", typeof(int));
            questionId.Caption = "id вопроса";

            DataColumn answerId = new DataColumn("answerId", typeof(int));
            answerId.Caption = "id ответа";

            DataColumn questionPhrase = new DataColumn("questionPhrase", typeof(string));
            questionPhrase.Caption = "Вопрос";

            DataColumn answer = new DataColumn("answerPhrase", typeof(string));
            answer.Caption = "Ответ";

            dtSession.Columns.AddRange(new DataColumn[] { questionId, answerId, questionPhrase, answer});

            dgvSession.DataSource = dtSession;
            for (int i = 0; i < dtSession.Columns.Count; i++)
            {
                dgvSession.Columns[i].HeaderText = dtSession.Columns[i].Caption;
            }


            dgvSession.Columns["questionId"].Visible = false;
            dgvSession.Columns["answerId"].Visible = false;
            dgvSession.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
            dgvProbList.Columns[3].HeaderText = "Априорная вероятность";
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
                getResult();


                //DataView dView = new DataView(dtProbList);
                //dView.Sort = "currentProbability DESC";
                //int idOfOutcomeFromDview = (int)dView[0][0];
                //string maxProbOutcomeFromDview = (string)dView[0][1];


                //object maxCurProbObj = dtProbList.Compute("Max(currentProbability)", "");
                //float maxProb = float.Parse(maxCurProbObj.ToString());

                ////string selectStr = "currentProbability = " + maxProb;
                ////DataRow[] foundRows = dtProbList.Select(selectStr);

                ////string maxProbEntity = foundRows[0][1].ToString();
                ////int idOfoutcome = (int)foundRows[0][0];

                //DialogResult result = MessageBox.Show(
                //    "Это - " + maxProbOutcomeFromDview +
                //    " c вероятностью " + maxProb +
                //    ". Правильно? ", "Вывод", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                //if (result == DialogResult.Yes)
                //{
                //    updateQuestionaryForOutcome(this.session, idOfOutcomeFromDview);
                //    updateCountClassificationForOutcomeInTableOutcome(idOfOutcomeFromDview);

                //    btn_stop_Click(null, null);
                //}
                //if (result == DialogResult.No)
                //{
                //    SelectOutcomeWindow sew = new SelectOutcomeWindow(this.dbWorker);
                //    sew.Owner = this;
                //    sew.ShowDialog();

                //    updateQuestionaryForOutcome(this.session, getIdOfOutcome);
                //    updateCountClassificationForOutcomeInTableOutcome(getIdOfOutcome);

                //    btn_stop_Click(null, null);
                //}


            }//есть ещё вопросы
            else
            {
                //currentPair.questionId = currentQuestionId;
               // int count = (int)dtSession.Compute("Count(questionId)", "questionId = " + currentQuestionId);
               // if (count != 0)
               //     askNextQuestion();
              //  else
                {
                    lbl_currentQuestion.Text = null;
                    lbl_currentQuestion.Text = dgvQuestion[1, currentQuestionId - 1].Value.ToString();
                }
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
               // int newQuestionId = getNextQuestionId();
            }

        }

        private int getNextQuestionId()
        {
            throw new NotImplementedException();
        }

        private void updateDtProbList()
        {

            int outcomeCount = dSet.Tables["Outcome"].Rows.Count;

            for (int j = 0; j < outcomeCount; j++)// все сущности
            {
                int jid = (int)dSet.Tables["Outcome"].Rows[j][0];

                string s = "outcomeId = " + jid;
                DataRow[] foundRows = dtProbList.Select("outcomeId = " + jid);
                if (foundRows.Length == 0)
                    MessageBox.Show("проблема в функции updateDtProbList - не нашли сущность по id");
                float apriorProb = (float)foundRows[0][3];

                float currentOutcomeProb = apriorProb;

                //for (int k = 0; k < session.Count; k++)//все элементы в сессии
                //
                for (int k = 0; k < dtSession.Rows.Count; k++)
                {
                    //Pair curPair = (Pair)session[k];

                    //int coloumnOfAnswer = getColoumnIdByAnswer(curPair.answer);
                    object obj = dtSession.Rows[k]["answerId"];
                    int coloumnOfAnswer = (int)obj;


                    float conProbAnswer = 0;

                    int curPairQuestionId = (int)dtSession.Rows[k]["questionId"];

                    //string selectStr = "outcomeId = " + jid + " AND " + " questionId = " + curPair.questionId;
                    string selectStr = "outcomeId = " + jid + " AND " + " questionId = " + curPairQuestionId;

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
                        dRow["outcomeId"] = jid;
                        dRow["questionId"] = curPairQuestionId;
                        dRow["yesCount"] = 1;
                        dRow["noCount"] = 1;
                        dRow["dontKnowCount"] = 1;
                        dRow["noMatterCount"] = 1;

                        dSet.Tables["Questionary"].Rows.Add(dRow);
                        dSet.AcceptChanges();

                        maxId++;

                        string selectStrAg = "outcomeId = " + jid + " AND " + " questionId = " + curPairQuestionId;
                        DataRow[] foundRowsQuestionaryAg = dSet.Tables["Questionary"].Select(selectStrAg);
                        if (foundRowsQuestionaryAg.Length == 0)
                        { MessageBox.Show("Problem in searching"); }

                        //string sql = "insert into Questionary (id, outcomeId, questionId, yesCount, noCount, dontKnowCount, noMatterCount) " +
                        //                                       " values ( " + maxId + " , " + jid + " , " + curPairQuestionId + ", 1, 1, 1, 1)";
                        //OleDbCommand command = new OleDbCommand(sql, dbWorker.connection);
                        //dbWorker.connection.Open();
                        //command.ExecuteNonQuery();
                        //dbWorker.connection.Close();
                        dbWorker.insertNewPositionInQuestionary(jid, curPairQuestionId, 1, 1, 1, 1);

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
                if (currentOutcomeProb < 0.000001)
                    currentOutcomeProb = 0;

                foundRows[0][2] = currentOutcomeProb;


            }


            object sumOfcurrentOutcomeProbObj = dtProbList.Compute("Sum(currentProbability)", "");
            float sumOfCurrentOutcomeProb = float.Parse(sumOfcurrentOutcomeProbObj.ToString());

            for (int j = 0; j < outcomeCount; j++)// все сущности
            {
                float curValOfConProb = (float)(dtProbList.Rows[j][2]);
                dtProbList.Rows[j][2] = curValOfConProb / sumOfCurrentOutcomeProb;
            }
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            btn_start.Enabled = false;
            isAutoMode = true;

            gbManualMode.Enabled = false;

            btn_stop.Enabled = true;
            btn_yes.Enabled = true;
            btn_no.Enabled = true;
            btn_dontKnow.Enabled = true;
            btn_noMatter.Enabled = true;

            btnClearSession.Enabled = false;

            askNextQuestion();
        }

        private void btn_yes_Click(object sender, EventArgs e)
        {
            //currentPair.questionId = currentQuestionId;
            //currentPair.answer = Answer.YES;
           //session.Add(currentPair);



            if (isAutoMode == true)
            {
                addRowToDtSession(currentQuestionId, lbl_currentQuestion.Text, Answer.YES);
                updateDtProbList();
                askNextQuestion();
            }
            else 
            {
                int questionId;
                string questionPhrase;
                getInformationAboutSelectedQuestion(out questionId, out questionPhrase);

                addRowToDtSession(questionId, questionPhrase, Answer.YES);
                updateDtProbList();
            }
        }

        private void btn_no_Click(object sender, EventArgs e)
        {
            //currentPair.questionId = currentQuestionId;
            //currentPair.answer = Answer.NO;
            //session.Add(currentPair);

            if (isAutoMode == true)
            {
                addRowToDtSession(currentQuestionId, lbl_currentQuestion.Text, Answer.NO);
                updateDtProbList();
                askNextQuestion();
            }
            else
            {
                int questionId;
                string questionPhrase;
                getInformationAboutSelectedQuestion(out questionId, out questionPhrase);

                addRowToDtSession(questionId, questionPhrase, Answer.NO);
                updateDtProbList();
            }
        }

        private void btn_dontKnow_Click(object sender, EventArgs e)
        {
            ////currentPair.questionId = currentQuestionId;
            ////currentPair.answer = Answer.DONTKNOW;
            ////session.Add(currentPair);

            //addRowToDtSession(currentQuestionId, lbl_currentQuestion.Text, Answer.DONTKNOW);
            //updateDtProbList();

            //if (isAutoMode == true)
            //    askNextQuestion();


            if (isAutoMode == true)
            {
                addRowToDtSession(currentQuestionId, lbl_currentQuestion.Text, Answer.DONTKNOW);
                updateDtProbList();
                askNextQuestion();
            }
            else
            {
                int questionId;
                string questionPhrase;
                getInformationAboutSelectedQuestion(out questionId, out questionPhrase);

                addRowToDtSession(questionId, questionPhrase, Answer.DONTKNOW);
                updateDtProbList();
            }
        }

        private void btn_noMatter_Click(object sender, EventArgs e)
        {
            ////currentPair.questionId = currentQuestionId;
            ////currentPair.answer = Answer.NOMATTER;
            ////session.Add(currentPair);

            //addRowToDtSession(currentQuestionId, lbl_currentQuestion.Text, Answer.NOMATTER);

            //updateDtProbList();
            //if (isAutoMode == true)
            //    askNextQuestion();

            if (isAutoMode == true)
            {
                addRowToDtSession(currentQuestionId, lbl_currentQuestion.Text, Answer.NOMATTER);
                updateDtProbList();
                askNextQuestion();
            }
            else
            {
                int questionId;
                string questionPhrase;
                getInformationAboutSelectedQuestion(out questionId, out questionPhrase);

                addRowToDtSession(questionId, questionPhrase, Answer.NOMATTER);
                updateDtProbList();
            }
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            dtSession.Clear();
            //session.Clear();
            currentQuestionId = 0;
            btn_start.Enabled = true;
            //gbManualMode.Enabled = true;
            isAutoMode = false;
            //btnClearSession.Enabled = true;

           btn_stop.Enabled = false;
          //  btn_yes.Enabled = false;
          //  btn_no.Enabled = false;
          //  btn_dontKnow.Enabled = false;
           // btn_noMatter.Enabled = false;


            getDataSetAndResetDGVquestion();
            getProbListAndSetIntoDGV();

            lbl_currentQuestion.Text = null;
        }

        private void updateQuestionaryForOutcome(int idOfOutcome)
        {
            //for (int i = 0; i < thisSession.Count; i++)
            //{
            for (int i = 0; i < dtSession.Rows.Count; i++)
			{
                //pair curPair = (pair)thisSession[i];
                //int coloumnId = getColoumnIdByAnswer(curPair.answer);
                int curPairQuestionId = (int)dtSession.Rows[i]["questionId"];
                int answerId = (int)dtSession.Rows[i]["answerId"];


                //я знаю outcomeId, questionId, answerColoumn
                //определяю id строки questionary и количество ответов текущего типа
                string selectStr = "outcomeId = " + idOfOutcome + " AND " + " questionId = " + curPairQuestionId;
                DataRow[] foundRowsQuestionary = dSet.Tables["Questionary"].Select(selectStr);

                if (foundRowsQuestionary.Length == 0)
                {
                    //string sql = "insert into Questionary (outcomeId, questionId, yesCount, noCount, dontKnowCount, noMatterCount) " +
                    //                         " values (" + idOfOutcome + " , " + curPairQuestionId + ", 1, 1, 1, 1)";
                    //OleDbCommand command1 = new OleDbCommand(sql, dbWorker.connection);
                    //dbWorker.connection.Open();
                    //command1.ExecuteNonQuery();
                    //dbWorker.connection.Close();
                    dbWorker.insertNewPositionInQuestionary(idOfOutcome, curPairQuestionId, 1, 1, 1, 1);
                    string answerColumnName = WorkerWithAnswer.getColoumnNameByAnswerId(answerId);
                    dbWorker.updatePositionInQuestinary(idOfOutcome, curPairQuestionId, answerColumnName);

                    //string answerColumnName = WorkerWithAnswer.getColoumnNameByAnswerId(answerId);
                    //string updateSql = "update Questionary set " + answerColumnName + " = " + (2) +
                    //    " where outcomeId = " + idOfOutcome + " AND questionId = " + curPairQuestionId;
                    //OleDbCommand command = new OleDbCommand(updateSql, dbWorker.connection);
                    //dbWorker.connection.Open();
                    //command.ExecuteNonQuery();
                    //dbWorker.connection.Close();


                    //////////////////////////////
                    ///////// сделать +1 сразу к нужному ответу!!!!
                    ////////////////////////////
                }
                else
                {

                    //foundRowsQuestionary = dSet.Tables["Questionary"].Select(selectStr);
                    int idInQuestionary = (int)foundRowsQuestionary[0][0];
                    int answerCount = (int)foundRowsQuestionary[0][answerId];
                    string answerColumnName = WorkerWithAnswer.getColoumnNameByAnswerId(answerId);
                    //выполняю обновление базы

                    dbWorker.updatePositionInQuestinary(idOfOutcome, curPairQuestionId, answerColumnName);



                    //string updateSql = "update Questionary set " + answerColumnName + " = " + (answerCount + 1) + " where id = " + idInQuestionary;
                    //OleDbCommand command = new OleDbCommand(updateSql, dbWorker.connection);
                    //dbWorker.connection.Open();
                    //command.ExecuteNonQuery();
                    //dbWorker.connection.Close();
                }
            }

            MessageBox.Show("Результат учтен");
        }

        private void updateCountClassificationForOutcomeInTableOutcome(int idOfOutcome)
        {
            //string selectStr = "id = " + idOfOutcome;
            //DataRow[] foundRowsOutcome = dSet.Tables["Outcome"].Select(selectStr);

            //int oldCountClassification = (int)foundRowsOutcome[0]["countClassification"];

            //string updateSql = "update Outcome set countClassification = " + (oldCountClassification + 1) + " where id = " + idOfOutcome;
            //OleDbCommand command = new OleDbCommand(updateSql, dbWorker.connection);
            //dbWorker.connection.Open();
            //command.ExecuteNonQuery();
            //dbWorker.connection.Close();

            dbWorker.updateCountClassificationForOutcome(idOfOutcome);
        }

        private void btnGoToKBEditForm_Click(object sender, EventArgs e)
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

        private void probabilitiesOfAnswers(ref float yesProbability, int questionId)
        {
            DataTable dtProbOfAnswers = dbWorker.getDTprobOfAnswersByQuestion(questionId);
            for (int i = 0; i < dtProbList.Rows.Count; i++)
            {
                //float yesProbOfOutcomeI = 


                //yesProbability += yesProbOfOutcomeI;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int questionId = 1;

            DataTable dtProbOfAnswers = dbWorker.getDTprobOfAnswersByQuestion(questionId);

            float probYesByQuestionId = 0;
            float probNoByQuestionId = 0;
            float probDontKnowByQuestionId = 0;
            float probNoMatterByQuestionId = 0;

            for (int i = 0; i < dtProbList.Rows.Count; i++)
            {
                int curOutcomeId = (int)dtProbList.Rows[i][0];

                DataRow[] drArray;
                drArray = dtProbOfAnswers.Select("outcomeId = '" + curOutcomeId + "'");

                float probOutcome = (float)dtProbList.Rows[i][3];

                float probYesByQuestionIdByOutcomeId = (float)drArray[0][1];
                probYesByQuestionId += probYesByQuestionIdByOutcomeId * probOutcome;

                float probNoByQuestionIdByOutcomeId = (float)drArray[0][2];
                probNoByQuestionId += probNoByQuestionIdByOutcomeId * probOutcome;

                float probDontKnowByQuestionIdByOutcomeId = (float)drArray[0][3];
                probDontKnowByQuestionId += probDontKnowByQuestionIdByOutcomeId * probOutcome;

                float probNoMatterByQuestionIdByOutcomeId = (float)drArray[0][4];
                probNoMatterByQuestionId += probNoMatterByQuestionIdByOutcomeId * probOutcome;
            }
        }

        private void btnSelectQuestion_Click(object sender, EventArgs e)
        {
            //pair p = new pair();
            int questionId = System.Convert.ToInt32(dgvQuestion.SelectedRows[0].Cells[0].Value);
            Answer answer = Answer.YES;
            //ООООООООООООООООООООООООООООПААААААААААААСНООООООООООООООООООООООООООО
            int c = (int)dtSession.Compute("Count (questionId)", "questionId = " + questionId);
            if (c != 0)
            {
                MessageBox.Show("На этот вопрос ответ уже был выбран!");
                return;
            }

            string questionPhrase = dgvQuestion.SelectedRows[0].Cells[1].Value.ToString();

            if (rbYes.Checked)
                answer = Answer.YES;
            if (rbNo.Checked)
                answer = Answer.NO;
            if (rbDontKnow.Checked)
                answer = Answer.DONTKNOW;
            if (rbNoMatter.Checked)
                answer = Answer.NOMATTER;

            //DataRow dr = dtSession.NewRow();
            //dr[0] = p.questionId;
            //dr[1] = questionPhrase;
            //dr[2] = getTranslateOfAnswer(p.answer);

            //dtSession.Rows.Add(dr);
            //addRowToDtSession(p, questionPhrase);
            addRowToDtSession(questionId, questionPhrase, answer);
            //session.Add(p);

            updateDtProbList();
        }

        //private void addRowToDtSession(Pair p, string questionPhrase)
        //{
        //    DataRow dr = dtSession.NewRow();
        //    dr["questionId"] = p.questionId;
        //    dr["questionPhrase"] = questionPhrase;
        //    dr["answerPhrase"] = WorkerWithAnswer.getTranslateOfAnswer(p.answer);
        //    dr["answerId"] = (int)p.answer + 1;

        //    dtSession.Rows.Add(dr);
        //}

        private void addRowToDtSession(int questionId, string questionPhrase, Answer ans)
        {
            //int c = (int)dtSession.Compute("Count (questionId)", "questionId = " + questionId);

            DataRow[] rowWithCurrentQuestionId = dtSession.Select("questionId = " + questionId);
            if (rowWithCurrentQuestionId.Length != 0)
            {
                DialogResult dialogResult = MessageBox.Show("На этот вопрос ответ уже был выбран! Изменить ответ на новый?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    rowWithCurrentQuestionId[0].Delete();

                    DataRow dr = dtSession.NewRow();
                    dr["questionId"] = questionId;
                    dr["questionPhrase"] = questionPhrase;
                    dr["answerPhrase"] = WorkerWithAnswer.getTranslateOfAnswer(ans);
                    dr["answerId"] = WorkerWithAnswer.getColoumnIdByAnswer(ans);

                    dtSession.Rows.Add(dr);
                }
                else
                {
                    return;
                }
                //MessageBox.Show("На этот вопрос ответ уже был выбран! Изменить ответ на новый?");
                //return;
            }
            else
            {
                DataRow dr2 = dtSession.NewRow();
                dr2["questionId"] = questionId;
                dr2["questionPhrase"] = questionPhrase;
                dr2["answerPhrase"] = WorkerWithAnswer.getTranslateOfAnswer(ans);
                dr2["answerId"] = WorkerWithAnswer.getColoumnIdByAnswer(ans);

                dtSession.Rows.Add(dr2);
            }

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        //private void cbManualMode_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (cbManualMode.Checked == true)
        //    {
        //        //gbAutoMode.Enabled = false;
        //        gbManualMode.Enabled = true;
        //    }
        //    else
        //    {
        //        gbAutoMode.Enabled = true;
        //        gbManualMode.Enabled = false;
        //    }
        //    //session.Clear();
        //    dtSession.Clear();
        //}

        private void getResult()
        {
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

            string resultString = "Это - " + maxProbOutcomeFromDview.TrimEnd(new char[] { ' ' }) + " c вероятностью " + maxProb;

            if (chkBoxTrainingMode.Checked == true)
            {

                DialogResult result = MessageBox.Show(
                    "Это - " + maxProbOutcomeFromDview.TrimEnd(new char[] { ' ' }) +
                    " c вероятностью " + maxProb +
                    ". Правильно? ", "Вывод", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    updateQuestionaryForOutcome(idOfOutcomeFromDview);
                    updateCountClassificationForOutcomeInTableOutcome(idOfOutcomeFromDview);

                    btn_stop_Click(null, null);
                }
                if (result == DialogResult.No)
                {
                    SelectOutcomeWindow sew = new SelectOutcomeWindow(this.dbWorker);
                    sew.Owner = this;
                    sew.ShowDialog();

                    updateQuestionaryForOutcome(getIdOfOutcome);
                    updateCountClassificationForOutcomeInTableOutcome(getIdOfOutcome);

                    btn_stop_Click(null, null);
                }
            }
            else
            {
                DialogResult res = MessageBox.Show(resultString, "Вывод:", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                btn_stop_Click(null, null);
            }
        }

        private void btnGetResult_Click(object sender, EventArgs e)
        {
            getResult();
        }

        private void btnClearSession_Click(object sender, EventArgs e)
        {
            //session.Clear();
            dtSession.Clear();
            updateDtProbList();
        }

        private void btnDeleteQuestion_Click(object sender, EventArgs e)
        {
            if (dgvSession.SelectedRows[0] == null)
                return;
            int questionId = (int)dgvSession.SelectedRows[0].Cells[0].Value;

            dtSession.Select("questionId = " + questionId)[0].Delete();
            //throw new Exception();

           // int index = getIndexInSessionPairWithQuestionId(questionId);

          //  if (index != -1)
          //      session.RemoveAt(index);
          //  else
          //      throw new Exception();

            updateDtProbList();
        }

        //private int getIndexInSessionPairWithQuestionId(int questionId)
        //{
        //    int result;
        //    pair p = new pair();
        //    p.questionId = questionId;

        //    p.answer = Answer.YES;
        //    result = session.IndexOf(p);
        //    if (result != -1)
        //        return result;

        //    p.answer = Answer.NO;
        //    result = session.IndexOf(p);
        //    if (result != -1)
        //        return result;


        //    p.answer = Answer.NOMATTER;
        //    result = session.IndexOf(p);
        //    if (result != -1)
        //        return result;

        //    p.answer = Answer.DONTKNOW;
        //    result = session.IndexOf(p);
        //    if (result != -1)
        //        return result;

        //    return result;
        //}

        private void btnGoToProductionES_Click(object sender, EventArgs e)
        {
            startForm sf = new startForm(dtSession, this.dbWorker);
            sf.ShowDialog();
        }

        private void getInformationAboutSelectedQuestion(out int questionId, out string questionPhrase)
        {
            questionId = System.Convert.ToInt32(dgvQuestion.SelectedRows[0].Cells[0].Value);
            questionPhrase = dgvQuestion.SelectedRows[0].Cells[1].Value.ToString();
        }

    }

}

//TODO: 
// done 1) сделать возможность запуска автоматического выбора вопросов после ручного прохода
// done 2) сделать сессию полноценным dataTable??? 
// done 3) убрать sql-запросы c форм в dbWorker
// 4) сделать mvp версию
// 5) сменить checkBox на кнопки и изменить обработчики кликов на ответы
// 6) синхронизация бз
// 7) хранение 2бд в одной бз
// 8) возвращение промежуточных результатов из работы продукционной системы