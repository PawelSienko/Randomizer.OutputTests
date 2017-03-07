using System.Globalization;
using Common.Core.Validation;
using Randomizer.Interfaces.ValueTypes;
using Randomizer.OutputTests.Base;

namespace Randomizer.OutputTests.Tests.Integer
{
    public class IntegerInRangeOutputTest : OutputTestBase<int>
    {
        // ReSharper disable once InconsistentNaming
        private readonly IRandomInteger randomInteger;
        public IntegerInRangeOutputTest(IRandomInteger randomInteger, ILogger logger)
            : base(logger)
        {
            Validator.ValidateNull(randomInteger);
            this.randomInteger = randomInteger;
        }
        
        public override void PerformTest(params int[] parameters)
        {
            int minValue = parameters[0];

            int maxValue = parameters[1];

            for (int i = 0; i < ExecutionTimes; i++)
            {
                int randomValue = randomInteger.GenerateValue(minValue, maxValue);
                if (randomValue > maxValue || randomValue < minValue)
                {
                    WrongResults.Add(randomValue.ToString(CultureInfo.InvariantCulture));
                }
            }
            fileLogger.LogResult(WrongResults);
        }
    }
}