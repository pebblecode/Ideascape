using System;
using System.Linq;
using System.Web.Mvc;

namespace Ideascape.Controllers
{
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
            var ids = new IdeaDataStore();

            ids.Items.Add(new Idea
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                Premise = model.Premise,
                Solution = model.Solution,
                Tags = model.Tags
            });

            ids.Save();

            return View(model);
        }

        public ActionResult MyIdeas()
        {
            return View();
        }

        public ActionResult Trending()
        {
            var ids = new IdeaDataStore();

            var trending = new Trending
                {
                    TrendingIdea = ids.Items
                                      .OrderBy(i => Guid.NewGuid())
                                      .Where(i => i.Stage != Idea.IdeaStage.Inception)
                                      .Take(5),
                    TrendingTags = ids.Items
                                      .SelectMany(i => i.Tags).Distinct()
                                      .OrderBy(i => Guid.NewGuid()).Take(5)
                };

            return View(trending);
        }
    }
}
