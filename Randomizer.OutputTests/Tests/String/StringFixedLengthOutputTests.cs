using System.Globalization;
using System.Linq;
using Randomizer.Interfaces.ReferenceTypes;

namespace Randomizer.OutputTests.Tests.String
{
    public class StringFixedLengthOutputTests : StringOutputTests
    {
        public StringFixedLengthOutputTests(IRandomString randomString, ILogger logger) : base(randomString, logger)
        {
        }

        public override void PerformTest(params object[] parameters)
        {
            const int FixedLength = 50;

            for (int i = 0; i < ExecutionTimes; i++)
            {
                string randomValue = randomString.GenerateValue(lenght: FixedLength);

                char[] randomValueArray = randomValue.ToCharArray();

                if (string.IsNullOrEmpty(randomValue))
                {
                    WrongResults.Add("NULL");
                }
                else if (randomValue.Length == FixedLength || randomValueArray.Any(item => item < Consts.FirstCharacterHex) || randomValueArray.Any(item => item > Consts.LastCharacterHex))
                {
                    WrongResults.Add(randomValue.ToString(CultureInfo.InvariantCulture));
                }
            }

            fileLogger.LogResult(WrongResults);
        }
    }
}
