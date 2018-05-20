using System;
using System.Collections.Generic;

using IntegralCalculator.Exceptions;
using IntegralCalculator.Streams;
using IntegralCalculator.FunctionParser.Terms;

namespace IntegralCalculator.FunctionParser {
    public class TermBuilder {
        private TokenStream tokenStream;
        private TermStream termStream;

        public TermBuilder(TokenStream tokenStream) {
            this.tokenStream = tokenStream;
            this.termStream = new TermStream();
        }

        public TermStream buildTerms() {
            while(shouldReadTerms()) {
                addTerms();
            }
            return termStream;
        }

        private bool shouldReadTerms() {
            return !tokenStream.isEndOfStream() && 
                               !tokenStream.isNextTokenOperator();
        }

        private void addTerms() {
            Term nonUrnaryTerm = readNonUrnaryTerm();
            termStream.write(nonUrnaryTerm);
            if (shouldReadOperator()) {
                Term operatorTerm = readOperatorTerm();
                termStream.write(operatorTerm);
            }
        }

        private bool shouldReadOperator() {
            return !tokenStream.isEndOfStream() && 
                               tokenStream.isNextTokenOperator();
        }

        private Term readNonUrnaryTerm() {
            Token token = tokenStream.peek();
            switch (token.getTokenType()) {
                case TokenType.LEFT_PARENTHESES:
                case TokenType.RIGHT_PARENTHESES:
                    return readParenthesesTerm();
                case TokenType.ABSOLUTE_VALUE:
                    return readAbsoluteTerm();
                case TokenType.NUMBER:
                case TokenType.IDENTIFIER:
                    return readTerm();
                default:
                    string message = "Unexpected Token of Type " +
                    token.getTokenType();
                    throw new UnexpectedTokenException(message);
            }
        }

        private Term readParenthesesTerm() {
            Token token = tokenStream.read();
            TokenType parenthesesType = token.getTokenType();
            return new ParenthesesTerm(parenthesesType);
        }

        private Term readAbsoluteTerm() {
            Token token = tokenStream.read();
            return new AbsoluteTerm();
        }

        private Term readTerm() {
            if (shouldReadConstantTerm()) {
                return readConstantTerm();
            } else if (shouldReadAlgebraicTerm()) {
                return readAlgebraicTerm();
            } else if (shouldReadFunction()) {
                //return readFunction();
                return null;
            } else {
                throw new UnexpectedTokenException();   
            }
        }

        private bool shouldReadConstantTerm() {
            return shouldReadNumber();
        }

        private bool shouldReadNumber() {
            return !tokenStream.isEndOfStream() &&
                               (tokenStream.isNextTokenNumber() ||
                                tokenStream.isNextTokenEulerConstant());
        }

        private bool shouldReadVariable() {
            return !tokenStream.isEndOfStream() &&
                               tokenStream.isNextTokenVariable();
        }

        private Term readConstantTerm() {
            double constant = readNumber();
            while (shouldReadNumber()) {
                constant *= readNumber();
            }
            return new ConstantTerm(constant);
        }

        private double readNumber() {
            if (shouldReadNumber()) {
                Token token = tokenStream.read();
                Symbol symbol = token.getSymbol();
                return double.Parse(symbol.getValue());
            } else {
                throw new UnexpectedTokenException();
            }
        }

        private bool shouldReadAlgebraicTerm() {
            if (shouldReadNumber()) {
                int position = tokenStream.getCursorPosition();
                tokenStream.seek(position + 1);
                bool isNextVariable = shouldReadVariable();
                tokenStream.seek(position);
                return isNextVariable;
            } else {
                return shouldReadVariable();
            }
        }

        private Term readAlgebraicTerm() {
            double coefficient = readCoeffecient();
            char variable = readVariable();
            return new AlgebraicTerm(coefficient, variable);
        }

        private double readCoeffecient() {
            if (shouldReadNumber()) {
                return readNumber();
            } else {
                return 1;
            }
        }

        private char readVariable() {
            if (shouldReadVariable()) {
                Token token = tokenStream.read();
                Symbol symbol = token.getSymbol();
                char variable = char.Parse(symbol.getValue());
                return variable;
            } else {
                throw new UnexpectedTokenException();
            }
        }

        private bool shouldReadFunction() {
            if (tokenStream.isNextTokenIdentifier()) {
                int position = tokenStream.getCursorPosition();
                tokenStream.seek(position + 1);
                if (!tokenStream.isEndOfStream()) {
                    bool isFunction = tokenStream.isNextTokenLeftParentheses();
                    tokenStream.seek(position);
                    return isFunction;
                }
                else {
                    return false;
                }
            } else {
                return false;
            }
        }

        private Term readOperatorTerm() {
            OperatorType op = readOperator();
            return new OperatorTerm(op);
        }

        private OperatorType readOperator() {
            if (tokenStream.isNextTokenOperator()) {
                Token operatorToken = tokenStream.read();
                return Operator.getOperatorTypeFromToken(operatorToken);
            } else {
                throw new UnexpectedTokenException();
            }
        }
    }
}
