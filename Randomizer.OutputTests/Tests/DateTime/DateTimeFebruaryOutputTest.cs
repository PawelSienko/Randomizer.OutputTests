using Common.Core.Validation;
using Randomizer.Interfaces.ValueTypes;
using Randomizer.OutputTests.Base;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer.OutputTests.Tests.DateTime
{
    public class DateTimeFebruaryOutputTest : OutputTestBase<System.DateTime>
    {
        private readonly IRandomDateTime randomDateTime;

        public DateTimeFebruaryOutputTest(IRandomDateTime randomDateTime, ILogger logger)
            : base(logger)
        {
            Validator.ValidateNull(randomDateTime);
            this.randomDateTime = randomDateTime;
        }

        public override void PerformTest(params System.DateTime[] parameters)
        {
            ValidateConfitions(parameters);
            System.DateTime randomValue = default(System.DateTime);

            for (int i = 0; i < ExecutionTimes; i++)
            {
                try
                {
                    randomValue = randomDateTime.GenerateValue();
                }
                catch
                {
                    WrongResults.Add(randomValue.ToString(CultureInfo.InvariantCulture));
                }
            }
            if (WrongResults.Count > 0)
            {
                fileLogger.LogResult(WrongResults);
            }
        }
    }
}
