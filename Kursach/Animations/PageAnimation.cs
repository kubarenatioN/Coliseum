using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Kursach
{
    /// <summary>
    /// Helper class to add animation methods to Pages using methods extensions
    /// </summary>
    public static class PageAnimation
    {
        public static async Task PageAnimationSlideFadeInFromRight(this Page page, float duration, double offset)
        {
            var storyboard = new Storyboard();

            // Specify storyboard
            storyboard.SlideFadeInFromRight(duration, offset);

            // Run animation on current page
            storyboard.Begin(page);

            // Wait animation to finish
            await Task.Delay((int)(duration * 1000));
        }

        public static async Task PageAnimationSlideFadeInFromLeft(this Page page, float duration, double offset)
        {
            var storyboard = new Storyboard();

            // Specify storyboard
            storyboard.SlideFadeInFromLeft(duration, offset);

            // Run animation on current page
            storyboard.Begin(page);

            // Wait animation to finish
            await Task.Delay((int)(duration * 1000));
        }

        public static async Task PageAnimationSlideFadeOutToLeft(this Page page, float duration)
        {
            var storyboard = new Storyboard();

            // Specify storyboard
            storyboard.SlideFadeOutToLeft(duration, page.ActualWidth);

            // Run animation on current page
            storyboard.Begin(page);

            // Wait animation to finish
            await Task.Delay((int)(duration * 1000));
        }

        public static async Task PageAnimationSlideFadeOutToRight(this Page page, float duration)
        {
            var storyboard = new Storyboard();

            // Specify storyboard
            storyboard.SlideFadeOutToRight(duration, page.ActualWidth);

            // Run animation on current page
            storyboard.Begin(page);

            // Wait animation to finish
            await Task.Delay((int)(duration * 1000));
        }

        public static async Task PageAnimationShortSlideFadeOutToLeft(this Page page, float duration, double offset)
        {
            var storyboard = new Storyboard();

            // Specify storyboard
            storyboard.ShortSlideFadeOutToLeft(duration, offset);

            // Run animation on current page
            storyboard.Begin(page);

            // Wait animation to finish
            await Task.Delay((int)(duration * 1000));
        }

        public static async Task PageAnimationShortSlideFadeInFromLeft(this Page page, float duration, double offset)
        {
            var storyboard = new Storyboard();

            // Specify storyboard
            storyboard.ShortSlideFadeInFromLeft(duration, offset);

            // Run animation on current page
            storyboard.Begin(page);

            // Wait animation to finish
            await Task.Delay((int)(duration * 1000));

            // Make page visible when the animation start
            //page.Visibility = Visibility.Collapsed;
        }
    }
}
