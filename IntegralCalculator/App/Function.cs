﻿using System;
using IntegralCalculator.FunctionParser;

namespace IntegralCalculator.App
{
    public class Function
    {
        private EvaluationTree evaluationTree;
        private Declaration declaration;
        private string function;

        public Function (Declaration declaration, EvaluationTree tree) {
            this.evaluationTree = tree;
            this.declaration = declaration;
        }

        public Function(string function) {
            this.function = function;
            if (isValidFunction()) {
                this.declaration = parseDeclaration();
                this.evaluationTree = parseExpression();
                addFunctionToNameSpace();
            } else {
                throw new Exception();
            }
        }

        private bool isValidFunction() {
            return true;
        }

        private EvaluationTree parseExpression() {
            string rightHandSide = getRightHandSide();
            ExpressionParser expressionParser = new ExpressionParser(declaration, rightHandSide);
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
            return evaluationTree.evaluate(x);
        }

        private void addFunctionToNameSpace() {
            string functionName = declaration.getName();
            Calculator.currentNameSpace.addFunction(functionName, this);
        }
    }
}
