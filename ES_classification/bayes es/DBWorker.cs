using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

namespace ES_classification
{

        public class DBWorker
        {
            public OleDbConnection connection;
            OleDbDataAdapter dataAdapterQuestionary;

            public DBWorker()
            {
                string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + @"Data Source= db1.mdb";
                connection = new OleDbConnection(connectionString);
            }

            public DBWorker(string filePath)
            {
                string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + @"Data Source= " + filePath;
                this.connection = new OleDbConnection(connectionString);
            }

            ~DBWorker()
            {
                connection = null;
            }

            public DataSet getDataSet()
            {
                DataSet dataSet = new DataSet();

                //connection.Open();
                //try{
                //    string sql = "select * from Question";
                //    OleDbCommand command = new OleDbCommand(sql, connection);
                //    dataAdapter = new OleDbDataAdapter(command);
                //    //dataAdapter.Fill(dtQuestion);
                //    dataAdapter.Fill(dataSet, "Question");

                //    dataSet.Tables.Add(dtQuestion);
                //    dataSet.Tables[0].TableName = "Question";

                //    sql = "select * from Outcome";
                //    command = new OleDbCommand(sql, connection);
                //    dataAdapter = new OleDbDataAdapter(command);
                //    dataAdapter.Fill(dtOutcome);

                //    dataSet.Tables.Add(dtOutcome);
                //    dataSet.Tables[1].TableName = "Outcome";

                //    sql = "select * from Questionary";
                //    command = new OleDbCommand(sql, connection);
                //    dataAdapter = new OleDbDataAdapter(command);
                //    dataAdapter.Fill(dtQuestionary);

                //    dataSet.Tables.Add(dtQuestionary);
                //    dataSet.Tables[2].TableName = "Questionary";
                //}
                //finally{connection.Close();}

                
                try
                {
                    connection.Open();
                    string sql = "select * from Question";
                    OleDbCommand command = new OleDbCommand(sql, connection);
                    OleDbDataAdapter dataAdapterQuestion = new OleDbDataAdapter(command);
                    dataAdapterQuestion.Fill(dataSet, "Question");

                    sql = "select * from Outcome";
                    command = new OleDbCommand(sql, connection);
                    OleDbDataAdapter dataAdapterOutcome = new OleDbDataAdapter(command);
                    dataAdapterOutcome.Fill(dataSet,"Outcome");

                    sql = "select * from Questionary";
                    dataAdapterQuestionary = new OleDbDataAdapter(sql,connection);
                    dataAdapterQuestionary.Fill(dataSet, "Questionary");
                }
                finally { connection.Close(); }


                return dataSet;
            }

            public DataSet getDataSetOutcome()
            {
                DataSet dataSet = new DataSet();
                connection.Open();
                try
                {
                    string sql = "select * from Outcome";
                    OleDbCommand command = new OleDbCommand(sql, connection);
                    OleDbDataAdapter dataAdapterOutcome = new OleDbDataAdapter(command);
                    dataAdapterOutcome.Fill(dataSet, "Outcome");
                }
                finally { connection.Close(); }


                return dataSet;
            }

            //public void update(DataSet ds)
            //{
            //    try
            //    {
            //        dataAdapterQuestionary = new OleDbDataAdapter();
            //        OleDbCommandBuilder commandBuilder = new OleDbCommandBuilder(dataAdapterQuestionary);
            //        dataAdapterQuestionary.UpdateCommand = commandBuilder.GetUpdateCommand();
            //        dataAdapterQuestionary.InsertCommand = commandBuilder.GetInsertCommand();
            //        dataAdapterQuestionary.DeleteCommand = commandBuilder.GetDeleteCommand();
            //        dataAdapterQuestionary.Update(ds);
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.ToString());
            //    }
            //}

            public void addNewQuestion(string questionString, int functionalAreaId)
            {
                try
                {
                    string selectString = "SELECT COUNT(*) FROM Question WHERE questionPhrase = \'" + questionString + "\'";
                    OleDbCommand command = new OleDbCommand(selectString, this.connection);
                    this.connection.Open();
                    object o = command.ExecuteScalar();
                    int count = System.Convert.ToInt32(o);
                    if (count != 0)
                    {
                        throw new Exception("Вопрос \"" + questionString + "\" уже присутствует в системе");
                    }


                    string fullString = string.Format("INSERT INTO Question  (questionPhrase, functionalAreaId) VALUES ('{0}', {1})", questionString, functionalAreaId);
                    command = new OleDbCommand(fullString, this.connection);
                    command.ExecuteNonQuery();
                }
                finally {
                    this.connection.Close();
                }
            }

