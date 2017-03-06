using System.Globalization;
using Common.Core.Validation;
using Randomizer.Interfaces.ValueTypes;
using Randomizer.OutputTests.Base;

namespace Randomizer.OutputTests.Tests.DateTime
{
    public class DateTimePositiveValueOutputTest : OutputTestBase<System.DateTime>
    {
        // ReSharper disable once InconsistentNaming
        private readonly IRandomDateTime randomDateTime;

        public DateTimePositiveValueOutputTest(IRandomDateTime randomDateTime, ILogger logger)
            : base(logger)
        {
            Validator.ValidateNull(randomDateTime);
            this.randomDateTime = randomDateTime;
        }
        
        public override void PerformTest(params System.DateTime[] parameters)
        {

            for (int i = 0; i < ExecutionTimes; i++)
            {
                System.DateTime randomValue = randomDateTime.GeneratePositiveValue();
                if (randomValue > System.DateTime.Now)
                {
                    WrongResults.Add(randomValue.ToString(CultureInfo.InvariantCulture));
                }
            }
            fileLogger.LogResult(WrongResults);
        }
    }
}