using SmashPopularity.Models.Post;
using System;
using System.Collections.Generic;

namespace SmashPopularity.Models.Reply
{
    public class PostReplyModel: PostModel
    {
        public string ReplyContent { get; set; }
        public int PostID { get; set; }
    }
}
