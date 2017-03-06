using System.Globalization;
using Randomizer.Interfaces.ValueTypes;
using Randomizer.OutputTests.Base;

namespace Randomizer.OutputTests.Tests.Long
{
    public class LongPositiveValueOutputTest : OutputTestBase<long>
    {
        // ReSharper disable once InconsistentNaming
        private readonly IRandomLong randomLong;
        public LongPositiveValueOutputTest(IRandomLong randomLong, ILogger logger)
            : base(logger)
        {
            this.randomLong = randomLong;
        }

        public override void PerformTest(params long[] parameters)
        {
            for (int i = 0; i < ExecutionTimes; i++)
            {
                long randomValue = randomLong.GeneratePositiveValue();
                if (randomValue < 0)
                {
                    WrongResults.Add(randomValue.ToString(CultureInfo.InvariantCulture));
                }
            }
            fileLogger.LogResult(WrongResults);
        }
    }
}