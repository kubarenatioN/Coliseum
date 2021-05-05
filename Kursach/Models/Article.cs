using System;
using System.ComponentModel.DataAnnotations;

namespace Kursach
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime PostDate { get; set; }
        public string ImageFileName { get; set; }
        public int Views { get; set; }
        public string ArticlePath { get; set; }
    }
}
