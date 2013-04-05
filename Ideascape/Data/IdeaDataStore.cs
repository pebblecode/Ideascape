using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;

namespace Ideascape.Data
{
    using Entities;

    public class IdeaDataStore
    {
        public static IdeaDataStore Instance { get; set; }
        public List<Idea> Items { get; private set; }

        public IdeaDataStore()
        {
            try
            {
                using (var fs = Assembly.GetExecutingAssembly().GetManifestResourceStream("Ideascape.Data.ideas.json"))
                using (var sr = new StreamReader(fs))
                using (var jr = new JsonTextReader(sr))
                    Items = new JsonSerializer { TypeNameHandling = TypeNameHandling.All }.Deserialize<List<Idea>>(jr) ?? new List<Idea>();
            }
            catch
            {
                Items = new List<Idea>();
            }
        }

        public void Save()
        {
#if DEBUG
            using (var fs = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "ideas.json"), FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
            using (var sw = new StreamWriter(fs))
            using (var fw = new JsonTextWriter(sw) { Formatting = Formatting.Indented })
                new JsonSerializer { TypeNameHandling = TypeNameHandling.All }.Serialize(fw, Items);
#endif
        }
    }
}