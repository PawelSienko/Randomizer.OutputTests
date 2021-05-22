using System;
using System.Collections.Generic;
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

        private static bool IsDifferenceOnlyInMilliseconds(System.DateTime minValue, System.DateTime maxValue, System.DateTime randomValue)
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

            if(parameters == null || parameters.Length < 2)
            {
                PerformParameterlessTest();
            }
            else
            {
                System.DateTime minValue = parameters[0];

                System.DateTime maxValue = parameters[1];
                PerformTestInternal(minValue, maxValue);
            }

            if (WrongResults.Count > 0)
            {
                fileLogger.LogResult(WrongResults);
            }
        }

        private void PerformParameterlessTest()
        {
            System.DateTime randomValue = default(System.DateTime);
            for (int i = 0; i < ExecutionTimes; i++)
            {
                try
                {
                    randomValue = randomDateTime.GenerateValue();
                }
                catch(Exception ex)
                {
                    WrongResults.Add(randomValue.ToString(CultureInfo.InvariantCulture));
                }
            }
        }

        private void PerformTestInternal(params System.DateTime[] parameters)
        {
            System.DateTime minValue = parameters[0];

            System.DateTime maxValue = parameters[1];

            for (int i = 0; i < ExecutionTimes; i++)
            {
                System.DateTime randomValue = randomDateTime.GenerateValue(minValue, maxValue);

                // very specific condition :(
                if ((randomValue > maxValue || randomValue < minValue) && IsDifferenceOnlyInMilliseconds(minValue, maxValue, randomValue) == false)
                {
                    WrongResults.Add(randomValue.ToString(CultureInfo.InvariantCulture));
                }
            }
        }
    }
}