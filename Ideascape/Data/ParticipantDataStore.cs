using System;
using System.Collections.Generic;

namespace Ideascape.Data
{
    using Entities;

    public class ParticipantDataStore
    {
        public IEnumerable<Participant> Get()
        {
            return new[]
                {
                    new Participant
                        {
                            Id = Guid.NewGuid(),
                            Name = "John Doe",
                            OfficeCode = 100,
                            DepartmentCode = 101,
                            Professions = { "Chemistry", "Brain Chemistry" }
                        },
                    new Participant
                        {
                            Id = Guid.NewGuid(),
                            Name = "Joe Bloggs",
                            OfficeCode = 100,
                            DepartmentCode = 101,
                            Professions = { "Biology", "Brain Chemistry" }
                        },
                    new Participant
                        {
                            Id = Guid.NewGuid(),
                            Name = "Steve Bobs",
                            OfficeCode = 100,
                            DepartmentCode = 101,
                            Professions = { "Financier", "Economics" }
                        },

                    new Participant
                        {
                            Id = Guid.NewGuid(),
                            Name = "Bill Nomates",
                            OfficeCode = 100,
                            DepartmentCode = 102,
                            Professions = { "Physics", "Atomic Science" }
                        },
                    new Participant
                        {
                            Id = Guid.NewGuid(),
                            Name = "Jeff Capes",
                            OfficeCode = 200,
                            DepartmentCode = 201,
                            Professions = { "Biology", "Economics" }
                        },
                };
        }
    }
}