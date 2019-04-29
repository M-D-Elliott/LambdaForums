using SmashPopularity.Models.Post;
using System.Collections.Generic;

namespace SmashPopularity.Models.Forum
{
    public class ForumTopicModel
    {
        public ForumListingModel Forum { get; set; }
        public IEnumerable<PostListingModel> Posts { get; set; }
    }
}
