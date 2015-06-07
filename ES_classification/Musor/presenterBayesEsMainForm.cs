//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Data;
//using System.Windows.Forms;

//namespace ES_classification
//{
//    class presenterBayesEsMainForm
//    {
//        private DBWorker dbWorker;
//        private DataSet dSet;
//        //private DataTable dtProbList;
//        //private DataTable dtSession;
//        //private int currentQuestionId = -1;

//        bool isAutoMode = true;

//        private MainFormPresenter view;

//        public presenterBayesEsMainForm(MainFormPresenter f)
//        {
//            dbWorker = new DBWorker();
//            dSet = dbWorker.getDataSetForBayesSystem();
//            this.view = f;

//            //setStructureDtSession();
//            //setStructureDtProbList();
//        }

//        public void goToProductionES(DataTable session)
//        {
//            startForm sf = new startForm(session, this.dbWorker);
//            sf.ShowDialog();
//        }

//        public void askNextQuestion(ref int currentQuestionId)
//        {
//            currentQuestionId++;

//            if (currentQuestionId >= dSet.Tables["Question"].Rows.Count)
//            {
//                MessageBox.Show("Вопросы закончились");
//                getResult();
//            }
//            else
//            {
//                string curQuestion = dSet.Tables["Question"].Rows[currentQuestionId]["questionPhrase"].ToString();
//                view.changeLblCurrentQuestionText(curQuestion);
//                view.selectRowInDgvQuestion(currentQuestionId);
//            }
//        }

//        private void getResult()
//        {
//            throw new Exception();
//        }

//        public void btnYesClicked(int currentQuestionId, string questionPhrase, DataTable dtSession,DataTable dtProbList)
//        {

//            addRowToDtSession(currentQuestionId, questionPhrase, Answer.YES, dtSession);
//            //fillDgvSession();
//            updateDtProbList(dtProbList, dtSession);

//            if (isAutoMode == true)
//            {
//                //presenter.addRowToDtSession(questionId, questionPhrase, Answer.YES, dtSession);
//                //fillDgvSession();
//                //presenter.updateDtProbList(dtProbList, dtSession);

//                askNextQuestion(ref currentQuestionId);
//            }
//            else
//            {
//                //int questionId;
//                //string questionPhrase;
//                //getInformationAboutSelectedQuestion(out questionId, out questionPhrase);

//                //presenter.addRowToDtSession(questionId, questionPhrase, Answer.YES, dtSession);
//                //fillDgvSession();
//                //presenter.updateDtProbList(dtProbList,dtSession);
//            }
//        }

//        public void setStructureDtSession(out DataTable dtSession)
//        {
//            dtSession = new DataTable();

//            DataColumn questionId = new DataColumn("questionId", typeof(int));
//            questionId.Caption = "id вопроса";

//            DataColumn answerId = new DataColumn("answerId", typeof(int));
//            answerId.Caption = "id ответа";

//            DataColumn questionPhrase = new DataColumn("questionPhrase", typeof(string));
//            questionPhrase.Caption = "Вопрос";

//            DataColumn answer = new DataColumn("answerPhrase", typeof(string));
//            answer.Caption = "Ответ";

//            dtSession.Columns.AddRange(new DataColumn[] { questionId, answerId, questionPhrase, answer });
//        }

//        public void setStructureDtProbList(out DataTable dtProbList)
//        {
//            dtProbList = new DataTable("ProbabilityList");

//            DataColumn outcomeId = new DataColumn("outcomeId", typeof(int));
//            outcomeId.Caption = "id сущности";

//            DataColumn outcomeName = new DataColumn("outcomeName", typeof(string));
//            outcomeName.Caption = "Имя сущности";

//            DataColumn currentProbability = new DataColumn("currentProbability", typeof(float));
//            currentProbability.Caption = "Текущая вероятность";

//            DataColumn сommonProbability = new DataColumn("сommonProbability", typeof(float));
//            сommonProbability.Caption = "Априорная вероятность";

//            dtProbList.Columns.AddRange(new DataColumn[] { outcomeId, outcomeName, currentProbability, сommonProbability });
//        }

//        public void addRowToDtSession(int questionId, string questionPhrase, Answer ans, DataTable dtSession)
//        {
//            //int c = (int)dtSession.Compute("Count (questionId)", "questionId = " + questionId);

//            DataRow[] rowWithCurrentQuestionId = dtSession.Select("questionId = " + questionId);
//            if (rowWithCurrentQuestionId.Length != 0)
//            {
//                DialogResult dialogResult = MessageBox.Show("На этот вопрос ответ уже был выбран! Изменить ответ на новый?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
//                if (dialogResult == DialogResult.Yes)
//                {
//                    rowWithCurrentQuestionId[0].Delete();

//                    DataRow dr = dtSession.NewRow();
//                    dr["questionId"] = questionId;
//                    dr["questionPhrase"] = questionPhrase;
//                    dr["answerPhrase"] = WorkerWithAnswer.getTranslateOfAnswer(ans);
//                    dr["answerId"] = WorkerWithAnswer.getColoumnIdByAnswer(ans);

//                    dtSession.Rows.Add(dr);
//                }
//                else
//                {
//                    return;
//                }
//                //MessageBox.Show("На этот вопрос ответ уже был выбран! Изменить ответ на новый?");
//                //return;
//            }
//            else
//            {
//                DataRow dr2 = dtSession.NewRow();
//                dr2["questionId"] = questionId;
//                dr2["questionPhrase"] = questionPhrase;
//                dr2["answerPhrase"] = WorkerWithAnswer.getTranslateOfAnswer(ans);
//                dr2["answerId"] = WorkerWithAnswer.getColoumnIdByAnswer(ans);

