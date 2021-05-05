using Kursach.Views;

namespace Kursach
{
    public class ArticleItemViewModel : BaseViewModel
    {
        public Article ControlArticle { get; set; }
        public MainContentViewModel MainContentInstance;

        public RelayCommand OpenArticlePageCommand { get; set; }

        public ArticleItemViewModel(Article a)
        {
            ControlArticle = a;

            MainContentInstance = MainContentViewModel.Instance;

            OpenArticlePageCommand = new RelayCommand(async () => await MainContentInstance.OpenPage(new ArticlePage(ControlArticle)));
        }
    }
}
