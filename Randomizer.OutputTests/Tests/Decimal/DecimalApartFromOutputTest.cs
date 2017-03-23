using System;
using System.Globalization;
using System.Linq;
using Common.Core.Validation;
using Randomizer.Interfaces.ValueTypes;
using Randomizer.OutputTests.Base;

namespace Randomizer.OutputTests.Tests.Decimal
{
    public class DecimalApartFromOutputTest : OutputTestBase<decimal>
    {
        // ReSharper disable once InconsistentNaming
        private readonly IRandomDecimal randomDecimal;

        public DecimalApartFromOutputTest(IRandomDecimal randomDecimal, ILogger logger) : base(logger)
        {
            Validator.ValidateNull(randomDecimal);
            this.randomDecimal = randomDecimal;
        }

        public override void PerformTest(params decimal[] parameters)
        {
            ValidateConfitions(parameters);

            for (int i = 0; i < ExecutionTimes; i++)
            {
                decimal randomValue = randomDecimal.GenerateValueApartFrom(parameters);
                if (parameters.Any(item => item == randomValue))
                {
                    WrongResults.Add(randomValue.ToString(CultureInfo.InvariantCulture));
                }
            }
            fileLogger.LogResult(WrongResults);
        }
    }
}
