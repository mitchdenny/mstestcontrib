using System;

namespace Calculator.Core
{
    public class BasicCalculator
    {
        public BasicCalculator() : this(0)
        {
        }

        public BasicCalculator(float accumulator)
        {
            this.Accumulator = accumulator;
        }

        public float Accumulator { get; private set; }


        public void Add(float value)
        {
            this.Accumulator = this.Accumulator + value;
        }

        public void Subtract(float value)
        {
            this.Accumulator = this.Accumulator - value;
        }

        public void Multiply(float value)
        {
            this.Accumulator = this.Accumulator * value;
        }

        public void Divide(float value)
        {
            this.Accumulator = this.Accumulator / value;
        }
    }
}
