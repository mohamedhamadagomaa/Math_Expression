using ConsoleApp1.TrainingApps.MathExpressoinEvaluator;
using Math_Expression.ConsoleApp1.TrainingApps.MathExpressoinEvaluator;

namespace Math_Expression.ConsoleApp1.TrainingApp.MathExpressoinEvaluator
{
    public static class App
    {
        public static void Run(string[] args)
        {
            while (true)
            {
                Console.Write("Please Enter The Expression: ");
                var input = Console.ReadLine();
                var expression = ExpressionParser.Parse(input);
                Console.WriteLine($"Left Side = {expression.LeftSideOperand} , Operation =  {expression.Operatoin} , Right Side = {expression.RightSideOperand}");
                Console.WriteLine($"{input} = {EvaluateExpression(expression)}");
            }

        }

        private static object EvaluateExpression(MathExpression expression)
        {
            if (expression.Operatoin == MathOperatoin.Addition)
                return expression.LeftSideOperand + expression.RightSideOperand;
            else if (expression.Operatoin == MathOperatoin.Subtraction)
                return expression.LeftSideOperand - expression.RightSideOperand;
            else if (expression.Operatoin == MathOperatoin.Multiplication)
                return expression.LeftSideOperand * expression.RightSideOperand;
            else if (expression.Operatoin == MathOperatoin.Divition)
                return expression.LeftSideOperand / expression.RightSideOperand;
            else if (expression.Operatoin == MathOperatoin.Madulus)
                return expression.LeftSideOperand % expression.RightSideOperand;
            else if (expression.Operatoin == MathOperatoin.Power)
                return Math.Pow(expression.LeftSideOperand, expression.RightSideOperand);
            else if (expression.Operatoin == MathOperatoin.Sin)
                return Math.Sin(expression.RightSideOperand);
            else if (expression.Operatoin == MathOperatoin.Cos)
                return Math.Cos(expression.RightSideOperand);
            else if (expression.Operatoin == MathOperatoin.Tan)
                return Math.Tan(expression.RightSideOperand);
            return 0;

        }
    }
}
