using System;
using Common.Core.Validation;
using Microsoft.Practices.Unity;
using Randomizer.Interfaces.ReferenceTypes;
using Randomizer.Interfaces.ValueTypes;
using Randomizer.OutputTests.Base;
using Randomizer.OutputTests.Tests.AlphanumericChar;
using Randomizer.OutputTests.Tests.AlphanumericString;
using Randomizer.OutputTests.Tests.DateTime;
using Randomizer.OutputTests.Tests.Decimal;
using Randomizer.OutputTests.Tests.Double;
using Randomizer.OutputTests.Tests.Float;
using Randomizer.OutputTests.Tests.Integer;
using Randomizer.OutputTests.Tests.Long;
using Randomizer.OutputTests.Tests.Short;
using Randomizer.OutputTests.Tests.String;

namespace Randomizer.OutputTests.Unity
{
    public class UnityOutputTests : UnityBase
    {
        public UnityOutputTests(UnityContainer unityContainer) : base(unityContainer)
        {
            Validator.ValidateNull(unityContainer);
        }

        public override void RegisterTypes()
        {
            RegisterOutputTest(typeof(OutputTestBase<float>), typeof(FloatInRangeOutputTest), typeof(IRandomFloat), "floatInRange",
               "floatInRangeLog");
            RegisterOutputTest(typeof(OutputTestBase<float>), typeof(FloatPositiveValueOutputTest), typeof(IRandomFloat), "floatPositive",
                "positiveFloatLog");
            RegisterOutputTest(typeof(OutputTestBase<float>), typeof(FloatNegativeValueOutputTest), typeof(IRandomFloat), "floatNegative",
                "negativeFloatLog");

            RegisterOutputTest(typeof(OutputTestBase<int>), typeof(IntegerInRangeOutputTest), typeof(IRandomInteger), "integerInRange",
                "intInRangeLog");
            RegisterOutputTest(typeof(OutputTestBase<int>), typeof(IntegerPositiveValueOutputTest), typeof(IRandomInteger), "integerPositive",
                "intPositiveLog");
            RegisterOutputTest(typeof(OutputTestBase<int>), typeof(IntegerNegativeValueOutputTest), typeof(IRandomInteger), "integerNegative",
                "intNegativeLog");

            RegisterOutputTest(typeof(OutputTestBase<decimal>), typeof(DecimalInRangeOutputTest), typeof(IRandomDecimal), "decimalInRange",
                "decimalInRangeLog");
            RegisterOutputTest(typeof(OutputTestBase<decimal>), typeof(DecimalPositiveValueOutputTest), typeof(IRandomDecimal), "decimalPositive",
                "decimalPositiveLog");
            RegisterOutputTest(typeof(OutputTestBase<decimal>), typeof(DecimalNegativeValueOutputTest), typeof(IRandomDecimal), "decimalNegative",
                "decimalNegativeLog");

            RegisterOutputTest(typeof(OutputTestBase<long>), typeof(LongInRangeOutputTest), typeof(IRandomLong), "longInRangte",
               "longInRangeLog");
            RegisterOutputTest(typeof(OutputTestBase<long>), typeof(LongPositiveValueOutputTest), typeof(IRandomLong), "longPositive",
                "longPositiveLog");
            RegisterOutputTest(typeof(OutputTestBase<long>), typeof(LongNegativeValueOutputTest), typeof(IRandomLong), "longNegative",
                "longNegativeLog");

            RegisterOutputTest(typeof(OutputTestBase<short>), typeof(ShortInRangeOutputTest), typeof(IRandomShort), "shortInRange",
               "shortInRangeLog");
            RegisterOutputTest(typeof(OutputTestBase<short>), typeof(ShortPositiveValueOutputTest), typeof(IRandomShort), "shortPositive",
                "shortPositiveLog");
            RegisterOutputTest(typeof(OutputTestBase<short>), typeof(ShortNegativeValueOutputTest), typeof(IRandomShort), "shortNegative",
                "shortNegativeLog");

            RegisterOutputTest(typeof(OutputTestBase<double>), typeof(DoubleInRangeOutputTest), typeof(IRandomDouble), "doubleInRange",
               "doubleInRangeLog");
            RegisterOutputTest(typeof(OutputTestBase<double>), typeof(DoublePositiveValueOutputTest), typeof(IRandomDouble), "doublePositive",
                "doublePositiveLog");
            RegisterOutputTest(typeof(OutputTestBase<double>), typeof(DoubleNegativeValueOutputTest), typeof(IRandomDouble), "doubleNegative",
                "doubleNegativeLog");

            RegisterOutputTest(typeof(OutputTestBase<DateTime>), typeof(DateTimeInRangeOutputTest), typeof(IRandomDateTime), "dateTimeInRange",
               "dateTimeInRangeLog");
            RegisterOutputTest(typeof(OutputTestBase<DateTime>), typeof(DateTimePositiveValueOutputTest), typeof(IRandomDateTime), "dateTimePositive",
                "dateTimePositiveLog");
            RegisterOutputTest(typeof(OutputTestBase<DateTime>), typeof(DateTimeNegativeValueOutputTest), typeof(IRandomDateTime), "dateTimeNegative",
                "dateTimeNegativeLog");

            RegisterOutputTest(typeof(AlphanumericStringOutputTest), typeof(AlphanumericStringDefaultLengthOutputTest), typeof(IRandomAlphanumericString), "alphanumericStringDefault",
              "alphanumericStringDefaultLengthLog");
            RegisterOutputTest(typeof(AlphanumericStringOutputTest), typeof(AlphanumericStringFixedLengthOutputTest), typeof(IRandomAlphanumericString), "alphanumericStringFixed",
                "alphanumericStringFixedLengthLog");
            RegisterOutputTest(typeof(AlphanumericStringOutputTest), typeof(AlphanumericStringLowercaseOutputTest), typeof(IRandomAlphanumericString), "alphanumericStringLower",
                "alphanumericStringLowercaseLog");
            RegisterOutputTest(typeof(AlphanumericStringOutputTest), typeof(AlphanumericStringUppercaseOutputTest), typeof(IRandomAlphanumericString), "alphanumericStringUpper",
                "alphanumericStringUppercaseLog");
            RegisterOutputTest(typeof(AlphanumericStringOutputTest), typeof(AlphanumericStringApartFromOutputTest), typeof(IRandomAlphanumericString), "alphanumericStringExcluded",
                "alphanumericStringExcludedLog");

            RegisterOutputTest(typeof(StringOutputTest), typeof(StringDefaultLengthOutputTest), typeof(IRandomString), "stringDefault",
              "stringDefaultLengthLog");
            RegisterOutputTest(typeof(StringOutputTest), typeof(StringFixedLengthOutputTest), typeof(IRandomString), "stringFixed",
                "stringFixedLengthLog");
            RegisterOutputTest(typeof(StringOutputTest), typeof(StringLowercaseOutputTest), typeof(IRandomString), "stringLower",
                "stringLowercaseLog");
            RegisterOutputTest(typeof(StringOutputTest), typeof(StringUppercaseOutputTest), typeof(IRandomString), "stringUpper",
                "stringUppercaseLog");
            RegisterOutputTest(typeof(StringOutputTest), typeof(StringApartFromOutputTest), typeof(IRandomString), "stringExcluded",
                "stringExcludedLog");

            RegisterOutputTest(typeof(AlphanumericCharOutputTest), typeof(AlphanumericRandomCharOutputTest), typeof(IRandomCharacter), "charDefault",
              "randomCharacterLog");
            RegisterOutputTest(typeof(AlphanumericCharOutputTest), typeof(AlphanumericCharInRangeOutputTest), typeof(IRandomCharacter), "charInRange",
                "randomCharacterInRangeLog");
        }

        private  void RegisterOutputTest(Type baseType, Type concreteType, Type randomInputInterface,
            string registerName, string loggerRegisterName)
        {
            unityContainer.RegisterType(baseType, concreteType, registerName,
                new InjectionConstructor(new ResolvedParameter(randomInputInterface)
                    , new ResolvedParameter(typeof(ILogger), loggerRegisterName)));
        }
    }
}
