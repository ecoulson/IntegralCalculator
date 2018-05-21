﻿using System;

using IntegralCalculator.Streams;
using IntegralCalculator.App;

namespace IntegralCalculator.FunctionParser
{
    public class SyntaxTree
    {
        private SyntaxNode root;
        private SyntaxTreeBuilder treeBuilder;
        private CharacterStream currentCharacterStream;

        public SyntaxTree(TokenStream tokenStream) {
            this.treeBuilder = new SyntaxTreeBuilder(tokenStream);
            this.root = treeBuilder.buildTree();
        }

        public void analyze() {
            this.root = breakOutExponents(root);
            this.root = transformInvokes(root);
            this.root = breakDownIdentifiers(root);
        }

        public void print() {
            if (root.left != null) {
                Console.WriteLine(root.getSymbolValue());    
            }
        }

        private SyntaxNode breakOutExponents(SyntaxNode node) {
            if (node == null) {
                return node;
            } else if (isNodeExponentOperator(node)) {
                return seperateExponent(node);
            } else {
                SyntaxNode newNode = new SyntaxNode(node.getToken());
                newNode.left = breakOutExponents(node.left);
                newNode.right = breakOutExponents(node.right);
                return newNode;
            }
        }

        private bool isNodeExponentOperator(SyntaxNode node) {
            return node.getTokenType() == TokenType.OPERATOR && node.getSymbolValue() == "^";
        }

        private SyntaxNode seperateExponent(SyntaxNode node) {
            if (shouldSeperateIdentifier(node.left)) {
                return seperateIdentifier(node);
            } else if (shouldSeperateInvoke(node)) {
                return seperateInvoke(node);
            } else {
                return node;
            }
        }

        private bool shouldSeperateIdentifier(SyntaxNode node) {
            return node.getTokenType() == TokenType.IDENTIFIER && node.getSymbolValue().Length > 1;
        }

        private SyntaxNode seperateIdentifier(SyntaxNode node) {
            SyntaxNode[] splitNodes = splitIdentifierNodeAtLastChar(node.left);
            SyntaxNode multiplierNode = SyntaxNode.createMultiplierNode();
            multiplierNode.left = splitNodes[1];
            node.left = splitNodes[0];
            multiplierNode.right = node;
            return multiplierNode;
        }
        
        private SyntaxNode[] splitIdentifierNodeAtLastChar(SyntaxNode node) {
            SyntaxNode[] split = new SyntaxNode[2];
            string symbol = node.getSymbolValue();
            Symbol rhsSymbol = new Symbol(symbol.Substring(symbol.Length - 2, symbol.Length - 1));
            Symbol lhsSymbol = new Symbol(symbol[symbol.Length - 1].ToString());
            Token lhsIdentifier = new Token(lhsSymbol, TokenType.IDENTIFIER);
            Token rhsIdentifier = new Token(rhsSymbol, TokenType.IDENTIFIER);
            split[0] = new SyntaxNode(lhsIdentifier);
            split[1] = new SyntaxNode(rhsIdentifier);
            return split;
        }

        private bool shouldSeperateInvoke(SyntaxNode node) {
            return isInvokeNode(node.left) || isInvokeNode(node.right);
        }

        private bool isInvokeNode(SyntaxNode node) {
            return node.getTokenType() == TokenType.INVOKE;
        }

        private SyntaxNode seperateInvoke(SyntaxNode node) {
            return node;
        }

        private SyntaxNode transformInvokes(SyntaxNode node) {
            if (node == null) {
                return node;
            } else if (isInvokeNode(node)) {
                return simplifyInvoke(node);
            } else {
                SyntaxNode newNode = new SyntaxNode(node.getToken());
                newNode.left = transformInvokes(node.left);
                newNode.right = transformInvokes(node.right);
                return newNode;
            }
        }

        private SyntaxNode simplifyInvoke(SyntaxNode node) {
            if (isFunctionName(node.left)) {
                return node;
            } else {
                SyntaxNode multiplierNode = SyntaxNode.createMultiplierNode();
                multiplierNode.left = node.left;
                multiplierNode.right = node.right;
                return multiplierNode;
            }
        }

        private bool isFunctionName(SyntaxNode node) {
            return Calculator.functionNameSpace.ContainsKey(node.getSymbolValue());
        }

        private SyntaxNode breakDownIdentifiers(SyntaxNode node) {
            if (node == null) {
                return node;
            } else if (isIdentifierNode(node)) {
                string identifier = node.getTokenValue();
                currentCharacterStream = new CharacterStream(identifier);
                return parseIdentifier();
            } else {
                SyntaxNode newNode = new SyntaxNode(node.getToken());
                newNode.left = breakDownIdentifiers(node.left);
                newNode.right = breakDownIdentifiers(node.right);
                return newNode;
            }
        }

        private bool isIdentifierNode(SyntaxNode node) {
            return node.getTokenType() == TokenType.IDENTIFIER;
        }

        private SyntaxNode parseIdentifier() {
            SyntaxNode node = readNode();
            while (!currentCharacterStream.isEndOfStream()) {
                SyntaxNode operatorNode = SyntaxNode.createMultiplierNode();
                operatorNode.right = node;
                operatorNode.left = readNode();
                node = operatorNode;
            }
            return node;
        }

        private SyntaxNode readNode() {
            if (currentCharacterStream.isNextCharDigit()) {
                return readNumber();
            } else if (currentCharacterStream.isNextCharEuler()) {
                return readEuler();
            } else if (currentCharacterStream.isNextCharVariable()) {
                return readVariable();
            } else {
                throw new UnknownSymbolException("Unrecognized Symbol " + currentCharacterStream.readAsString());
            }
        }

        private SyntaxNode readNumber() {
            string number = "";
            while (shouldReadNumber()) {
                number += currentCharacterStream.readAsString();
            }
            Symbol numberSymbol = new Symbol(number);
            Token numberToken = new Token(numberSymbol, TokenType.NUMBER);
            return new SyntaxNode(numberToken);
        }

        private bool shouldReadNumber() {
            return !currentCharacterStream.isEndOfStream() && currentCharacterStream.isNextCharDigit();
        }

        private SyntaxNode readEuler() {
            currentCharacterStream.read();
            Symbol eulerSymbol = new Symbol(Math.E.ToString());
            Token eulerToken = new Token(eulerSymbol, TokenType.NUMBER);
            return new SyntaxNode(eulerToken);
        }

        private SyntaxNode readVariable() {
            string variable = currentCharacterStream.readAsString();
            Symbol variableSymbol = new Symbol(variable);
            Token variableToken = new Token(variableSymbol, TokenType.VARIABLE);
            return new SyntaxNode(variableToken);
        }
    }
}
