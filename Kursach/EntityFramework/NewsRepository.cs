namespace Kursach
{
    public class NewsRepository : Repository<Article>
    {
        public NewsRepository(ColiseumDbContext context) : base(context) { }

    }
}
