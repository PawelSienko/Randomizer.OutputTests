using System.Globalization;
using System.Linq;
using Common.Core.Validation;
using Randomizer.Interfaces.ValueTypes;
using Randomizer.OutputTests.Base;

namespace Randomizer.OutputTests.Tests.Short
{
    public class ShortApartFromOutputTest : OutputTestBase<short>
    {
        // ReSharper disable once InconsistentNaming
        private readonly IRandomShort randomShort;

        public ShortApartFromOutputTest(IRandomShort randomShort, ILogger logger) : base(logger)
        {
            Validator.ValidateNull(randomShort);
            this.randomShort = randomShort;
        }

        public override void PerformTest(params short[] parameters)
        {
            ValidateConfitions(parameters);

            for (int i = 0; i < ExecutionTimes; i++)
            {
                double randomValue = randomShort.GenerateValueApartFrom(parameters);
                // ReSharper disable once CompareOfFloatsByEqualityOperator
                if (parameters.Any(o => o == randomValue))
                {
                    WrongResults.Add(randomValue.ToString(CultureInfo.InvariantCulture));
                }
            }
            fileLogger.LogResult(WrongResults);
        }
    }
}