            public DataTable getDataTable(string tableName)
            {
                DataTable result = new DataTable();
                string selectString = "SELECT * FROM " + tableName;
                OleDbCommand command = new OleDbCommand(selectString, this.connection);
                connection.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                adapter.Fill(result);
                connection.Close();
                return result;
            }

            internal void formStructureOfKnowlegeBase()
            {
                connection.Open();

                string sqlCreateOutcomeTable = @"CREATE TABLE Outcome (" +
                                                "id integer IDENTITY(1,1), " +
                                                "outcomeName char(100), " +
                                                "countClassification integer, " +
                                                "PRIMARY KEY(id)) ";
                OleDbCommand command = new OleDbCommand(sqlCreateOutcomeTable, connection);
                command.ExecuteNonQuery();

                string sqlCreateQuestionTable = @"CREATE TABLE Question (" +
                                                "id integer IDENTITY(1,1), " +
                                                "questionPhrase char(100), " +
                                                "functionalAreaId integer," +
                                                "PRIMARY KEY(id)) ";

                command.CommandText = sqlCreateQuestionTable;
                command.ExecuteNonQuery();

                string sqlCreateQuestionaryTable = @"CREATE TABLE Questionary (" +
                                                    "id integer IDENTITY(1,1), " +
                                                    "outcomeId integer, " +
                                                    "questionId integer, " +
                                                    "yesCount integer, " +
                                                    "noCount integer, " +
                                                    "dontKnowCount integer, " +
                                                    "noMatterCount integer, " +
                                                    "PRIMARY KEY(id)) ";
                command.CommandText = sqlCreateQuestionaryTable;
                command.ExecuteNonQuery();

                string sqlCreateFunctionalAreaTable = @"CREATE TABLE FunctionalArea (" +
                                "id integer IDENTITY(1,1), " +
                                "areaName char(100), " +
                                "PRIMARY KEY(id)) ";

                command.CommandText = sqlCreateFunctionalAreaTable;
                command.ExecuteNonQuery();

                connection.Close();
                command = null;
            }

            internal void deleteQuestion(int selectedId)
            {
                connection.Open();
                string sqlDeleteQuestion = @"DELETE FROM Question WHERE id = " + selectedId;
                OleDbCommand command = new OleDbCommand(sqlDeleteQuestion, connection);

                command.ExecuteNonQuery();

                string sqlDeleteFromQuestionary = @"DELETE FROM Questionary WHERE questionId=" + selectedId;
                command = new OleDbCommand(sqlDeleteFromQuestionary, connection);
                command.ExecuteNonQuery();

                command = null;
                connection.Close();
            }

            public void addNewOutcome(string outcomeString)
            {
                try
                {
                    string selectString = "SELECT COUNT(*) FROM Outcome WHERE outcomeName = \'" + outcomeString + "\'";
                    OleDbCommand command = new OleDbCommand(selectString, this.connection);
                    this.connection.Open();
                    object o = command.ExecuteScalar();
                    int count = System.Convert.ToInt32(o);
                    if (count != 0)
                    {
                        throw new Exception("Вывод \"" + outcomeString + "\" уже есть в системе");
                    }


                    string fullString = "INSERT INTO Outcome  (outcomeName , countClassification) VALUES ('" + outcomeString + "' , 4)";
                    command = new OleDbCommand(fullString, this.connection);
                    command.ExecuteNonQuery();
                }
                finally
                {
                    this.connection.Close();
                }
            }

            internal void deleteOutcome(int selectedId)
            {
                connection.Open();
                string sqlDeleteQuestion = @"DELETE FROM Outcome WHERE id =" + selectedId;
                OleDbCommand command = new OleDbCommand(sqlDeleteQuestion, connection);
                command.ExecuteNonQuery();

                string sqlDeleteFromQuestionary = @"DELETE FROM Questionary WHERE outcomeId=" + selectedId;
                command = new OleDbCommand(sqlDeleteFromQuestionary, connection);
                command.ExecuteNonQuery();

                command = null;
                connection.Close();
            }

