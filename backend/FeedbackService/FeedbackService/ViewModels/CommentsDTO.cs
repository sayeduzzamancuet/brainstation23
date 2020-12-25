using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FeedbackService.Models
{
    public class CommentsDTO
    {
        public long Id { get; set; }
        public string Comment { get; set; }
        public long PostId { get; set; }
        public Nullable<DateTime> created { get; set; }

    }
}