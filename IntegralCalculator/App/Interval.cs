using System;
namespace IntegralCalculator.App
{
    public class Interval
    {
        private static readonly double MIN_INTERVAL_VALUE = double.Epsilon;
        private static readonly double MAX_INTERVAL_VALUE = 100;

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

        public override string ToString() {
            return "(" + this.start + ", " + this.end + ")";
        }

        public static Interval generateRandomInterval(double length) {
            Random random = new Random();
            double min = MIN_INTERVAL_VALUE + length;
            double max = MAX_INTERVAL_VALUE;
            double end = random.NextDouble() * (max - min) + min;
            double start = end - length;
            return new Interval(start, end);
        }
    }
}
