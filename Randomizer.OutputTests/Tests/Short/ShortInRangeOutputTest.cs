using System.Globalization;
using Common.Core.Validation;
using Randomizer.Interfaces.ValueTypes;
using Randomizer.OutputTests.Base;

namespace Randomizer.OutputTests.Tests.Short
{
    public class ShortInRangeOutputTest : OutputTestBase<short>
    {
        // ReSharper disable once InconsistentNaming
        private readonly IRandomShort randomShort;

        public ShortInRangeOutputTest(IRandomShort randomShort, ILogger logger)
            : base(logger)
        {
            Validator.ValidateNull(randomShort);
            this.randomShort = randomShort;
        }
        
        public override void PerformTest(params short[] parameters)
        {
            ValidateConfitions(parameters);
            // ReSharper disable once PossibleNullReferenceException
            short minValue = parameters[0];
            // ReSharper disable once PossibleNullReferenceException
            short maxValue = parameters[1];

            for (int i = 0; i < ExecutionTimes; i++)
            {
                short randomValue = randomShort.GenerateValue(minValue, maxValue);
                if (randomValue > maxValue || randomValue < minValue)
                {
                    WrongResults.Add(randomValue.ToString(CultureInfo.InvariantCulture));
                }
            }
            fileLogger.LogResult(WrongResults);
        }
    }
}