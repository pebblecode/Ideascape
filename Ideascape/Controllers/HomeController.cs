﻿using System;
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
            IdeaDataStore.Instance.Items.Add(new Idea
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name,
                    Premise = model.Premise,
                    Solution = model.Solution,
                    Tags = model.Tags
                });

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
    }
}

