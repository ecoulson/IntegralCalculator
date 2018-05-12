using System;
namespace IntegralCalculator
{
    public class Function
    {
        private Expression expression;

        public Function(string expression) {
            ExpressionParser expressionParser = new ExpressionParser(expression);
            this.expression = expressionParser.parse();
        }

        public double getY(double x) {
            return expression.evaluate(x);
        }
    }
}
