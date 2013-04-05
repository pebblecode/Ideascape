using System;
using System.Linq;
using System.Web.Mvc;

namespace Ideascape.Controllers
{
    using System.Collections.Generic;
    using Data;
    using Data.Entities;
    using Models;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NewIdea()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewIdea(NewIdeaSubmission model)
        {
            IdeaDataStore.Instance.Items.Add(new Idea
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name,
                    Premise = model.Premise,
                    Solution = model.Solution,
                    Tags = model.Tags
                });

            IdeaDataStore.Instance.Save();

            return View("IdeaSubmitted");
        }

        public ActionResult MyIdeas()
        {
            return View();
        }

        public ActionResult Trending(string tag)
        {
            Func<Idea, bool> ideaSelector;
            if (string.IsNullOrWhiteSpace(tag))
            {
                ideaSelector = i => i.Stage != Idea.IdeaStage.Inception;
            }
            else
            {
                ideaSelector = i => i.Tags.Contains(tag);
            }

            var trending = new Trending
                {
                    TrendingIdea = IdeaDataStore.Instance.Items
                                      .OrderBy(i => Guid.NewGuid())
                                      .Where(ideaSelector).Take(5),
                    TrendingTags = IdeaDataStore.Instance.Items
                                      .SelectMany(i => i.Tags).Distinct()
                                      .OrderBy(i => Guid.NewGuid()).Take(5)
                };

            return View(trending);
        }

        public ActionResult Timeline()
        {
            return View();
        }

        public ActionResult ProposeSolution(ProposeSolution model)
        {
            var idea = IdeaDataStore.Instance.Items.Single(i => i.Id == model.IdeaId);
            idea.Contributions.Add(new IdeaSolution(model.Solution));
            IdeaDataStore.Instance.Save();

            return View("MyIdeas");
        }

        public ActionResult HotSeatItem(string @class = "item")
        {
            ViewBag.ItemClass = @class;
            var hotSeatIdea = new[] {true, false}.OrderBy(i => Guid.NewGuid()).First();
            if (hotSeatIdea)
            {
                return PartialView("_HotseatIdea", IdeaDataStore.Instance.Items.OrderBy(i=>Guid.NewGuid()).First());

            }
            return PartialView("_HotseatSolution", IdeaDataStore.Instance.Items.OrderBy(i=>Guid.NewGuid()).First());
        }

        public ActionResult HotSeat()
        {
            ViewBag.Title = "Hot Seat";

            return View();
        }

        public ActionResult HotSeatItemActive()
        {
            return HotSeatItem("item active");
        }

        public JsonResult TimelineData()
        {
            var data = new
                {
                    timeline = new TimelineData.TimelineContainer(
                        "This is our headline", "default", DateTime.Now,
                        "Hello world",
                        new TimelineData.Asset(
                            "http://2.bp.blogspot.com/-dxJbW0CG8Zs/TmkoMA5-cPI/AAAAAAAAAqw/fQpsz9GpFdo/s1600/voyage-dans-la-lune-1902-02-g.jpg",
                            "", ""))
                };


            data.timeline.date = new List<TimelineData.Date>();
            foreach (var contribution in IdeaDataStore.Instance.Items.SelectMany(i => i.Contributions))
            {
                data.timeline.date.Add(new TimelineData.Date(contribution.Timestamp, contribution.Participant + " proposed a solution", "", new TimelineData.Asset(
                                            "http://maps.google.com/maps?q=New+York,+NY&hl=en&ll=40.721242,-73.987427&spn=0.164187,0.365295&sll=40.722673,-73.993263&sspn=0.082092,0.182648&oq=New+Y&hnear=New+York&t=m&z=11",
                                            "", "")));
            }



                //        {
                //            date = new List<TimelineData.Date>
                //                {
                //                    new TimelineData.Date(
                //                        new DateTime(2013, 4, 1), "headline1", "text",
                //                        new TimelineData.Asset(
                //                            "http://maps.google.com/maps?q=New+York,+NY&hl=en&ll=40.721242,-73.987427&spn=0.164187,0.365295&sll=40.722673,-73.993263&sspn=0.082092,0.182648&oq=New+Y&hnear=New+York&t=m&z=11",
                //                            "", "")),

                //                    new TimelineData.Date(
                //                        new DateTime(2013, 4, 2), "headline2", "text",
                //                        new TimelineData.Asset(
                //                            "http://maps.google.com/maps?q=New+York,+NY&hl=en&ll=40.721242,-73.987427&spn=0.164187,0.365295&sll=40.722673,-73.993263&sspn=0.082092,0.182648&oq=New+Y&hnear=New+York&t=m&z=11",
                //                            "", "")),

                //                    new TimelineData.Date(
                //                        new DateTime(2013, 4, 3), "headline3", "text",
                //                        new TimelineData.Asset(
                //                            "http://maps.google.com/maps?q=New+York,+NY&hl=en&ll=40.721242,-73.987427&spn=0.164187,0.365295&sll=40.722673,-73.993263&sspn=0.082092,0.182648&oq=New+Y&hnear=New+York&t=m&z=11",
                //                            "", "")),

                //                    new TimelineData.Date(
                //                        new DateTime(2013, 4, 4), "headline4", "text",
                //                        new TimelineData.Asset(
                //                            "http://maps.google.com/maps?q=New+York,+NY&hl=en&ll=40.721242,-73.987427&spn=0.164187,0.365295&sll=40.722673,-73.993263&sspn=0.082092,0.182648&oq=New+Y&hnear=New+York&t=m&z=11",
                //                            "", "")),

                //                    new TimelineData.Date(
                //                        new DateTime(2013, 4, 5), "headline5", "text",
                //                        new TimelineData.Asset(
                //                            "http://maps.google.com/maps?q=New+York,+NY&hl=en&ll=40.721242,-73.987427&spn=0.164187,0.365295&sll=40.722673,-73.993263&sspn=0.082092,0.182648&oq=New+Y&hnear=New+York&t=m&z=11",
                //                            "", ""))
                //                }
                //        }
                //};


            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}

