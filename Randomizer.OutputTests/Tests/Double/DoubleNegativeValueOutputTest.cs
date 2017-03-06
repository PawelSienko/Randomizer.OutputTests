using System.Globalization;
using Common.Core.Validation;
using Randomizer.Interfaces.ValueTypes;
using Randomizer.OutputTests.Base;

namespace Randomizer.OutputTests.Tests.Double
{
    public class DoubleNegativeValueOutputTest : OutputTestBase<double>
    {
        // ReSharper disable once InconsistentNaming
        private readonly IRandomDouble randomDouble;

        public DoubleNegativeValueOutputTest(IRandomDouble randomDouble, ILogger logger)
            : base(logger)
        {
            Validator.ValidateNull(randomDouble);
            this.randomDouble = randomDouble;
        }
        
        public override void PerformTest(params double[] parameters)
        {
            for (int i = 0; i < ExecutionTimes; i++)
            {
                double randomValue = randomDouble.GenerateNegativeValue();
                if (randomValue > 0)
                {
                    WrongResults.Add(randomValue.ToString(CultureInfo.InvariantCulture));
                }
            }
            fileLogger.LogResult(WrongResults);
        }
    }
}