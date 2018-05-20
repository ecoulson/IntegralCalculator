using System;
using IntegralCalculator.FunctionParser;

namespace IntegralCalculator.App
{
    public class Function
    {
        private SyntaxTree evaluationTree;
        private Declaration declaration;
        private string function;

        public Function(string function) {
            this.function = function;
            if (isValidFunction()) {
                this.declaration = parseDeclaration();
                this.evaluationTree = parseExpression();
            } else {
                throw new Exception();
            }
        }

        private bool isValidFunction() {
            return true;
        }

        private SyntaxTree parseExpression() {
            string rightHandSide = getRightHandSide();
            ExpressionParser expressionParser = new ExpressionParser(rightHandSide);
            return expressionParser.parse();
        }

        private Declaration parseDeclaration() {
            string leftHandSide = getLeftHandSide();
            return new Declaration(leftHandSide);
        }

        private string getRightHandSide() {
            return function.Split('=')[1];
        }

        private string getLeftHandSide() {
            return function.Split('=')[0];
        }

        public double calculateY(double x) {
            return 5;
            //return evaluationTree.evaluate(x);
        }
    }
}
