using System.Globalization;
using Common.Core.Validation;
using Randomizer.Interfaces.ValueTypes;
using Randomizer.OutputTests.Base;

namespace Randomizer.OutputTests.Tests.Decimal
{
    public class DecimalInRangeOutputTest : OutputTestBase<decimal>
    {
        // ReSharper disable once InconsistentNaming
        private readonly IRandomDecimal randomDecimal;

        public DecimalInRangeOutputTest(IRandomDecimal randomDecimal, ILogger logger)
            : base(logger)
        {
            Validator.ValidateNull(randomDecimal);
            this.randomDecimal = randomDecimal;
        }
        
        public override void PerformTest(params decimal[] parameters)
        {
            ValidateConfitions(parameters);

            // ReSharper disable once PossibleNullReferenceException
            decimal minValue = parameters[0];
            // ReSharper disable once PossibleNullReferenceException
            decimal maxValue = parameters[1];

            for (int i = 0; i < ExecutionTimes; i++)
            {
                decimal randomValue = randomDecimal.GenerateValue(minValue, maxValue);
                if (randomValue > maxValue || randomValue < minValue)
                {
                    WrongResults.Add(randomValue.ToString(CultureInfo.InvariantCulture));
                }
            }
            fileLogger.LogResult(WrongResults);
        }
    }
}