using System;

using IntegralCalculator.Exceptions;

namespace IntegralCalculator.Streams
{
    public abstract class Stream<T>
    {
        protected Cursor cursor;

        private int size;

        public Stream(int size) {
            this.cursor = new Cursor();
            this.size = size;
        }

        public int length() {
            return size;
        }

        public void resize(int size) {
            this.size = size;
        }

        public bool isEndOfStream() {
            return cursor.getPosition() == size;
        }

        public virtual T read() {
            throw new IllegalReadException();
        }

        public virtual void seek(int offset) {
            throw new IllegalSeekException();
        }

        public virtual void write(T data) {
            throw new IllegalWriteException();
        }

        public int getCursorPosition() {
            return cursor.getPosition();
        }
    }
}
