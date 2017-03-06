using System.Globalization;
using Common.Core.Validation;
using Randomizer.Interfaces.ValueTypes;
using Randomizer.OutputTests.Base;

namespace Randomizer.OutputTests.Tests.Double
{
    public class DoubleInRangeOutputTest : OutputTestBase<double>
    {
        private IRandomDouble randomDouble;
        public DoubleInRangeOutputTest(IRandomDouble randomDouble, ILogger logger)
            : base(logger)
        {
            Validator.ValidateNull(randomDouble);
            this.randomDouble = randomDouble;
        }
        
        public override void PerformTest(params double[] parameters)
        {
            ValidateConfitions(parameters);

            double minValue = parameters[0];

            double maxValue = parameters[1];

            for (int i = 0; i < ExecutionTimes; i++)
            {
                double randomValue = randomDouble.GenerateValue(minValue, maxValue);
                if (randomValue > maxValue || randomValue < minValue)
                {
                    WrongResults.Add(randomValue.ToString(CultureInfo.InvariantCulture));
                }
            }
            fileLogger.LogResult(WrongResults);
        }
    }
}