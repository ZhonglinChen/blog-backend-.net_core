using System;

namespace backend.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime PostDate { get; set; }

        public string Content { get; set; }
    }
}