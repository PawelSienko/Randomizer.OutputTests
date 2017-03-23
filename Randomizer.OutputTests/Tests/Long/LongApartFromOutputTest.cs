using System.Globalization;
using System.Linq;
using Common.Core.Validation;
using Randomizer.Interfaces.ValueTypes;
using Randomizer.OutputTests.Base;

namespace Randomizer.OutputTests.Tests.Long
{
    public class LongApartFromOutputTest : OutputTestBase<long>
    {
        // ReSharper disable once InconsistentNaming
        private readonly IRandomLong randomLong;

        public LongApartFromOutputTest(IRandomLong randomLong, ILogger logger) : base(logger)
        {
            Validator.ValidateNull(randomLong);
            this.randomLong = randomLong;
        }

        public override void PerformTest(params long[] parameters)
        {
            ValidateConfitions(parameters);

            for (int i = 0; i < ExecutionTimes; i++)
            {
                double randomValue = randomLong.GenerateValueApartFrom(parameters);
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
