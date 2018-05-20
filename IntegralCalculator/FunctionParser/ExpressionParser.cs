using System;
using System.Collections.Generic;
using IntegralCalculator.Streams;
using IntegralCalculator.FunctionParser.Terms;

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
            EvaluationTree evaluationTree = syntaxTree.buildEvaluationTree();
            return evaluationTree;
        }
    }
}
