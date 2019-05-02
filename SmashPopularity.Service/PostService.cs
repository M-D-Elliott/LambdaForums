using Microsoft.EntityFrameworkCore;
using SmashPopularity.Data;
using SmashPopularity.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmashPopularity.Service
{
    public class PostService : IPost
    {
        private readonly ApplicationDbContext _context;

        public PostService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Post post)
        {
            _context.Add(post);
            await _context.SaveChangesAsync();
        }

        public Task AddReply(PostReply reply)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditPostContent(int id, string newContent)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetAll()
        {
            return _context.Posts
                .Include(p => p.User)
                .Include(p => p.Replies).ThenInclude(r => r.User)
                .Include(p => p.Forum);
        }

        public Post GetByID(int id)
        {
            var post = _context.Posts.Where(p => p.ID == id)
                .Include(p => p.User)
                .Include(p => p.Replies).ThenInclude(r => r.User)
                .Include(p => p.Forum)
                .FirstOrDefault();

            return post;
        }

        public IEnumerable<Post> GetFilteredPosts(Forum forum, string searchQuery)
        {
            return string.IsNullOrEmpty(searchQuery)
                ? forum.Posts
                : forum.Posts.Where(p 
                    => p.Title.Contains(searchQuery) 
                    || p.Content.Contains(searchQuery));
        }

        public IEnumerable<Post> GetFilteredPosts(string searchQuery)
        {
            return GetAll().Where(p
                => p.Title.Contains(searchQuery)
                || p.Content.Contains(searchQuery));
        }

        public IEnumerable<Post> GetLatestPosts(int nPosts)
        {
            return GetAll().OrderByDescending(p => p.Created).Take(nPosts);
        }

        public IEnumerable<Post> GetPostsByForum(int id)
        {
            return _context.Forums.Where(f => f.ID == id).First()
                .Posts;
        }
    }
}
