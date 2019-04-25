using System;

namespace SmashPopularity.Data.Models
{
    public class PostReply
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Post Post { get; set; }
    }
}