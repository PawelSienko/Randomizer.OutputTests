using System.Globalization;
using Randomizer.Interfaces.ValueTypes;
using Randomizer.OutputTests.Base;

namespace Randomizer.OutputTests.Tests.Long
{
    public class LongInRangeOutputTest : OutputTestBase<long>
    {
        // ReSharper disable once InconsistentNaming
        private readonly IRandomLong randomLong;
        public LongInRangeOutputTest(IRandomLong randomLong, ILogger logger)
            : base(logger)
        {
            this.randomLong = randomLong;
        }
        
        public override void PerformTest(params long[] parameters)
        {
            ValidateConfitions(parameters);
            long minValue = parameters[0];

            long maxValue = parameters[1];


            for (int i = 0; i < ExecutionTimes; i++)
            {
                long randomValue = randomLong.GenerateValue(minValue, maxValue);
                if (randomValue > maxValue || randomValue < minValue)
                {
                    WrongResults.Add(randomValue.ToString(CultureInfo.InvariantCulture));
                }
            }
            fileLogger.LogResult(WrongResults);
        }
    }
}