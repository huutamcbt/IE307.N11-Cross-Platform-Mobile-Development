using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Content;
using Android.Content.Res;
using Android.Graphics.Drawables;
using Frontend;
using Frontend.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

#pragma warning disable CS0612 // Type or member is obsolete
[assembly: ExportRenderer(typeof(SearchBarNoUnderline), typeof(SearchBarNoUnderlineRenderer))]
#pragma warning restore CS0612 // Type or member is obsolete
namespace Frontend.Droid
{
    [Obsolete]
    public class SearchBarNoUnderlineRenderer : SearchBarRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                var plateId = Resources.GetIdentifier("android:id/search_plate", null, null);
                var plate = Control.FindViewById(plateId);
                plate.SetBackgroundColor(Android.Graphics.Color.Transparent);
            }
        }
    }
}