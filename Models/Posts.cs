using System;
using System.Collections.Generic;

namespace SpeakOut.Models
{
    public partial class Posts
    {
        public Posts()
        {
            Category = new HashSet<Category>();
            Comments = new HashSet<Comments>();
            Users = new HashSet<Users>();
        }

        public int PostId { get; set; }
        public string Post { get; set; }
        public int? UserId { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category CategoryNavigation { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<Category> Category { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
