using System;
using System.Collections.Generic;
using IntegralCalculator.Streams;

namespace IntegralCalculator.FunctionParser {
    public class ExpressionParser {
        private string expression;

        public ExpressionParser(string expression) {
            this.expression = expression;
        }

        public EvaluationTree parse() {
            ExpressionLexer lexer = new ExpressionLexer(expression);
            TokenStream tokenStream = lexer.lex();

            SyntaxTree syntaxTree = new SyntaxTree(tokenStream);
            EvaluationTree evaluationTree = new EvaluationTree(syntaxTree);
            return evaluationTree;
        }
    }
}
