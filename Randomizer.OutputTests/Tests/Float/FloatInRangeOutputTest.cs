using System.Globalization;
using Common.Core.Validation;
using Randomizer.Interfaces.ValueTypes;
using Randomizer.OutputTests.Base;

namespace Randomizer.OutputTests.Tests.Float
{
    public class FloatInRangeOutputTest : OutputTestBase<float>
    {
        // ReSharper disable once InconsistentNaming
        private readonly IRandomFloat randomFloat;
        public FloatInRangeOutputTest(IRandomFloat randomFloat, ILogger logger)
            : base(logger)
        {
            Validator.ValidateNull(randomFloat);
            this.randomFloat = randomFloat;
        }

        public override void PerformTest(params float[] parameters)
        {
            ValidateConfitions(parameters);
            float minValue = parameters[0];

            float maxValue = parameters[1];

            for (int i = 0; i < ExecutionTimes; i++)
            {
                float randomValue = randomFloat.GenerateValue(minValue, maxValue);
                if (randomValue > maxValue || randomValue < minValue)
                {
                    WrongResults.Add(randomValue.ToString(CultureInfo.InvariantCulture));
                }
            }
            fileLogger.LogResult(WrongResults);
        }
    }
}