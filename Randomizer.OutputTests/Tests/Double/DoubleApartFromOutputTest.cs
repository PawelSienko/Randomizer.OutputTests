using System;
using System.Globalization;
using System.Linq;
using Common.Core.Validation;
using Randomizer.Interfaces.ValueTypes;
using Randomizer.OutputTests.Base;

namespace Randomizer.OutputTests.Tests.Double
{
    public class DoubleApartFromOutputTest : OutputTestBase<double>
    {
        private readonly double tolerance;

        // ReSharper disable once InconsistentNaming
        private readonly IRandomDouble randomDouble;
        public DoubleApartFromOutputTest(IRandomDouble randomDouble, ILogger logger) : base(logger)
        {
            Validator.ValidateNull(randomDouble);
            this.randomDouble = randomDouble;
            this.tolerance = Math.Pow(0.1, 15);
        }

        public override void PerformTest(params double[] parameters)
        {
            ValidateConfitions(parameters);

            for (int i = 0; i < ExecutionTimes; i++)
            {
                double randomValue = randomDouble.GenerateValueApartFrom(parameters);
                if (parameters.Any(item => Math.Abs(item - randomValue) < tolerance))
                {
                    WrongResults.Add(randomValue.ToString(CultureInfo.InvariantCulture));
                }
            }
            fileLogger.LogResult(WrongResults);
        }
    }
}
