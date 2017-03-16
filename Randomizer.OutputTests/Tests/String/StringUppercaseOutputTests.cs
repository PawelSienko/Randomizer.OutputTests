using System.Globalization;
using System.Linq;
using Randomizer.Interfaces.ReferenceTypes;

namespace Randomizer.OutputTests.Tests.String
{
    public class StringUppercaseOutputTests : StringOutputTests
    {
        public StringUppercaseOutputTests(IRandomString randomString, ILogger logger) : base(randomString, logger)
        {
        }

        public override void PerformTest(params object[] parameters)
        {
            const int FixedLength = 74;

            for (int i = 0; i < ExecutionTimes; i++)
            {
                string randomValue = randomString.GenerateUpperCaseValue(FixedLength);

                char[] randomValueArray = randomValue.ToCharArray();

                if (string.IsNullOrEmpty(randomValue))
                {
                    WrongResults.Add("NULL");
                }
                else if (randomValue.Length == FixedLength || randomValueArray.Any(item => item < Consts.FirstCharacterHex) || randomValueArray.Any(item => item > Consts.LastCharacterHex)
                    || randomValueArray.Any(char.IsLower))
                {
                    WrongResults.Add(randomValue.ToString(CultureInfo.InvariantCulture));
                }
            }

            fileLogger.LogResult(WrongResults);
        }
    }
}
