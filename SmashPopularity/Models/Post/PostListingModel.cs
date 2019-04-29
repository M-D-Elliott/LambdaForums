using SmashPopularity.Models.Forum;

namespace SmashPopularity.Models.Post
{
    public class PostListingModel : PostModel
    {
        public string DatePosted { get; set; }
        public ForumListingModel Forum { get; set; }
        public int RepliesCount { get; set; }
    }
}
