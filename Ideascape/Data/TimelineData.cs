using System;
using Newtonsoft.Json;

namespace Ideascape.Data
{
    using System.Collections.Generic;
    using System.IO;

    public class TimelineData
    {
        public void foo()
        {
            using (var ms = new MemoryStream())
            using (var sw = new StreamWriter(ms))
            using (var tw = new JsonTextWriter(sw) { Formatting = Formatting.Indented })
                new JsonSerializer()
                    .Serialize(tw,
                               new TimelineContainer(
                                   "This is our headline", "default", DateTime.Now,
                                   "Hello world",
                                   new Asset(
                                       "http://2.bp.blogspot.com/-dxJbW0CG8Zs/TmkoMA5-cPI/AAAAAAAAAqw/fQpsz9GpFdo/s1600/voyage-dans-la-lune-1902-02-g.jpg",
                                       "", ""))
                                   {
                                       date =
                                           {
                                               new Date(new DateTime(2013, 4, 4), "headline", "text", new Asset("http://maps.google.com/maps?q=New+York,+NY&hl=en&ll=40.721242,-73.987427&spn=0.164187,0.365295&sll=40.722673,-73.993263&sspn=0.082092,0.182648&oq=New+Y&hnear=New+York&t=m&z=11", "", ""))
                                           }
                                   });
        }

        public class TimelineContainer
        {
            public string headline;
            public string type;
            public string startDate;
            public string text;
            public Asset asset;
            public List<Date> date;

            public TimelineContainer(string headline, string type, DateTime startDate, string text, Asset asset)
            {
                this.headline = headline;
                this.type = type;
                this.startDate = startDate.ToString("yyyy,MM,dd");
                this.text = text;
                this.asset = asset;
            }
        }

        public class Date
        {
            public string startDate, headline, text;
            public Asset asset;

            public Date(DateTime startDate, string headline, string text, Asset asset)
            {
                this.startDate = startDate.ToString("yyyy,MM,dd");
                this.headline = headline;
                this.text = text;
                this.asset = asset;
            }
        }

        public class Asset
        {
            public string media, credit, caption;

            public Asset(string media, string credit, string caption)
            {
                this.media = media;
                this.credit = credit;
                this.caption = caption;
            }
        }
    }
}