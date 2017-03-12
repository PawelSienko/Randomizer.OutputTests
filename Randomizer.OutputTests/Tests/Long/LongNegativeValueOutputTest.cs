using System.Globalization;
using Common.Core.Validation;
using Randomizer.Interfaces.ValueTypes;
using Randomizer.OutputTests.Base;

namespace Randomizer.OutputTests.Tests.Long
{
    public class LongNegativeValueOutputTest : OutputTestBase<long>
    {
        // ReSharper disable once InconsistentNaming
        private readonly IRandomLong randomLong;
        public LongNegativeValueOutputTest(IRandomLong randomLong, ILogger logger)
            : base(logger)
        {
            Validator.ValidateNull(randomLong);
            this.randomLong = randomLong;
        }

        public override void PerformTest(params long[] parameters)
        {
            for (int i = 0; i < ExecutionTimes; i++)
            {
                long randomValue = randomLong.GenerateNegativeValue();
                if (randomValue > 0)
                {
                    WrongResults.Add(randomValue.ToString(CultureInfo.InvariantCulture));
                }
            }
            fileLogger.LogResult(WrongResults);
        }
    }
}