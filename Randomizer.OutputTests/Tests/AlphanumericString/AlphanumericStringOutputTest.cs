using System;
using System.Linq;
using Common.Core.Validation;
using Randomizer.Interfaces.ReferenceTypes;
using Randomizer.OutputTests.Base;

namespace Randomizer.OutputTests.Tests.AlphanumericString
{
    public abstract class AlphanumericStringOutputTest : OutputTestBase<string>
    {
        protected readonly IRandomAlphanumericString RandomAlphanumericString;

        protected AlphanumericStringOutputTest(IRandomAlphanumericString randomAlphanumericString, ILogger logger)
            : base(logger)
        {
            Validator.ValidateNull(randomAlphanumericString);
            RandomAlphanumericString = randomAlphanumericString;
        }
        
        protected bool IsLetterOrDigit(string randomValue)
        {
            char[] randomValueAsArray = randomValue.ToCharArray();
            return randomValueAsArray.All(Char.IsLetterOrDigit);
        }
    }
}
