using System;
namespace IntegralCalculator
{
    public class Accumulator
    {
        private double accumulation;

        public Accumulator() {
            this.accumulation = 0;
        }

        public double getCurrentAccumulation() {
            return accumulation;
        }

        public void accumulate(double value) {
            accumulation += value;
        }
    }
}
