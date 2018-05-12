using System;
namespace IntegralCalculator
{
    public class Integral
    {
        private Function function;
        private Interval interval;

        public Integral(Function function, Interval interval) {
            this.function = function;
            this.interval = interval;

        }

        public double integrate() {
            Integrator integrator = getIntegrator();
            return integrator.integrate();
        }

        private Integrator getIntegrator() {
            return new Integrator(this);
        }

        public Function getFunction() {
            return function;
        }

        public Interval getInterval() {
            return interval;
        }
    }
}
