using Kursach.Views;
using System.Collections.Generic;

namespace Kursach
{
    public class NewsViewModel : BaseViewModel
    {
        public MainContentViewModel MainContentInstance;

        public List<ArticleItemControl> ArticlesList { get; set; } = new List<ArticleItemControl>();

        public NewsViewModel()
        {
            MainContentInstance = MainContentViewModel.Instance;

            foreach (Article a in UnitOfWork.News.GetAll())
            {
                ArticlesList.Add(new ArticleItemControl(a));
            }
        }
    }
}
