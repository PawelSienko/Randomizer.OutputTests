using System;
using System.Globalization;
using System.Linq;
using Randomizer.Interfaces.ValueTypes;
using Randomizer.OutputTests.Base;

namespace Randomizer.OutputTests.Tests.Integer
{
    public class IntegerApartFromOutputTest : OutputTestBase<int>
    {
        // ReSharper disable once InconsistentNaming
        private readonly IRandomInteger randomInteger;
        public IntegerApartFromOutputTest(IRandomInteger randomInteger, ILogger logger) : base(logger)
        {
            this.randomInteger = randomInteger;
        }

        public override void PerformTest(params int[] parameters)
        {
            ValidateConfitions(parameters);

            for (int i = 0; i < ExecutionTimes; i++)
            {
                double randomValue = randomInteger.GenerateValueApartFrom(parameters);
                // ReSharper disable once CompareOfFloatsByEqualityOperator
                if (parameters.Any(o => o == randomValue))
                {
                    WrongResults.Add(randomValue.ToString(CultureInfo.InvariantCulture));
                }
            }
            fileLogger.LogResult(WrongResults);

        }
    }
}
