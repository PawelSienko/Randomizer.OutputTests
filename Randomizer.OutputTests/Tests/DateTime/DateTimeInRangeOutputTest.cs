using System.Globalization;
using Common.Core.Validation;
using Randomizer.Interfaces.ValueTypes;
using Randomizer.OutputTests.Base;

namespace Randomizer.OutputTests.Tests.DateTime
{
    public class DateTimeInRangeOutputTest : OutputTestBase<System.DateTime>
    {
        // ReSharper disable once InconsistentNaming
        private readonly IRandomDateTime randomDateTime;

        public DateTimeInRangeOutputTest(IRandomDateTime randomDateTime, ILogger logger)
            : base(logger)
        {
            Validator.ValidateNull(randomDateTime);
            this.randomDateTime = randomDateTime;
        }
        
        private static bool IsDifferenceonlyInMilliseconds(System.DateTime minValue, System.DateTime maxValue, System.DateTime randomValue)
        {
            return IsSpecificCondition(minValue, randomValue) || IsSpecificCondition(maxValue, randomValue);
        }

        private static bool IsSpecificCondition(System.DateTime comparisonValue, System.DateTime randomValue)
        {
            if ((comparisonValue.Year == randomValue.Year && comparisonValue.Month == randomValue.Month
                 && comparisonValue.Day == randomValue.Day && comparisonValue.Hour == randomValue.Hour
                 && comparisonValue.Minute == randomValue.Minute && comparisonValue.Second == randomValue.Second))
            {
                return true;
            }

            return false;
        }

        public override void PerformTest(params System.DateTime[] parameters)
        {
            ValidateConfitions(parameters);
            
            System.DateTime minValue = parameters[0];
            
            System.DateTime maxValue = parameters[1];

            for (int i = 0; i < ExecutionTimes; i++)
            {
                System.DateTime randomValue = randomDateTime.GenerateValue(minValue, maxValue);

                // very specific condition :(
                if ((randomValue > maxValue || randomValue < minValue) && IsDifferenceonlyInMilliseconds(minValue, maxValue, randomValue) == false)
                {
                    WrongResults.Add(randomValue.ToString(CultureInfo.InvariantCulture));
                }
            }
            fileLogger.LogResult(WrongResults);
        }
    }
}