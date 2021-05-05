using System;
using System.IO;
using System.Windows.Documents;
using System.Windows.Markup;

namespace Kursach
{
    public class ArticlePageViewModel : BaseViewModel
    {
        public Article PageArticle { get; set; }
        public FlowDocument FlowArticle { get; set; }
        public string ArticleFilePath { get; set; }
        public ArticlePageViewModel(Article a)
        {
            PageArticle = a;

            string fileName = PageArticle.ArticlePath;

            // path to the article
            //ArticleFilePath = $"../Articles/{fileName}.xaml";

            // parser context instance
            ParserContext context = new ParserContext
            {
                BaseUri = new Uri($@"D:\Visual_Studio\kursach\Kursach\Kursach\Articles\{fileName}.xaml", UriKind.Absolute)
            };

            // Open file stream
            FileStream articleFileStream = new FileStream($@"D:\Visual_Studio\kursach\Kursach\Kursach\Articles\{fileName}.xaml", FileMode.Open);

            FlowDocument content = XamlReader.Load(articleFileStream, context) as FlowDocument;

            FlowArticle = content;

            articleFileStream.Close();
        }
    }
}
