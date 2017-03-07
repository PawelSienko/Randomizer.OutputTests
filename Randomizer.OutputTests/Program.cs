using System;
using System.Configuration;
using System.IO;
using System.Linq;
using Microsoft.Practices.Unity;
using Randomizer.OutputTests.Base;
using Randomizer.OutputTests.TestManagers;
using Randomizer.OutputTests.Unity;

namespace Randomizer.OutputTests
{
    class Program
    {
        private static IConsoleManager consoleManager;

        static Program()
        {
            Bootstrap();
        }

        static void Main()
        {
            consoleManager.PrintHeader();

            RemovePreviousErrorFilesIfExist();
            Console.ForegroundColor = ConsoleColor.Green;
            InvokeTests<AlphanumericCharTestManager, char>("Alphanumeric char", 'g', 'w');
            InvokeTests<AlphanumericCharTestManager, char>("Alphanumeric char", 'F', 'L');
            InvokeTests<AlphanumericCharTestManager, char>("Alphanumeric char", 'A', 'c');
            InvokeTests<AlphanumericCharTestManager, char>("Alphanumeric char", 'c', '4');
            InvokeTests<AlphanumericCharTestManager, char>("Alphanumeric char", 'A', '1');
            InvokeTests<IntegerTestManager, int>("integer", 10, 20);
            InvokeTests<IntegerTestManager, int>("integer", int.MinValue, int.MaxValue);
            InvokeTests<IntegerTestManager, int>("integers", -70411, 543);
            InvokeTests<FloatTestManager, float>("float", 1.9023f, 1.924565f);
            InvokeTests<FloatTestManager, float>("float", -7001.9023f, 21.924f);
            InvokeTests<FloatTestManager, float>("float", float.MinValue, float.MaxValue);
            InvokeTests<DecimalTestManager, decimal>("decimal", 1.2234200045m, 1.32331990989m);
            InvokeTests<DecimalTestManager, decimal>("decimal", -1.2234200045m, 500.32331990989m);
            InvokeTests<DecimalTestManager, decimal>("decimal", decimal.MinValue, decimal.MaxValue);
            InvokeTests<LongTestManager, long>("long", -4294967296L, 500000000L);
            InvokeTests<LongTestManager, long>("long", -4294967297L, -4294967295L);
            InvokeTests<LongTestManager, long>("long", 4294967296L, 4294967297L);
            InvokeTests<LongTestManager, long>("long", long.MinValue, long.MaxValue);
            InvokeTests<ShortTestManager, short>("short", (short)-12, (short)15);
            InvokeTests<ShortTestManager, short>("short", (short)-100, (short)-15);
            InvokeTests<ShortTestManager, short>("short", (short)0, (short)15);
            InvokeTests<ShortTestManager, short>("short", short.MinValue, short.MaxValue);
            InvokeTests<DoubleTestManager, double>("double", double.MinValue, double.MaxValue);
            InvokeTests<DoubleTestManager, double>("double", -1022342D, 11D);
            InvokeTests<DoubleTestManager, double>("double", -1022342D, -11D);
            InvokeTests<DoubleTestManager, double>("double", 1022342D, 1123421312D);
            InvokeTests<DateTimeTestManager, DateTime>("dateTime", DateTime.MinValue.AddSeconds(1), DateTime.MaxValue.AddSeconds(-1));
            InvokeTests<DateTimeTestManager, DateTime>("dateTime", DateTime.Now.AddHours(-10), DateTime.Now.AddDays(2));
            InvokeTests<DateTimeTestManager, DateTime>("dateTime", DateTime.Now.AddSeconds(-1), DateTime.Now.AddSeconds(1));
            InvokeTests<AlphanumericStringTestManager, string>("alphanumeric string");

            consoleManager.PrintFooter();
            
            NotifyIfErrors();
        }

        private static void RemovePreviousErrorFilesIfExist()
        {
            var errorLogsPath = GetErrorLogPath();
            var files = Directory.GetFiles(errorLogsPath);
            if (files.Any())
            {
                Directory.Delete(errorLogsPath, true);
                Directory.CreateDirectory(errorLogsPath);
            }
        }

        private static void NotifyIfErrors()
        {
            var errorLogsPath = GetErrorLogPath();
            if (Directory.GetFiles(errorLogsPath).Any())
            {
                consoleManager.PrintErrorMsg("Some errors occured. Please check location " + errorLogsPath);
            }
        }

        private static string GetErrorLogPath()
        {
            return ConfigurationManager.AppSettings["basePath"];
        }
        private static void InvokeTests<T, TInput>(string testName, params TInput[] parameters)
            where T : TestManagerBase<TInput>
        {
            consoleManager.PrintLine($"Start {testName} tests..............");
            UnityConfiguration.Get.Resolve<T>().ExecuteAll(parameters);
            consoleManager.PrintLine($"Stop {testName} tests..............");
        }

        private static void Bootstrap()
        {
            UnityConfiguration.Configure();
            consoleManager = UnityConfiguration.Get.Resolve<IConsoleManager>();
        }

    }
}
