
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ideascape.Infrastructure
{
    using Data.Entities;

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

        public static string ToBootstrapLabelClass(this Idea.IdeaStage value)
        {
            switch (value)
            {
                case Idea.IdeaStage.Inception:
                    return "label-inverse";
                case Idea.IdeaStage.Expansion:
                    return "label-info";
                case Idea.IdeaStage.Published:
                    return "label-important";
                case Idea.IdeaStage.Kickstarted:
                    return "label-success";

                default:
                    return "";
            }
        }
    }
}