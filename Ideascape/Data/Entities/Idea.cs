using System;
using System.Collections.Generic;

namespace Ideascape.Data.Entities
{
    public class Idea
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Premise { get; set; }
        public string Solution { get; set; }
        public ICollection<string> Tags { get; set; }
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
        public Guid Id { get; set; }
        public Guid ParticipantId { get; set; }
        public Guid IdeaId { get; set; }

        public ContributionType Type { get; set; }
        public DateTime Timestamp { get; set; }

        public enum ContributionType
        {
            Originator,
            Vote,
            Comment
        }
    }
}