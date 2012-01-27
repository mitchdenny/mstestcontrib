using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTestContrib.Specifications;
using System.Text;

namespace Calculator.Core.Specifications
{
    [TestClass]
    [SpecificationDescription("As a user I want to perform mathematical calculations so that my head doesn't hurt.")]
    public class BasicCalculatorSpecification : Specification
    {
        [TestMethod]
        [ScenarioDescription("Add two to a calculator with zero on the accumulator.")]
        public void AddTwoToACalculatorWithZeroOnTheAccumulator()
        {
            Given("a calculator with zero on the accumulator", x => x.State.Calculator = new BasicCalculator(0))
                .When("I add two to the accumulator", x => x.State.Calculator.Add(2))
                .Then("the accumulator should show two", x => x.State.Calculator.Accumulator == 2);
        }

        [TestMethod]
        [ScenarioDescription("Add negative two to a calculator with zero on the accumulator.")]
        public void AddNegativeTwoToACalculatorWithZeroOnTheAccumulator()
        {
            Given("a calculator with zero on the accumulator", x => x.State.Calculator = new BasicCalculator(0))
                .When("I add negative two to the accumulator", x => x.State.Calculator.Add(-2))
                .Then("the accumulator should show negative two", x => x.State.Calculator.Accumulator == -2);
        }

        [TestMethod]
        [ScenarioDescription("Add zero to a calculator with zero on the accumulator.")]
        public void AddZeroToACalculatorWithZeroOnTheAccumulator()
        {
            Given("a calculator with zero on the accumulator", x => x.State.Calculator = new BasicCalculator(0))
                .When("I add zero to the accumulator", x => x.State.Calculator.Add(0))
                .Then("the accumulator should show zero", x => x.State.Calculator.Accumulator == 0);
        }

        [TestMethod]
        [ScenarioDescription("Subtract two from a calculator with zero on the accumulator.")]
        public void SubtractTwoFromACalculatorWithZeroOnTheAccumulator()
        {
            Given("a calculator with zero on the accumulator", x => x.State.Calculator = new BasicCalculator(0))
                .When("I subtract two from the accumulator", x => x.State.Calculator.Subtract(2))
                .Then("the accumulator should show negative two", x => x.State.Calculator.Accumulator == -2);
        }

        [TestMethod]
        [ScenarioDescription("Subtract negative two from a calculator with zero on the accumulator.")]
        public void SubtractNegativeTwoFromACalculatorWithZeroOnTheAccumulator()
        {
            Given("a calculator with zero on the accumulator", x => x.State.Calculator = new BasicCalculator(0))
                .When("I subtract negative two from the accumulator", x => x.State.Calculator.Subtract(2))
                .Then("the accumulator should show two", x => x.State.Calculator.Accumulator == -2);
        }

        [TestMethod]
        [ScenarioDescription("Subtract zero from a calculator with zero on the accumulator.")]
        public void SubtractZeroFromACalculatorWithZeroOnTheAccumulator()
        {
            Given("a calculator with zero on the accumulator", x => x.State.Calculator = new BasicCalculator(0))
                .When("I subtract zero from the accumulator", x => x.State.Calculator.Subtract(0))
                .Then("the accumulator should show zero", x => x.State.Calculator.Accumulator == 0);
        }

        [TestMethod]
        [ScenarioDescription("Multiply by two a calculator with zero on the accumulator.")]
        public void MultiplyByTwoACalculatorWithZeroOnTheAccumulator()
        {
            Given("a calculator with zero on the accumulator", x => x.State.Calculator = new BasicCalculator(0))
                .When("I multiply the accumulator by two", x => x.State.Calculator.Multiply(2))
                .Then("the accumulator should show zero", x => x.State.Calculator.Accumulator == 0);
        }

        [TestMethod]
        [ScenarioDescription("Multiply by negative two a calculator with zero on the accumulator.")]
        public void MultiplyByNegativeTwoACaulcatorWithZeroOnTheAccumulator()
        {
            Given("a calculator with zero on the accumulator", x => x.State.Calculator = new BasicCalculator(0))
                .When("I multiply the accumulator by negative two", x => x.State.Calculator.Multiply(-2))
                .Then("the accumulator should show zero", x => x.State.Calculator.Accumulator == 0);
        }

        [TestMethod]
        [ScenarioDescription("Multiply by zero a calculator with zero on the accumulator.")]
        public void MultiplyByZeroACalculatorWithZeroOnTheAccumulator()
        {
            Given("a calculator with zero on the accumulator", x => x.State.Calculator = new BasicCalculator(0))
                .When("I multiply the accumulator by zero", x => x.State.Calculator.Multiply(0))
                .Then("the accumulator should show zero", x => x.State.Calculator.Accumulator == 0);
        }

        [TestMethod]
        [ScenarioDescription("Divide by two a calculator with zero on the accumulator.")]
        public void DivideByTwoACalculatorWithZeroOnTheAccumulator()
        {
            Given("a calculator with zero on the accumulator", x => x.State.Calculator = new BasicCalculator(0))
                .When("I divide the accumulator by two", x => x.State.Calculator.Divide(2))
                .Then("the accumulator should show zero", x => x.State.Calculator.Accumulator == 0);
        }

        [TestMethod]
        [ScenarioDescription("Divide by negative two a calculator with zero on the accumulator.")]
        public void DivideByNegativeTwoACalculatorWithZeroOnTheAccumulator()
        {
            Given("a calculator with zero on the accumulator", x => x.State.Calculator = new BasicCalculator(0))
                .When("I divide the accumulator by negative two", x => x.State.Calculator.Divide(-2))
                .Then("the accumulator should show zero", x => x.State.Calculator.Accumulator == 0);
        }

        [TestMethod]
        [ScenarioDescription("Divide by zero a calculator with zero on the accumulator.")]
        public void DivideByZeroACalculatorWithZeroOnTheAccumulator()
        {
            Given("a calculator with zero on the accumulator", x => x.State.Calculator = new BasicCalculator(0))
                .When("I divide the accumulator by zero", x => x.State.Calculator.Divide(0))
                .Then("the accumulator should show NaN", x => float.IsNaN(x.State.Calculator.Accumulator));
        }
    }
}