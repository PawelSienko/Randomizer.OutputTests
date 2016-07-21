﻿using System.Globalization;
using System.Linq;
using Randomizer.Interfaces.ReferenceTypes;

namespace Randomizer.OutputTests.Tests.AlphanumericString
{
    public class AlphanumericStringUppercaseOutputTest : AlphanumericStringOutputTest
    {
        public AlphanumericStringUppercaseOutputTest(IRandomAlphanumericString randomAlphanumericString, ILogger fileLogger)
            : base(randomAlphanumericString, fileLogger)
        {
        }

        public override void PerformTest(object min = null, object max = null)
        {
            for (int i = 0; i < ExecutionTimes; i++)
            {
                string randomValue = randomAlphanumericString.GenerateUpperCaseValue(100);
                if (string.IsNullOrEmpty(randomValue))
                {
                    wrongResults.Add("NULL");
                }
                else if (randomValue.Any(char.IsLower) || IsLetterOrDigit(randomValue) == false)
                {
                    wrongResults.Add(randomValue.ToString(CultureInfo.InvariantCulture));
                }
            }
            FileLogger.LogResult(wrongResults);
        }
    }
}