using System;
using System.Collections.Generic;

namespace SpeakOut.Models
{
    public partial class Category
    {
        public Category()
        {
            Posts = new HashSet<Posts>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int? PostId { get; set; }

        public virtual Posts Post { get; set; }
        public virtual ICollection<Posts> Posts { get; set; }
    }
}
