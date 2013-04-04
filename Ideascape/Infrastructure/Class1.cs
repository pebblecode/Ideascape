
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ideascape.Infrastructure
{
    public static class Class1
    {
        public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> source)
        {
            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index/3)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }
    }
}