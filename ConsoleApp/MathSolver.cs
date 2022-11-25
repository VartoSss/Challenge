using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    public static class MathSolver
    {
        public static string Solve(string question)
        {
            var result = "";
            var splittedQuestion = GetSplittedFields(question);

            foreach (var questionField in splittedQuestion)
                result += CalculateField(questionField) + " ";
            var trimmedResult = result.Trim();
            return trimmedResult;
        }

        public static string CalculateField(string questionField)
        {
            var withoutFunctions = GetRidOfFunctions.CalculateFunctions(questionField);
            var postfixExpression = PostfixBuilder.BuildPostfixExpression(withoutFunctions);
            var answer = PostfixCalculator.Calculate(postfixExpression).ToString();
            return answer;
        }

        public static string[] GetSplittedFields(string question)
        {
            var splitted = new List<string>();
            var currentField = "";

            for (int i = 0; i < question.Length; i++)
            {
                if (question[i] != ' ' && question[i] != '\"')
                {
                    currentField += question[i];
                }
                else if (question[i] == ' ')
                {
                    splitted.Add(currentField);
                    currentField = "";
                }
                else if (question[i] == '\"')
                {
                    var parsedQuotationField = ParseFieldWithQuotationMark(question, i);
                    currentField = parsedQuotationField[0];
                    i = int.Parse(parsedQuotationField[1]);
                }
            }
            if (!string.IsNullOrEmpty(currentField))
            {
                splitted.Add(currentField);
            }
            return splitted.ToArray();
        }

        public static string[] ParseFieldWithQuotationMark(string question, int i)
        {
            i++;
            var result = new StringBuilder();
            while (question[i] != '\"')
            {
                if (question[i] != ' ')
                    result.Append(question[i]);
                i++;
            }
            return new[] { result.ToString(), i.ToString() };
        }
    }
}
