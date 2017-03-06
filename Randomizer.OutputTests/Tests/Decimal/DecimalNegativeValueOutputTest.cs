using System.Globalization;
using Common.Core.Validation;
using Randomizer.Interfaces.ValueTypes;
using Randomizer.OutputTests.Base;

namespace Randomizer.OutputTests.Tests.Decimal
{
    public class DecimalNegativeValueOutputTest : OutputTestBase<decimal>
    {
        // ReSharper disable once InconsistentNaming
        private readonly IRandomDecimal randomDecimal;

        public DecimalNegativeValueOutputTest(IRandomDecimal randomDecimal, ILogger logger)
            : base(logger)
        {
            Validator.ValidateNull(randomDecimal);
            this.randomDecimal = randomDecimal;
        }
        
        public override void PerformTest(params decimal[] parameters)
        {

            for (int i = 0; i < ExecutionTimes; i++)
            {
                decimal randomValue = randomDecimal.GenerateNegativeValue();
                if (randomValue > 0)
                {
                    WrongResults.Add(randomValue.ToString(CultureInfo.InvariantCulture));
                }
            }
            fileLogger.LogResult(WrongResults);
        }
    }
}