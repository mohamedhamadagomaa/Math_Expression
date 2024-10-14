using Math_Expression.ConsoleApp1.TrainingApps.MathExpressoinEvaluator;

namespace ConsoleApp1.TrainingApps.MathExpressoinEvaluator
{
    public static class ExpressionParser
    {
        private const string MathSympols = "+*/%^";
        public static MathExpression Parse(string input)
        {
            var expression = new MathExpression();
            string token = "";
            bool leftSideInitialised = false;
            for (int i = 0; i < input.Length; i++)
            {
                var currentchar = input[i];
                if (char.IsDigit(currentchar))
                {
                    token += currentchar;
                    if (i == input.Length - 1 && leftSideInitialised == true)
                    {
                        expression.RightSideOperand = double.Parse(token);
                        break;
                    }

                }
                else if (MathSympols.Contains(currentchar))
                {
                    if (!leftSideInitialised)
                    {
                        expression.LeftSideOperand = double.Parse(token);
                        leftSideInitialised = true;
                    }
                    expression.Operatoin = ParseMathOpetation(currentchar.ToString());
                    token = "";


                }
                else if (currentchar == '-' && i > 0)
                {
                    if (expression.Operatoin == MathOperatoin.None)
                    {
                        expression.Operatoin = MathOperatoin.Subtraction;
                        expression.LeftSideOperand = double.Parse(token);
                        leftSideInitialised = true;
                        token = "";
                    }
                    else if (expression.Operatoin == MathOperatoin.Subtraction)
                    {
                        token += currentchar;

                    }



                }
                else if (char.IsLetter(currentchar))
                {
                    leftSideInitialised = true;
                    token += currentchar;

                }
                else if (currentchar == ' ')
                {
                    if (!leftSideInitialised)
                    {
                        expression.LeftSideOperand = double.Parse(token);
                        leftSideInitialised = true;
                        token = "";
                    }
                    else if (expression.Operatoin == MathOperatoin.None)
                    {
                        expression.Operatoin = ParseMathOpetation(token);
                        token = "";
                    }

                }
                else
                    token += currentchar;

            }
            return expression;
        }

        private static MathOperatoin ParseMathOpetation(string token)
        {
            switch (token.ToLower())
            {
                case "+":
                    return MathOperatoin.Addition;
                case "*":
                    return MathOperatoin.Multiplication;
                case "/":
                    return MathOperatoin.Divition;
                case "%":
                case "mod":
                    return MathOperatoin.Madulus;
                case "^":
                case "pow":
                    return MathOperatoin.Power;
                case "sin":
                    return MathOperatoin.Sin;
                case "cos":
                    return MathOperatoin.Cos;
                case "tan":
                    return MathOperatoin.Tan;
                default:
                    return MathOperatoin.None;
            }
        }
    }
}
