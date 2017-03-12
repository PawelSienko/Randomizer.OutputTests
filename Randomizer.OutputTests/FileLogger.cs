using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Common.Core.Validation;

namespace Randomizer.OutputTests
{
    public class FileLogger : ILogger
    {
        private readonly string fullPath;

        public FileLogger(string basePath, string fileName)
        {
            Validator.ValidateNullOrEmpty(basePath);
            Validator.ValidateNullOrEmpty(fileName);
            if (Directory.Exists(basePath) == false)
            {
                Directory.CreateDirectory(basePath);
            }

            fullPath = Path.Combine(basePath, fileName);
        }

        public void LogResult(IEnumerable<string> lines, string minValue = null, string maxValue = null)
        {
            if (string.IsNullOrEmpty(minValue) == false && string.IsNullOrEmpty(maxValue) == false)
            {
                var minAndMaxValueString = $"Min value - {minValue}, max value - {maxValue}, {Environment.NewLine}";
                File.AppendAllText(fullPath, minAndMaxValueString);
            }
            if (lines != null && lines.Any())
            {
                File.AppendAllLines(fullPath, lines);
            }
        }

        public void LogResult(string singleLine)
        {
            if (string.IsNullOrEmpty(singleLine) == false)
            {
                File.AppendAllText(fullPath, singleLine);
            }
        }
    }
}