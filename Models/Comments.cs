using System;
using System.Collections.Generic;

namespace SpeakOut.Models
{
    public partial class Comments
    {
        public int CommentId { get; set; }
        public string Comment { get; set; }
        public int? PostId { get; set; }

        public virtual Posts Post { get; set; }
    }
}