            internal DataTable getDTprobOfAnswersByQuestion(int questionId)
            {
                DataTable dtData = new DataTable();
                string selectString = "SELECT outcomeId, yesCount, noCount, dontKnowCount, noMatterCount FROM Questionary WHERE questionId = " + questionId + " ORDER BY outcomeId ASC";
                OleDbCommand cmd = new OleDbCommand(selectString, this.connection);
                connection.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                adapter.Fill(dtData);
                connection.Close();

                DataTable dtResult = new DataTable("probabilityOfAnswers");

                DataColumn outcomeId = new DataColumn("outcomeId", typeof(int));
                DataColumn yesProbability = new DataColumn("yesProbability", typeof(float));
                DataColumn noProbability = new DataColumn("noProbability", typeof(float));
                DataColumn dontKnowProbability = new DataColumn("dontKnowProbability", typeof(float));
                DataColumn noMatterProbability = new DataColumn("noMatterProbability", typeof(float));

                dtResult.Columns.AddRange(new DataColumn[] { outcomeId, yesProbability, noProbability, dontKnowProbability, noMatterProbability });

                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    int yesCount = (int)dtData.Rows[i]["yesCount"];
                    int noCount = (int)dtData.Rows[i]["noCount"];
                    int dontKnowCount = (int)dtData.Rows[i]["dontKnowCount"];
                    int noMatterCount = (int)dtData.Rows[i]["noMatterCount"];
                    int count =  yesCount + noCount + dontKnowCount + noMatterCount;

                    float yesProb = (float)yesCount / count;
                    float noProb = (float)noCount / count;
                    float dontKnowProb = (float)dontKnowCount / count;
                    float noMatterProb = (float)noMatterCount / count;

                    DataRow dRow = dtResult.NewRow();
                    dRow[outcomeId] = dtData.Rows[i]["outcomeId"];
                    dRow[yesProbability] = yesProb;
                    dRow[noProbability] = noProb;
                    dRow[dontKnowProbability] = dontKnowProb;
                    dRow[noMatterProbability] = noMatterProb;

                    dtResult.Rows.Add(dRow);
                }

