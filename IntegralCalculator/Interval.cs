using System;
namespace IntegralCalculator
{
    public class Interval
    {
        private double start;
        private double end;

        public Interval(double start, double end) {
            this.start = start;
            this.end = end;
        }

        public double getStartPoint() {
            return start;
        }

        public double getEndPoint() {
            return end;
        }

        public double getLength() {
            return end - start;            
        }

        public void setStartPoint(double start) {
            this.start = start;
        }

        public void setEndPoint(double end) {
            this.end = end;
        }
    }
}
