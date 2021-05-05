using System.Windows;
using System.Windows.Media.Animation;

namespace Kursach
{
    /// <summary>
    /// Wrapper static class to create storyboards using methods extensions
    /// </summary>
    public static class Storyboards
    {
        public static int? DesiredFrameRateValue;
        public static void SlideFadeInFromRight(this Storyboard storyboard, float duration, double offset, float deceleration = 0.9f)
        {
            // Specify animation
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(System.TimeSpan.FromSeconds(duration)),
                From = new Thickness(offset, 0, -offset, 0),
                To = new Thickness(0),
                DecelerationRatio = deceleration
            };
            // Set property to animate
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            // Add animation to storyboard
            storyboard.Children.Add(animation);
        }

        public static void SlideFadeInFromLeft(this Storyboard storyboard, float duration, double offset, float deceleration = 0.9f)
        {
            // Specify animation
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(System.TimeSpan.FromSeconds(duration)),
                From = new Thickness(-offset, 0, offset, 0),
                To = new Thickness(0),
                DecelerationRatio = deceleration
            };
            // Set property to animate
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            // Add animation to storyboard
            storyboard.Children.Add(animation);
        }
        
        public static void SlideFadeOutToLeft(this Storyboard storyboard, float duration, double offset, float deceleration = 0.9f)
        {
            // Specify animation
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(System.TimeSpan.FromSeconds(duration)),
                From = new Thickness(0),
                To = new Thickness(-offset, 0, offset, 0),
                DecelerationRatio = deceleration
            };
            // Set property to animate
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            // Add animation to storyboard
            storyboard.Children.Add(animation);
        }

        public static void SlideFadeOutToRight(this Storyboard storyboard, float duration, double offset, float deceleration = 0.9f)
        {
            // Specify animation
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(System.TimeSpan.FromSeconds(duration)),
                From = new Thickness(0),
                To = new Thickness(offset, 0, -offset, 0),
                DecelerationRatio = deceleration
            };
            // Set property to animate
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            // Add animation to storyboard
            storyboard.Children.Add(animation);
        }

        public static void ShortSlideFadeOutToLeft(this Storyboard storyboard, float duration, double offset, float deceleration = .9f)
        {
            // Specify animation
            var move = new ThicknessAnimation
            {
                Duration = new Duration(System.TimeSpan.FromSeconds(duration)),
                From = new Thickness(0),
                To = new Thickness(-offset, 0, offset, 0),
                DecelerationRatio = deceleration
            };
            
            var opacity = new DoubleAnimation
            {
                Duration = new Duration(System.TimeSpan.FromSeconds(duration)),
                From = 1,
                To = 0,
                DecelerationRatio = deceleration
            };

            // Set 60 fps on animation
            //Timeline.SetDesiredFrameRate(move, DesiredFrameRateValue);
            //Timeline.SetDesiredFrameRate(opacity, DesiredFrameRateValue);

            // Set property to animate
            Storyboard.SetTargetProperty(move, new PropertyPath("Margin"));
            Storyboard.SetTargetProperty(opacity, new PropertyPath("Opacity"));

            // Add animation to storyboard
            storyboard.Children.Add(move);
            storyboard.Children.Add(opacity);
        }

        public static void ShortSlideFadeInFromLeft(this Storyboard storyboard, float duration, double offset, float deceleration = .9f)
        {
            // Specify animation
            var move = new ThicknessAnimation
            {
                Duration = new Duration(System.TimeSpan.FromSeconds(duration)),
                From = new Thickness(-offset, 0, offset, 0),
                To = new Thickness(0),
                DecelerationRatio = deceleration
            };

            var opacity = new DoubleAnimation
            {
                Duration = new Duration(System.TimeSpan.FromSeconds(duration)),
                From = 0,
                To = 1,
                DecelerationRatio = deceleration
            };

            // Set 60 fps on animation
            //Timeline.SetDesiredFrameRate(move, DesiredFrameRateValue);
            //Timeline.SetDesiredFrameRate(opacity, DesiredFrameRateValue);

            // Set property to animate
            Storyboard.SetTargetProperty(move, new PropertyPath("Margin"));
            Storyboard.SetTargetProperty(opacity, new PropertyPath("Opacity"));

            // Add animation to storyboard
            storyboard.Children.Add(move);
            storyboard.Children.Add(opacity);
        }

    }
}
