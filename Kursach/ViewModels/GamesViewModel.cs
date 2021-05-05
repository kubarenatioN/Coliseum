using Kursach.Views;
using System.Collections.Generic;
using System.Linq;

namespace Kursach
{
    public class GamesViewModel : BaseViewModel
    {
        /// <summary>
        /// Collection of games to display
        /// </summary>
        public List<GameItemControl> GamesCollection { get; set; } = new List<GameItemControl>();
        
        public GamesViewModel()
        {
            foreach (var game in UnitOfWork.Games.GetGamesWithImages(game => game.GameImage != null))
            {
                GameItemControl gControl = new GameItemControl(game);
                GamesCollection.Add(gControl);
            }

            // TEST 
            GamesCollection = GamesCollection.Take(3).ToList();
        }
    }
}
