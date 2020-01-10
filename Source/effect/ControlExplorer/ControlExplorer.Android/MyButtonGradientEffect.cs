using Android.Graphics.Drawables;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace ControlExplorer.Droid
{
    public class MyButtonGradientEffect : PlatformEffect
    {
        Drawable oldDrawable;

        protected override void OnAttached()
        {
        }

        protected override void OnDetached()
        {
        }

        void SetGradient()
        {
            var xfButton = Element as Xamarin.Forms.Button;

            var colorTop = xfButton.BackgroundColor;
            var colorBottom = Xamarin.Forms.Color.Black;

            var drawable = Gradient.GetGradientDrawable(colorTop.ToAndroid(), colorBottom.ToAndroid());

            Control.SetBackground(drawable);
        }
    }
}