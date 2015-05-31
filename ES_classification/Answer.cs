using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ES_classification
{
    public enum Answer { YES, NO, DONTKNOW, NOMATTER }

    public static class WorkerWithAnswer
    {
        public static void getInformationAboutAnswer(Answer a, ref string translation, ref string columnName, ref int columnId)
        { 

        }

        public static string getTranslateOfAnswer(Answer a)
        {
            string result;
            switch (a)
            {
                case Answer.YES:
                    {
                        result = "да";
                        break;
                    }
                case Answer.NO:
                    {
                        result = "нет";
                        break;
                    }
                case Answer.NOMATTER:
                    {
                        result = "не имеет значения";
                        break;
                    }
                case Answer.DONTKNOW:
                    {
                        result = "не известно";
                        break;
                    }
                default:
                    throw new Exception("Ошибка получения перевода ответа!");
            }
            return result;
        }

        public static int getColoumnIdByAnswer(Answer ans)
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
                throw new Exception("Ошибка в private int getColoumnIdByAnswer(Answer ans) ");
            return result;
        }

        public static string getColoumnNameByAnswer(Answer ans)
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
                throw new Exception("Ошибка в private string getColoumnNameByAnswer(Answer ans)");
            return result;
        }

        public static string getColoumnNameByAnswerId(int answerId)
        {
            string result = null;
            switch (answerId)
            {
                case 3:
                    result = "yesCount";
                    break;
                case 4:
                    result = "noCount";
                    break;
                case 5:
                    result = "dontKnowCount";
                    break;
                case 6:
                    result = "noMatterCount";
                    break;
                default:
                    result = null;
                    break;
            }
            if (result == null)
                throw new Exception("Ошибка в private string getColoumnNameByAnswer(Answer ans)");
            return result;
        }

        public static Answer getAnswerByText(string s)
        {
            Answer result;
            switch (s)
            {
                case "да":
                    {
                        result = Answer.YES;
                        break;
                    }
                case "нет":
                    {
                        result = Answer.NO;
                        break;
                    }
                //case Answer.NOMATTER:
                //    {
                //        result = "не имеет значения";
                //        break;
                //    }
                //case Answer.DONTKNOW:
                //    {
                //        result = "не известно";
                //        break;
                //    }
                default:
                    throw new Exception("Ошибка получения перевода ответа!");
            }
            return result;
        }
    }
}
