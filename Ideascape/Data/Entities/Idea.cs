using System;
using System.Collections.Generic;

namespace Ideascape.Data.Entities
{
    public class Idea
    {
        private List<IdeaContribution> _contributions;

        public DateTime Timestamp { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Premise { get; set; }
        public string Solution { get; set; }
        public ICollection<string> Tags { get; set; }
        public IdeaStage Stage { get; set; }

        public List<IdeaContribution> Contributions
        {
            get { return (_contributions ?? (_contributions = new List<IdeaContribution>())); }
        }

        public enum IdeaStage
        {
            Inception,
            Expansion,
            Published,
            Kickstarted
        }
    }

    public class Participant
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int OfficeCode { get; set; }
        public int DepartmentCode { get; set; }
        public ICollection<string> Professions { get; set; }
    }

    public class IdeaContribution
    {
        public DateTime Timestamp { get; protected set; }
        public string Participant { get; protected set; }
    }

    public class IdeaVote : IdeaContribution
    {
        public IdeaVote()
        {
            Timestamp = DateTime.Now;
            Participant = "Joe Bloggs";
        }
    }

    public class IdeaComment : IdeaContribution
    {
        public string Comment { get; private set; }

        public IdeaComment(string comment)
        {
            Timestamp = DateTime.Now;
            Comment = comment;
            Participant = "Joe Bloggs";
        }
    }

    public class IdeaSolution : IdeaContribution
    {
        public string Solution { get; private set; }

        public IdeaSolution(string solution)
        {
            Timestamp = DateTime.Now;
            Solution = solution;
            Participant = "Joe Bloggs";
        }
    }
}