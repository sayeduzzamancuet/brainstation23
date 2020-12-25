
using System;

namespace FeedbackService.Models
{
    public class PostDTO
    {
        public long id { get; set; }
        public string Post { get; set; }
        public Nullable<DateTime> created { get; set; }
    }
}