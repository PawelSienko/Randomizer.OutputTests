using System.Globalization;
using Randomizer.Interfaces.ReferenceTypes;

namespace Randomizer.OutputTests.Tests.AlphanumericString
{
    public class AlphanumericStringDefaultLengthOutputTest : AlphanumericStringOutputTest
    {
        public AlphanumericStringDefaultLengthOutputTest(IRandomAlphanumericString randomAlphanumericString, ILogger logger)
            : base(randomAlphanumericString, logger)
        {
        }

        public override void PerformTest(params string[] parameters)
        {
            for (int i = 0; i < ExecutionTimes; i++)
            {
                string randomValue = RandomAlphanumericString.GenerateValue();

                if (string.IsNullOrEmpty(randomValue))
                {
                    WrongResults.Add("NULL");
                }
                else if (randomValue.Length != 25 || IsLetterOrDigit(randomValue) == false)
                {
                    WrongResults.Add(randomValue.ToString(CultureInfo.InvariantCulture));
                }
            }

            fileLogger.LogResult(WrongResults);
        }
    }
}
