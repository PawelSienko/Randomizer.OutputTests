using System.Globalization;
using Randomizer.Interfaces.ValueTypes;
using Randomizer.OutputTests.Base;

namespace Randomizer.OutputTests.Tests.Float
{
    public class FloatPositiveValueOutputTest : OutputTestBase<float>
    {
        // ReSharper disable once InconsistentNaming
        private readonly IRandomFloat randomFloat;
        public FloatPositiveValueOutputTest(IRandomFloat randomFloat, ILogger logger)
            : base(logger)
        {
            this.randomFloat = randomFloat;
        }

        public override void PerformTest(params float[] parameters)
        {
            for (int i = 0; i < ExecutionTimes; i++)
            {
                float randomValue = randomFloat.GeneratePositiveValue();
                if (randomValue < 0)
                {
                    WrongResults.Add(randomValue.ToString(CultureInfo.InvariantCulture));
                }
            }
            fileLogger.LogResult(WrongResults);
        }
    }
}
