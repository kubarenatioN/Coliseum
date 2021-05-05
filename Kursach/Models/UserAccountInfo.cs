using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Drawing;
//using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Kursach
{
    public class UserAccountInfo
    {
        [ForeignKey("User")]
        public int Id { get; set; }
        public string BannerImage { get; set; }
        public byte[] AvatarImage { get; set; }

        public virtual User User { get; set; }
        public virtual ColorTheme ColorTheme { get; set; }

        public UserAccountInfo()
        {
            // default banner image filename
            BannerImage = "1"; 
        }
    }
}