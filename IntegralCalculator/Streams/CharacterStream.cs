using System;

using IntegralCalculator.Exceptions;

namespace IntegralCalculator.Streams
{
    public class CharacterStream : Stream<char>
    {
        private string expression;

        public CharacterStream(string expression)
            :base(expression.Length) 
        {
            this.expression = expression;
        }

        public override char read() {
            int index = cursor.getPosition();
            char data = expression[index];
            cursor.incrementPosition();
            return data;
        }

        public override void seek(int offset) {
            cursor.setPosition(offset);
        }

        public string readAsString() {
            char symbol = read();
            return symbol.ToString();
        }

        public char peek() {
            int oldPosition = cursor.getPosition();
            char data = read();
            seek(oldPosition);
            return data;
        }

        public bool isNextCharWhiteSpace() {
            char startingChar = peek();
            return char.IsWhiteSpace(startingChar);
        }

        public bool isNextCharIdentifier() {
            char startingChar = peek();
            return char.IsLetterOrDigit(startingChar) || startingChar == '.'; 
        }

        public bool isNextCharOperator() {
            char startingChar = peek();
            return startingChar == '+' ||
                    startingChar == '-' ||
                    startingChar == '^' ||
                    startingChar == '*' ||
                    startingChar == '/' ||
                    startingChar == '|';
        }

        public bool isNextCharLeftParentheses() {
            char startingChar = peek();
            return startingChar == '(' || startingChar == '[';
        }

        public bool isNextCharRightParentheses() {
            char startingChar = peek();
            return startingChar == ')' || startingChar == ']';
        }
    }
}
