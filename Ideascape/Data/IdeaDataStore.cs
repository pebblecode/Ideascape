using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ideascape.Data
{
    using Entities;

    public class IdeaDataStore
    {
        public List<Idea> Items { get; private set; }

        public IdeaDataStore()
        {
            try
            {
                using (var fs = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data", "ideas.json"), FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
                using (var sr = new StreamReader(fs))
                using (var jr = new JsonTextReader(sr))
                    Items = new JsonSerializer().Deserialize<List<Idea>>(jr) ?? new List<Idea>();
            }
            catch
            {
                Items = new List<Idea>();
            }
        }

        public void Save()
        {
            using (var fs = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data", "ideas.json"), FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
            using (var sw = new StreamWriter(fs))
            using (var fw = new JsonTextWriter(sw) { Formatting = Formatting.Indented })
                new JsonSerializer().Serialize(fw, Items);
        }
    }
}