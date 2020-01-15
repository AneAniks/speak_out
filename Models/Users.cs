using System;
using System.Collections.Generic;

namespace SpeakOut.Models
{
    public partial class Users
    {
        public Users()
        {
            Posts = new HashSet<Posts>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public int? PostId { get; set; }

        public virtual Posts Post { get; set; }
        public virtual ICollection<Posts> Posts { get; set; }
    }
}