//                dtSession.Rows.Add(dr2);
//            }

//        }

//        public void updateDtProbList(DataTable dtProbList, DataTable dtSession)
//        {

//            int outcomeCount = dSet.Tables["Outcome"].Rows.Count;

//            for (int j = 0; j < outcomeCount; j++)// все сущности
//            {
//                int jid = (int)dSet.Tables["Outcome"].Rows[j][0];

//                string s = "outcomeId = " + jid;
//                DataRow[] foundRows = dtProbList.Select("outcomeId = " + jid);
//                if (foundRows.Length == 0)
//                    MessageBox.Show("проблема в функции updateDtProbList - не нашли сущность по id");
//                float apriorProb = (float)foundRows[0][3];

//                float currentOutcomeProb = apriorProb;

//                //for (int k = 0; k < session.Count; k++)//все элементы в сессии
//                //
//                for (int k = 0; k < dtSession.Rows.Count; k++)
//                {
//                    //Pair curPair = (Pair)session[k];

//                    //int coloumnOfAnswer = getColoumnIdByAnswer(curPair.answer);
//                    object obj = dtSession.Rows[k]["answerId"];
//                    int coloumnOfAnswer = (int)obj;


//                    float conProbAnswer = 0;

//                    int curPairQuestionId = (int)dtSession.Rows[k]["questionId"];

//                    //string selectStr = "outcomeId = " + jid + " AND " + " questionId = " + curPair.questionId;
//                    string selectStr = "outcomeId = " + jid + " AND " + " questionId = " + curPairQuestionId;

//                    DataRow[] foundRowsQuestionary = dSet.Tables["Questionary"].Select(selectStr);
//                    if (foundRowsQuestionary.Length == 0)
//                    {
//                        int maxId;

//                        string selectAll = "";
//                        DataRow[] foundRowsAll = dSet.Tables["Questionary"].Select(selectAll);
//                        if (foundRowsAll.Length == 0)
//                            maxId = 0;
//                        else
//                        {
//                            object maxIdObj = dSet.Tables["Questionary"].Compute("Max(id)", "");
//                            maxId = int.Parse(maxIdObj.ToString());
//                        }

//                        DataRow dRow = dSet.Tables["Questionary"].NewRow();

//                        //dRow["id"] = maxId + 1;
//                        dRow["outcomeId"] = jid;
//                        dRow["questionId"] = curPairQuestionId;
//                        dRow["yesCount"] = 1;
//                        dRow["noCount"] = 1;
//                        dRow["dontKnowCount"] = 1;
//                        dRow["noMatterCount"] = 1;

//                        dSet.Tables["Questionary"].Rows.Add(dRow);
//                        dSet.AcceptChanges();

//                        maxId++;

//                        string selectStrAg = "outcomeId = " + jid + " AND " + " questionId = " + curPairQuestionId;
//                        DataRow[] foundRowsQuestionaryAg = dSet.Tables["Questionary"].Select(selectStrAg);
//                        if (foundRowsQuestionaryAg.Length == 0)
//                        { MessageBox.Show("Problem in searching"); }

//                        //string sql = "insert into Questionary (id, outcomeId, questionId, yesCount, noCount, dontKnowCount, noMatterCount) " +
//                        //                                       " values ( " + maxId + " , " + jid + " , " + curPairQuestionId + ", 1, 1, 1, 1)";
//                        //OleDbCommand command = new OleDbCommand(sql, dbWorker.connection);
//                        //dbWorker.connection.Open();
//                        //command.ExecuteNonQuery();
//                        //dbWorker.connection.Close();
//                        dbWorker.insertNewPositionInQuestionary(jid, curPairQuestionId, 1, 1, 1, 1);

//                        conProbAnswer = 1.0f / 4.0f;
//                    }
//                    else
//                    {
//                        int countCallofQuestionForThisOutcome = (int)foundRowsQuestionary[0][3] +
//                                                                (int)foundRowsQuestionary[0][4] +
//                                                                (int)foundRowsQuestionary[0][5] +
//                                                                (int)foundRowsQuestionary[0][6];



//                        if (countCallofQuestionForThisOutcome != 0)
//                        {
//                            int countOfAnswer = (int)foundRowsQuestionary[0][coloumnOfAnswer];
//                            conProbAnswer = (float)(countOfAnswer) / countCallofQuestionForThisOutcome;
//                        }
//                        else
//                            conProbAnswer = (float)(1 / 4);
//                    }
//                    currentOutcomeProb *= conProbAnswer;
//                }
//                if (currentOutcomeProb < 0.000001)
//                    currentOutcomeProb = 0;

//                foundRows[0][2] = currentOutcomeProb;


//            }


//            object sumOfcurrentOutcomeProbObj = dtProbList.Compute("Sum(currentProbability)", "");
//            float sumOfCurrentOutcomeProb = float.Parse(sumOfcurrentOutcomeProbObj.ToString());

//            for (int j = 0; j < outcomeCount; j++)// все сущности
//            {
//                float curValOfConProb = (float)(dtProbList.Rows[j][2]);
//                dtProbList.Rows[j][2] = curValOfConProb / sumOfCurrentOutcomeProb;
//            }
//        }

//        public DataTable getDtSession(DataTable dtSession)
//        {
//            return dtSession;
//        }

//        public string []getDtSessionColumnName(DataTable dtSession)
//        { 
//            int colCount = dtSession.Columns.Count;
//            string[] colCaption = new string[colCount];

//            for (int i = 0; i < dtSession.Columns.Count; i++)
//            {
//               colCaption[i] = dtSession.Columns[i].Caption;
//            }

//            return colCaption;
//        }
//    }
//}
