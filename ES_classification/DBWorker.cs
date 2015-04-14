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
                string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + @"Data Source= KBcar.mdb";
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

            public void addNewQuestion(string questionString)
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


                    string fullString = "INSERT INTO Question  (questionPhrase) VALUES ('" + questionString + "')";
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
                                                "idOutcome integer IDENTITY(1,1), " +
                                                "outcomeName char(100), " +
                                                "countClassification integer, " +
                                                "PRIMARY KEY(idOutcome)) ";
                OleDbCommand command = new OleDbCommand(sqlCreateOutcomeTable, connection);
                command.ExecuteNonQuery();

                string sqlCreateQuestionTable = @"CREATE TABLE Question (" +
                                                "idQuestion integer IDENTITY(1,1), " +
                                                "questionPhrase char(100), " +
                                                "PRIMARY KEY(idQuestion)) ";

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

                connection.Close();
                command = null;
            }

            internal void deleteQuestion(int selectedId)
            {
                connection.Open();
                string sqlDeleteQuestion = @"DELETE FROM Question WHERE idQuestion=" + selectedId;
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


                    string fullString = "INSERT INTO Outcome  (outcomeName , countClassification) VALUES ('" + outcomeString + "' , 1)";
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
                string sqlDeleteQuestion = @"DELETE FROM Outcome WHERE idOutcome=" + selectedId;
                OleDbCommand command = new OleDbCommand(sqlDeleteQuestion, connection);
                command.ExecuteNonQuery();

                string sqlDeleteFromQuestionary = @"DELETE FROM Questionary WHERE outcomeId=" + selectedId;
                command = new OleDbCommand(sqlDeleteFromQuestionary, connection);
                command.ExecuteNonQuery();

                command = null;
                connection.Close();
            }
        }



}
