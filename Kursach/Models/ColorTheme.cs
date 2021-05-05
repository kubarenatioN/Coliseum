using System.ComponentModel.DataAnnotations.Schema;

namespace Kursach
{
    public class ColorTheme
    {
        [ForeignKey("UserAccountInfo")]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
