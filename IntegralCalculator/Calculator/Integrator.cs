using System;
namespace IntegralCalculator.App
{
    public class Integrator
    {
        private const int STARTING_INTERVAL = 0;
        private const int TOTAL_SUB_INTERVALS = 1000000;

        private Integral integral;
        private Accumulator accumulator;

        private int currentSubInterval;
        private double subIntervalLength;

        public Integrator(Integral integral) {
            this.integral = integral;
            this.accumulator = new Accumulator();

            this.currentSubInterval = STARTING_INTERVAL;
            this.subIntervalLength = calculateSubIntervalLength();
        }

        private double calculateSubIntervalLength() {
            Interval interval = integral.getInterval();
            double length = interval.getLength();
            return length / TOTAL_SUB_INTERVALS;
        }

        public double integrate() {
            while (isAccumulatingSubIntervals()) {
                currentSubInterval++;
                double accumulation = calculateAccumulationOverSubInterval();
                accumulator.accumulate(accumulation);
            }
            return accumulator.getCurrentAccumulation();
        }

        private bool isAccumulatingSubIntervals() {
            return currentSubInterval != TOTAL_SUB_INTERVALS;
        }

        private double calculateAccumulationOverSubInterval() {
            Function function = integral.getFunction();
            double x = calculateX();
            double y = function.calculateY(x);
            double accumulation = y * subIntervalLength;
            return accumulation;
        }

        private double calculateX() {
            Interval interval = integral.getInterval();
            return interval.getStartPoint() + currentSubInterval * subIntervalLength;
        }

    }
}
