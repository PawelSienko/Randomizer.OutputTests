using System.Globalization;
using System.Linq;
using Randomizer.Interfaces.ReferenceTypes;

namespace Randomizer.OutputTests.Tests.String
{
    public class StringLowercaseOutputTests : StringOutputTests
    {
        public StringLowercaseOutputTests(IRandomString randomString, ILogger logger) : base(randomString, logger)
        {
        }

        public override void PerformTest(params object[] parameters)
        {
            const int FixedLength = 100;

            for (int i = 0; i < ExecutionTimes; i++)
            {
                string randomValue = randomString.GenerateLowerCaseValue(FixedLength);

                char[] randomValueArray = randomValue.ToCharArray();

                if (string.IsNullOrEmpty(randomValue))
                {
                    WrongResults.Add("NULL");
                }
                else if (randomValue.Length == FixedLength || randomValueArray.Any(item => item < Consts.FirstCharacterHex) || randomValueArray.Any(item => item > Consts.LastCharacterHex)
                    || randomValueArray.Any(char.IsUpper))
                {
                    WrongResults.Add(randomValue.ToString(CultureInfo.InvariantCulture));
                }
            }

            fileLogger.LogResult(WrongResults);
        }
    }
}
