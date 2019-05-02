using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmashPopularity.Data;
using SmashPopularity.Data.Models;
using SmashPopularity.Models.Forum;
using SmashPopularity.Models.Post;
using SmashPopularity.Models.Search;

namespace SmashPopularity.Controllers
{
    public class SearchController : Controller
    {
        private readonly IPost _postService;

        public SearchController(IPost postService)
        {
            _postService = postService;
        }

        public IActionResult Results(string searchQuery)
        {
            var posts = _postService.GetFilteredPosts(searchQuery);
            var areNoResults = 
                (!string.IsNullOrEmpty(searchQuery) && !posts.Any());

            var postListings = posts.Select(p => new PostListingModel
            {
                ID = p.ID,
                AuthorID = p.User.Id,
                AuthorName = p.User.UserName,
                AuthorRating = p.User.Rating,
                Title = p.Title,
                Created = p.Created,
                RepliesCount = p.Replies.Count(),
                Forum = BuildForumListing(p),
            });

            var model = new SearchResultModel
            {
                Posts = postListings,
                SearchQuery = searchQuery,
                EmptySearchResults = areNoResults,
            };

            return View(model);
        }

        private ForumListingModel BuildForumListing(Post post)
        {
            var forum = post.Forum;

            return new ForumListingModel
            {
                ID = forum.ID,
                ImageUrl = forum.ImageUrl,
                Name = forum.Title,
                Description = forum.Description,
            };
        }

        [HttpPost]
        public IActionResult Search(string searchQuery)
        {
            return RedirectToAction("Results", new { searchQuery });
        }
    }
}