using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmashPopularity.Data;
using SmashPopularity.Data.Models;
using SmashPopularity.Models;
using SmashPopularity.Models.Forum;
using SmashPopularity.Models.Home;
using SmashPopularity.Models.Post;

namespace SmashPopularity.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPost _postService;

        public HomeController(IPost postService)
        {
            _postService = postService;
        }

        public IActionResult Index()
        {
            var model = BuildHomeIndexModel();
            return View(model);
        }

        private HomeIndexModel BuildHomeIndexModel()
        {
            var latestPosts = _postService.GetLatestPosts(10);
            var posts = latestPosts.Select(p => new PostListingModel
            {
                ID = p.ID,
                Title = p.Title,
                AuthorName = p.User.UserName,
                AuthorID = p.User.Id,
                AuthorRating = p.User.Rating,
                DatePosted = p.Created.ToString(),
                RepliesCount = p.Replies.Count(),
                Forum = GetForumListingForPost(p),
            });

            return new HomeIndexModel
            {
                LatestPosts = posts,
                SearchQuery = "",
            };
        }

        private ForumListingModel GetForumListingForPost(Post p)
        {
            var forum = p.Forum;
            return new ForumListingModel
            {
                Name = forum.Title,
                ImageUrl = forum.ImageUrl,
                ID = forum.ID,
            };
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
