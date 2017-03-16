using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Randomizer.Interfaces.ReferenceTypes;

namespace Randomizer.OutputTests.Tests.String
{
    public class StringExcludedOutputTest : StringOutputTest
    {
        public StringExcludedOutputTest(IRandomString randomString, ILogger logger) : base(randomString, logger)
        {
        }

        public override void PerformTest(params object[] parameters)
        {
            int length = int.Parse(parameters[0].ToString());

            var excludedCharacters = new List<char>();

            for (int i = 1; i < parameters.Length; i++)
            {
                excludedCharacters.Add((char)parameters[i]);
            }

            for (int i = 0; i < ExecutionTimes; i++)
            {
                string randomValue = randomString.GenerateValueWithout(length, excludedCharacters.ToArray());

                char[] randomValueArray = randomValue.ToCharArray();

                if (string.IsNullOrEmpty(randomValue))
                {
                    WrongResults.Add("NULL");
                }
                else if (randomValue.Length != length || randomValueArray.Any(item => excludedCharacters.Contains(item)) || randomValueArray.Any(item => item < Consts.FirstCharacterHex) || randomValueArray.Any(item => (item > Consts.LastCharacterHex)))
                {
                    WrongResults.Add(randomValue.ToString(CultureInfo.InvariantCulture));
                }
            }

            fileLogger.LogResult(WrongResults);
        }
    }
}
