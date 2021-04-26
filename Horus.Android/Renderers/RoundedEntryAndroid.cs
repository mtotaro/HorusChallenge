using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Widget;
using Horus.Droid.Renderers;
using Horus.Forms.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(RoundedEntry), typeof(RoundedEntryAndroid))]
namespace Horus.Droid.Renderers
{
    public class RoundedEntryAndroid : EntryRenderer
    {
        public RoundedEntryAndroid(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                EditText nativeEditText = (EditText)Control;
                ShapeDrawable shape = new ShapeDrawable(new Android.Graphics.Drawables.Shapes.RectShape());
                shape.Paint.Color = Xamarin.Forms.Color.Black.ToAndroid();
                shape.Paint.SetStyle(Paint.Style.Stroke);
                nativeEditText.Background = shape;
                GradientDrawable gd = new GradientDrawable();
                gd.SetColor(Android.Graphics.Color.Rgb(247,246,246));
                gd.SetCornerRadius(50f);
                gd.SetStroke(0, Android.Graphics.Color.LightGray);
                nativeEditText.SetBackground(gd);
                Control.SetPadding(40, 40, 40, 40);
            }
        }
    }
}