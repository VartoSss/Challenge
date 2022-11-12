namespace ConsoleApp
{
    public static class MathSolver
    {
        public static string Solve(string question)
        {
            var withoutFunctions = GetRidOfFunctions.CalculateFunctions(question);
            var postfixExpression = PostfixBuilder.BuildPostfixExpression(withoutFunctions);
            var answer = PostfixCalculator.Calculate(postfixExpression).ToString();
            return answer;
        }
    }
}
