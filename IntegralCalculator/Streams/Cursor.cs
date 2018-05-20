using System;
namespace IntegralCalculator.Streams
{
    public class Cursor {
        private int position;

        public Cursor() {
        }

        public int getPosition() {
            return position;
        }

        public void incrementPosition() {
            position++;
        }

        public void setPosition(int position) {
            this.position = position;
        }
    }
}
