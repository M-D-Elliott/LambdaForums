using SmashPopularity.Models.Reply;
using System;
using System.Collections.Generic;

namespace SmashPopularity.Models.Post
{
    public class PostIndexModel : PostModel
    {
        public string PostContent { get; set; }

        public int ForumID { get; set; }
        public string ForumName { get; set; }

        public IEnumerable<PostReplyModel> Replies { get; set; }

    }
}
