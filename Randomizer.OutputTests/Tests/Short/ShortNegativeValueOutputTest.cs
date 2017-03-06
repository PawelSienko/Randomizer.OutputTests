using System.Globalization;
using Randomizer.Interfaces.ValueTypes;
using Randomizer.OutputTests.Base;

namespace Randomizer.OutputTests.Tests.Short
{
    public class ShortNegativeValueOutputTest : OutputTestBase<short>
    {
        // ReSharper disable once InconsistentNaming
        private readonly IRandomShort randomShort;

        public ShortNegativeValueOutputTest(IRandomShort randomShort, ILogger logger)
            : base(logger)
        {
            this.randomShort = randomShort;
        }
       
        public override void PerformTest(params short[] parameters)
        {
            for (int i = 0; i < ExecutionTimes; i++)
            {
                short randomValue = randomShort.GenerateNegativeValue();
                if (randomValue > 0)
                {
                    WrongResults.Add(randomValue.ToString(CultureInfo.InvariantCulture));
                }
            }
            fileLogger.LogResult(WrongResults);
        }
    }
}