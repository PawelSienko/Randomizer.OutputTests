using System.Globalization;
using System.Linq;
using Randomizer.Interfaces.ReferenceTypes;

namespace Randomizer.OutputTests.Tests.String
{
    public class StringDefaultLengthOutputTest : StringOutputTest
    {
        public StringDefaultLengthOutputTest(IRandomString randomString, ILogger logger) : base(randomString, logger)
        {
        }

        public override void PerformTest(params object[] parameters)
        {
            for (int i = 0; i < ExecutionTimes; i++)
            {
                string randomValue = randomString.GenerateValue();

                char[] randomValueArray = randomValue.ToCharArray();

                if (string.IsNullOrEmpty(randomValue))
                {
                    WrongResults.Add("NULL");
                }
                else if (randomValue.Length != 25 || randomValueArray.Any(item => item < Consts.FirstCharacterHex) || randomValueArray.Any(item => (item > Consts.LastCharacterHex)))
                {
                    WrongResults.Add(randomValue.ToString(CultureInfo.InvariantCulture));
                }
            }

            fileLogger.LogResult(WrongResults);
        }
    }
}
