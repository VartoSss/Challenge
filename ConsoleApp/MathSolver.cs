namespace ConsoleApp
{
    public static class MathSolver
    {
        public static string Solve(string question)
        {
            var result = "";
            var possibleSeparators = new[] { " ", "\"" };
            var splittedQuestion = question.Split(possibleSeparators, System.StringSplitOptions.RemoveEmptyEntries);

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

        
    }
}
