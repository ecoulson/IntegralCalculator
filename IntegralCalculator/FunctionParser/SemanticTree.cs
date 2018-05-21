using System;
using IntegralCalculator.App;
using IntegralCalculator.Exceptions;

namespace IntegralCalculator.FunctionParser
{
    public class SemanticTree
    {
        private SyntaxTree syntaxTree;
        private SemanticNode root;
        private Declaration declaration;

        public SemanticTree(SyntaxTree syntaxTree) {
            this.syntaxTree = syntaxTree;
        }

        public void analyze(Declaration declaration) {
            this.declaration = declaration;
            this.root = analyze(syntaxTree.getRoot());
        }

        private SemanticNode analyze(SyntaxNode node) {
            if (node == null) {
                return null;
            } else if (node.getTokenType() == TokenType.VARIABLE) {
                return evaluateVariableNode(node);
            } else {
                SemanticNode newRoot = new SemanticNode(node.getToken());
                newRoot.left = analyze(node.left);
                newRoot.right = analyze(node.right);
                return newRoot;
            }
        }

        private SemanticNode evaluateVariableNode(SyntaxNode node) {
            if (isCurrentFunctionParameter(node)) {
                return new SemanticNode(node.getToken());
            } else if (isFunctionName(node)) {
                return new SemanticNode(node.getToken());
            } else if (localNamespaceHasConstant(node)) {
                return readLocalNamespaceConstant(node);
            } else if (globalNamespaceHasConstant(node)) {
                return readGlobalNamespaceConstant(node);
            } else {
                throw new UnknownVariableException();
            }
        } 

        private bool isCurrentFunctionParameter(SyntaxNode node) {
            return this.declaration.getVariable() == node.getSymbolValue()[0];
        }

        private bool isFunctionName(SyntaxNode node) {
            return Calculator.currentNameSpace.hasFunction(node.getSymbolValue()) ||
                             Calculator.globalNameSpace.hasFunction(node.getSymbolValue());
        }

        private bool localNamespaceHasConstant(SyntaxNode node) {
            return Calculator.currentNameSpace.hasConstant(node.getSymbolValue());
        }

        private SemanticNode readLocalNamespaceConstant(SyntaxNode node) {
            return readConstantFromNamespace(Calculator.currentNameSpace, node);
        } 

        private SemanticNode readConstantFromNamespace(Namespace space, SyntaxNode node) {
            string variable = node.getSymbolValue();
            string constant = space.getConstant(variable);
            Symbol symbol = new Symbol(constant);
            Token token = new Token(symbol, TokenType.NUMBER);
            return new SemanticNode(token);
        }

        private bool globalNamespaceHasConstant(SyntaxNode node) {
            return Calculator.globalNameSpace.hasConstant(node.getSymbolValue());
        }

        private SemanticNode readGlobalNamespaceConstant(SyntaxNode node) {
            return readConstantFromNamespace(Calculator.globalNameSpace, node);
        }
    }
}
