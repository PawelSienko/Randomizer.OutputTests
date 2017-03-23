using Common.Core.Validation;
using Microsoft.Practices.Unity;

namespace Randomizer.OutputTests.Unity
{
    public class UnityLoggers : UnityBase
    {
        // ReSharper disable once InconsistentNaming
        private readonly string basePath;
        
        public UnityLoggers(UnityContainer unityContainer, string basePath)
            : base(unityContainer)
        {
            Validator.ValidateNullOrEmpty(basePath);
            Validator.ValidateNull(unityContainer);
            this.basePath = basePath;
        }

        public override void RegisterTypes()
        {
            RegisterLogger("floatInRangeLog", "floatInRange.log", basePath);
            RegisterLogger("positiveFloatLog", "positiveFloat.log", basePath);
            RegisterLogger("negativeFloatLog", "negativeFloat.log", basePath);

            RegisterLogger("intInRangeLog", "intInRange.log", basePath);
            RegisterLogger("intPositiveLog", "intPositive.log", basePath);
            RegisterLogger("intNegativeLog", "intNegative.log", basePath);

            RegisterLogger("decimalInRangeLog", "decimalInRange.log", basePath);
            RegisterLogger("decimalPositiveLog", "decimalPositive.log", basePath);
            RegisterLogger("decimalNegativeLog", "decimalNegative.log", basePath);

            RegisterLogger("longInRangeLog", "longInRange.log", basePath);
            RegisterLogger("longPositiveLog", "longPositive.log", basePath);
            RegisterLogger("longNegativeLog", "longNegative.log", basePath);

            RegisterLogger("shortInRangeLog", "shortInRange.log", basePath);
            RegisterLogger("shortPositiveLog", "shortPositive.log", basePath);
            RegisterLogger("shortNegativeLog", "shortNegative.log", basePath);

            RegisterLogger("doubleInRangeLog", "doubleInRange.log", basePath);
            RegisterLogger("doublePositiveLog", "doublePositive.log", basePath);
            RegisterLogger("doubleNegativeLog", "doubleNegative.log", basePath);

            RegisterLogger("dateTimeInRangeLog", "dateTimeInRange.log", basePath);
            RegisterLogger("dateTimePositiveLog", "dateTimePositive.log", basePath);
            RegisterLogger("dateTimeNegativeLog", "dateTimeNegative.log", basePath);

            RegisterLogger("alphanumericStringDefaultLengthLog", "alphanumericStringDefaultLength.log", basePath);
            RegisterLogger("alphanumericStringFixedLengthLog", "alphanumericStringFixedLength.log", basePath);
            RegisterLogger("alphanumericStringLowercaseLog", "alphanumericStringLowercase.log", basePath);
            RegisterLogger("alphanumericStringUppercaseLog", "alphanumericStringUppercase.log", basePath);
            RegisterLogger("alphanumericStringExcludedLog", "alphanumericStringExcluded.log", basePath);

            RegisterLogger("stringDefaultLengthLog", "stringDefaultLength.log", basePath);
            RegisterLogger("stringFixedLengthLog", "stringFixedLength.log", basePath);
            RegisterLogger("stringLowercaseLog", "stringLowercase.log", basePath);
            RegisterLogger("stringUppercaseLog", "stringUppercase.log", basePath);
            RegisterLogger("stringExcludedLog", "stringExcluded.log", basePath);

            RegisterLogger("randomCharacterLog", "randomCharacter.log", basePath);
            RegisterLogger("randomCharacterInRangeLog", "randomCharacter.log", basePath);
        }
        private void RegisterLogger(string registerName, string logFileName, string basePath)
        {
            unityContainer.RegisterType<ILogger, FileLogger>(registerName, new InjectionConstructor(basePath, logFileName));
        }

    }
}
