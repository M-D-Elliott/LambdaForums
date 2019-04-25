using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmashPopularity.Data;
using SmashPopularity.Data.Models;
using SmashPopularity.Models.Forum;

namespace SmashPopularity.Controllers
{
    public class ForumController : Controller
    {
        private readonly IForum _forumService;

        public ForumController(IForum forumService)
        {
            _forumService = forumService;
        }

        public IActionResult Index()
        {
            var forums = _forumService.GetAll()
                .Select(f => new ForumListingModel {
                    ID = f.ID,
                    Name = f.Title,
                    Description = f.Description,
                });

            var model = new ForumIndexModel
            {
                ForumList = forums,
            };

            return View(model);
        }
    }
}