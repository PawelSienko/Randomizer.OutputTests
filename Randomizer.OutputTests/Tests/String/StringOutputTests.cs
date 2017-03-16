using Common.Core.Validation;
using Randomizer.Interfaces.ReferenceTypes;
using Randomizer.OutputTests.Base;

namespace Randomizer.OutputTests.Tests.String
{
    public abstract class StringOutputTests : OutputTestBase<object>
    {
        protected readonly IRandomString randomString;

        protected StringOutputTests(IRandomString randomString, ILogger logger) : base(logger)
        {
            Validator.ValidateNull(randomString);
            this.randomString = randomString;
        }
    }
}
