using System;
using System.Collections.Generic;
using IntegralCalculator.Streams;

namespace IntegralCalculator.FunctionParser {
    public class ExpressionParser {
        private Declaration declaration;
        private string expression;

        public ExpressionParser(Declaration declaration, string expression) {
            this.declaration = declaration;
            this.expression = expression;
        }

        public EvaluationTree parse() {
            ExpressionLexer lexer = new ExpressionLexer(expression);
            TokenStream tokenStream = lexer.lex();

            SyntaxTree syntaxTree = new SyntaxTree(tokenStream);
            syntaxTree.analyze();

            SemanticTree semanticTree = new SemanticTree(syntaxTree);
            semanticTree.analyze(declaration);

            EvaluationTree evaluationTree = new EvaluationTree(syntaxTree);
            return evaluationTree;
        }
    }
}
