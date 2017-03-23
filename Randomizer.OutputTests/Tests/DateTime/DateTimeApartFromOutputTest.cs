using System;
using System.Globalization;
using System.Linq;
using Common.Core.Validation;
using Randomizer.Interfaces.ValueTypes;
using Randomizer.OutputTests.Base;

namespace Randomizer.OutputTests.Tests.DateTime
{
    public class DateTimeApartFromOutputTest : OutputTestBase<System.DateTime>
    {
        // ReSharper disable once InconsistentNaming
        private readonly IRandomDateTime randomDateTime;

        public DateTimeApartFromOutputTest(IRandomDateTime randomDateTime, ILogger logger) : base(logger)
        {
            Validator.ValidateNull(randomDateTime);
            this.randomDateTime = randomDateTime;
        }

        public override void PerformTest(params System.DateTime[] parameters)
        {
            ValidateConfitions(parameters);

            for (int i = 0; i < ExecutionTimes; i++)
            {
                System.DateTime randomValue = randomDateTime.GenerateValueApartFrom(parameters);
                if (parameters.Any(o => o == randomValue))
                {
                    WrongResults.Add(randomValue.ToString(CultureInfo.InvariantCulture));
                }
            }
            fileLogger.LogResult(WrongResults);
        }
    }
}
