using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.OleDb;

namespace WebApplicationForExpertSystem
{
    /// <summary>
    /// Summary description for WebServiceForExpertSystem
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceForExpertSystem : System.Web.Services.WebService
    {
        private string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + @"Data Source= E:\Синхронизация с Облаком mail.ru\ES_classification\ES_classification\bin\Debug\db1.mdb";

        //[WebMethod]
        //public string HelloWorld()
        //{
        //    return "Hello World";
        //}

        //[WebMethod]
        //public string HW(int i)
        //{
        //    return (i + 1).ToString();
        //}

        [WebMethod]
        public DataSet dbwGetDataSetForBayesSystem()
        {
            OleDbConnection connection = new OleDbConnection(connectionString);

            DataSet dataSet = new DataSet();

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
                dataAdapterOutcome.Fill(dataSet, "Outcome");

                sql = "select * from Questionary";
                OleDbDataAdapter dataAdapterQuestionary = new OleDbDataAdapter(sql, connection);
                dataAdapterQuestionary.Fill(dataSet, "Questionary");
            }            
            catch {
                return null;
            }
            finally { 
                connection.Close(); 
            }

            return dataSet;
        }

        [WebMethod]
        public string dbwAddNewQuestion(string questionString, int functionalAreaId)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);

            string result = "Добавления вопроса прошло успешно";

            try
            {
                string selectString = "SELECT COUNT(*) FROM Question WHERE questionPhrase = \'" + questionString + "\'";
                OleDbCommand command = new OleDbCommand(selectString, connection);
                connection.Open();
                object o = command.ExecuteScalar();
                int count = System.Convert.ToInt32(o);
                if (count != 0)
                {
                    throw new Exception("Вопрос \"" + questionString + "\" уже присутствует в системе");
                }


                string fullString = string.Format("INSERT INTO Question  (questionPhrase, functionalAreaId) VALUES ('{0}', {1})", questionString, functionalAreaId);
                command = new OleDbCommand(fullString, connection);
                command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                result = ex.Message;
            }
            finally
            {
               connection.Close();
            }

            return result;
        }
    }
}
