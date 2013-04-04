using System;
using System.Collections.Generic;

namespace Ideascape.Models
{
    public class NewIdeaSubmission
    {
        public string Name { get; set; }

        public string Premise { get; set; }

        public string Solution { get; set; }

        public ICollection<string> Tags { get; set; }
    }
}