using System;
using System.Collections.Generic;
using System.Linq;
using Balta.ContentContext;

namespace Balta.ContentContext
{
    public class Career : Content
    {
        public Career(string title, string url) : base(title, url)
        {
            Items = new List<CareerItem>();
        }
        public IList<CareerItem> Items { get; set; }

        public int TotalCourses => Items.Count();
        // Expression body
    }
}