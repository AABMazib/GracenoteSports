using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GracenoteSportsApi.Core.SoccerMatches.Csv
{
    public class CsvConverter<T>
    {
        public IEnumerable<T> Convert(string path, Func<string, T> formetter)
        {
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            return File.ReadAllLines(Path.Combine(basePath, path))
            .Skip(1)
            .Select(formetter)
            .ToList();
        }
    }
}