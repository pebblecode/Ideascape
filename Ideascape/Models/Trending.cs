using System.Collections.Generic;
using Ideascape.Data.Entities;

namespace Ideascape.Models
{
    public class Trending
    {
        public Idea TrendingIdea { get; set; }

        public IEnumerable<string> TrendingTags { get; set; }  
    }
}