                return dtResult;
            }

            internal void addNewFunctionalArea(string functionalAreaName)
            {
                try
                {
                    string selectString = "SELECT COUNT(*) FROM FunctionalArea WHERE areaName = \'" + functionalAreaName + "\'";
                    OleDbCommand command = new OleDbCommand(selectString, this.connection);
                    this.connection.Open();
                    object o = command.ExecuteScalar();
                    int count = System.Convert.ToInt32(o);
                    if (count != 0)
                    {
                        throw new Exception("Функциональная \"" + functionalAreaName + "\" уже есть в системе");
                    }


                    string fullString = "INSERT INTO FunctionalArea  (areaName) VALUES ('" + functionalAreaName + "')";
                    command = new OleDbCommand(fullString, this.connection);
                    command.ExecuteNonQuery();
                }
                finally
                {
                    this.connection.Close();
                }
            }

            internal DataRow getStatisticOfAnswers(int outcomeId, int questionId)
            {
                DataRow result = null;
                try
                {
                    string selectString = string.Format("SELECT * FROM Questionary WHERE outcomeId = {0} AND questionId = {1}", outcomeId, questionId);
                    OleDbCommand command = new OleDbCommand(selectString, connection);

                    DataTable dt = new DataTable();
                    this.connection.Open();
                    OleDbDataAdapter da = new OleDbDataAdapter(command);
                    da.Fill(dt);
                    connection.Close();
                    if (dt.Rows.Count == 0)
                        return result;
                    else
                        result = dt.Rows[0];
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally 
                {
                    connection.Close();
                }
                return result;
            }

            internal int updateStatistic(int outcomeId, int questionId, int yesProcent)
            {
                if (yesProcent == 0)
                    yesProcent = 1;
                if (yesProcent == 100)
                    yesProcent = 99;

                int result = -1;
                try 
                {
                    string updateString = string.Format("UPDATE Questionary SET yesCount = {0}, noCount = {1} WHERE outcomeId = {2} AND questionId = {3}", yesProcent, 100-yesProcent,outcomeId,questionId);
                    OleDbCommand command = new OleDbCommand(updateString, connection);
                    connection.Open();
                    result = command.ExecuteNonQuery();
                }
                finally 
                {
                    connection.Close();
                }

                if (result == 0)
                    result = this.addStatistic(outcomeId, questionId, yesProcent, 100 - yesProcent, 1, 1);
                

                return result;
            }

            internal int addStatistic(int outcomeId, int questionId, int yesCount, int noCount, int dontKnowCount, int noMatterCount)
            {
                int result = -1;
                try
                {
                    string insertString = string.Format("INSERT INTO Questionary (outcomeId, questionId, yesCount, noCount, dontKnowCount, noMatterCount) " +
                                                      " VALUES ({0},{1},{2},{3},{4},{5})", outcomeId, questionId, yesCount, noCount, dontKnowCount, noMatterCount);
                    OleDbCommand command = new OleDbCommand(insertString, connection);
                    connection.Open();
                    result = command.ExecuteNonQuery();
                }
                finally 
                { 
                    connection.Close();
                }
                return result;       
            }

            internal void updateOutcome(int outcomeId, string outcomeString)
            {
                int result = -1;
                try
                {
                    string updateString = string.Format("UPDATE Outcome SET outcomeName = '{0}' WHERE id = {1}", outcomeString, outcomeId);
                    OleDbCommand command = new OleDbCommand(updateString, connection);
                    connection.Open();
                    result = command.ExecuteNonQuery();
                }
                finally
                {
                    connection.Close();
                }
            }

            /// <summary>
            /// /////////////////////////////////////////////////////////////////////////
            /// </summary>
            /// <param name="questionId"></param>
            /// <returns></returns>
            //internal string getQuestionPhraseByQuestionId(int questionId)
            //{
            //    string result = null;
            //    try
            //    {
            //        string selectString = string.Format("SELECT * FROM Question WHERE id = {0}", questionId);
            //        OleDbCommand command = new OleDbCommand(selectString, connection);

            //        DataTable dt = new DataTable();
            //        this.connection.Open();
            //        OleDbDataAdapter da = new OleDbDataAdapter(command);
            //        da.Fill(dt);
            //        connection.Close();

            //        if (dt.Rows.Count == 0)
            //            return result;
            //        else
            //            result = dt.Rows[0][1].ToString();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //    finally
            //    {
            //        connection.Close();
            //    }
            //    return result;
            //}


            internal int insertNewPositionInQuestionary(int outcomeId, int questionId, int yesCount, int noCount, int dontKnowCount, int noMatterCount)
            {
                int result = 0;
                string sql = string.Format("insert into Questionary (outcomeId, questionId, yesCount, noCount, dontKnowCount, noMatterCount) values ({0}, {1}, {2}, {3}, {4}, {5})",
                    outcomeId, questionId, yesCount, noCount, dontKnowCount, noMatterCount);

                    //"insert into Questionary (id, outcomeId, questionId, yesCount, noCount, dontKnowCount, noMatterCount) " +
                    //                                           " values ( " + maxId + " , " + jid + " , " + curPairQuestionId + ", 1, 1, 1, 1)";
                try
                {
                    OleDbCommand command = new OleDbCommand(sql, connection);
                    connection.Open();
                    result = command.ExecuteNonQuery();
                    connection.Close();
                }
                catch 
                {
                    result = 0; 
                }
                finally 
                { 
                    connection.Close();
                }

                return result;
            }

            internal int updatePositionInQuestinary(int outcomeId, int questionId, string answerColumnName)
            {
                int result = 0;

                //string updateSql = "update Questionary set " + answerColumnName + " = " + (answerCount + 1) + " where id = " + idInQuestionary;

                string updateSql = string.Format("UPDATE Questionary SET {0} = {0} + 1 WHERE outcomeId = {1} AND questionId = {2}", answerColumnName, outcomeId, questionId);
                try
                {
                    OleDbCommand command = new OleDbCommand(updateSql, connection);
                    connection.Open();
                    result = command.ExecuteNonQuery();
                    connection.Close();
                }
                catch { result = 0; }
                finally { connection.Close(); }


                return result;
            }

            internal int updateCountClassificationForOutcome(int outcomeId)
            {
                //string selectStr = "id = " + idOfOutcome;
                //DataRow[] foundRowsOutcome = dSet.Tables["Outcome"].Select(selectStr);

                //int oldCountClassification = (int)foundRowsOutcome[0]["countClassification"];


                int result = 0;
                try
                {
                    string updateSql = "update Outcome set countClassification = countClassification + 1 where id = " + outcomeId;
                    OleDbCommand command = new OleDbCommand(updateSql, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch { result = 0; }
                finally { connection.Close(); }
                return result;
 
            }

            internal void updateQuestion(int questionId, int functionalAreaId, string questionString)
            {
                int result = -1;
                try
                {
                    string updateString = string.Format("UPDATE Question SET questionPhrase = '{0}', functionalAreaId = {1} WHERE id = {2}", questionString, functionalAreaId, questionId);
                    OleDbCommand command = new OleDbCommand(updateString, connection);
                    connection.Open();
                    result = command.ExecuteNonQuery();
                }
                catch { result = -1; }
                finally
                {
                    connection.Close();
                }
            }
        }

    ///////////////////////////////////////////////////////////////////////////

}
