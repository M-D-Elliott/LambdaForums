using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmashPopularity.Models.Post
{
    public class PostModel
    {
        public string Title { get; set; }
        public int ID { get; set; }
        public string AuthorID { get; set; }
        public string AuthorName { get; set; }
        public int AuthorRating { get; set; }
        public string AuthorImageUrl { get; set; }
        public DateTime Created { get; set; }

        public bool IsAuthorAdmin { get; set; }
    }
}
