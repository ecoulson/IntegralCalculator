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
            char nextChar = peek();
            return char.IsWhiteSpace(nextChar);
        }

        public bool isNextCharIdentifier() {
            char nextChar = peek();
            return char.IsLetterOrDigit(nextChar) || nextChar == '.'; 
        }

        public bool isNextCharOperator() {
            char nextChar = peek();
            return nextChar == '+' ||
                    nextChar == '-' ||
                    nextChar == '^' ||
                    nextChar == '*' ||
                    nextChar == '/' ||
                    nextChar == '|';
        }

        public bool isNextCharDigit() {
            char nextChar = peek();
            return char.IsDigit(nextChar) || nextChar == '.';
        }

        public bool isNextCharEuler() {
            char nextChar = peek();
            return nextChar == 'e';
        }

        public bool isNextCharVariable() {
            char nextChar = peek();
            return !isNextCharEuler() && char.IsLetter(nextChar);
        }

        public bool isNextCharLeftParentheses() {
            char nextChar = peek();
            return nextChar == '(' || nextChar == '[';
        }

        public bool isNextCharRightParentheses() {
            char nextChar = peek();
            return nextChar == ')' || nextChar == ']';
        }
    }
}
