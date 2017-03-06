using System.Globalization;
using Randomizer.Interfaces.ValueTypes;
using Randomizer.OutputTests.Base;

namespace Randomizer.OutputTests.Tests.Float
{
    public class FloatNegativeValueOutputTest : OutputTestBase<float>
    {
        private readonly IRandomFloat randomFloat;

        public FloatNegativeValueOutputTest(IRandomFloat randomFloat, ILogger logger)
            : base(logger)
        {
            this.randomFloat = randomFloat;
        }

        public override void PerformTest(params float[] parameters)
        {
            for (int i = 0; i < ExecutionTimes; i++)
            {
                float randomValue = randomFloat.GenerateNegativeValue();
                if (randomValue > 0)
                {
                    WrongResults.Add(randomValue.ToString(CultureInfo.InvariantCulture));
                }
            }
            fileLogger.LogResult(WrongResults);
        }
    }
}