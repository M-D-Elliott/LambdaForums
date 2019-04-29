using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmashPopularity.Data;
using SmashPopularity.Data.Models;
using SmashPopularity.Models.Post;
using SmashPopularity.Models.Reply;

namespace SmashPopularity.Controllers
{
    public class PostController : Controller
    {
        private readonly IPost _postService;

        public PostController(IPost postService)
        {
            _postService = postService;
        }

        public IActionResult Index(int id)
        {
            var post = _postService.GetByID(id);

            var replies = BuildPostReplies(post.Replies);

            var model = new PostIndexModel
            {
                ID = post.ID,
                Title = post.Title,
                AuthorID = post.User.Id,
                AuthorName = post.User.UserName,
                AuthorImageUrl = post.User.ProfileImageUrl,
                AuthorRating = post.User.Rating,
                Created = post.Created,
                PostContent = post.Content,
                Replies = replies

            };

            return View();
        }

        private IEnumerable<PostReplyModel> BuildPostReplies(IEnumerable<PostReply> replies)
        {
            return replies.Select(reply => new PostReplyModel
            {
                ID = reply.ID,
                AuthorName = reply.User.UserName,
                AuthorID = reply.User.Id,
                AuthorImageUrl = reply.User.ProfileImageUrl,
                AuthorRating = reply.User.Rating,
                Created = reply.Created,
                ReplyContent = reply.Content,
            });
        }
    }
}