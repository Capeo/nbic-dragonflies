using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using NbicDragonflies.Droid.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using NbicDragonflies.Views.ListItems;

[assembly: ExportRenderer(typeof(ObservationsCell), typeof(ObservationCellRenderer))]

namespace NbicDragonflies.Droid.Views {
    class ObservationCellRenderer : ViewCellRenderer {

        protected override Android.Views.View GetCellCore(Xamarin.Forms.Cell item, Android.Views.View convertView,
            ViewGroup parent, Context context)
        {
            var x = (ObservationsCell) item;

            var view = convertView;

            if (view == null)
            {
                view = (context as Activity).LayoutInflater.Inflate(Resource.Layout.ObservationCellLayout, null);
            }

            view.FindViewById<TextView>(Resource.Id.speciesText).Text = x.Taxon;
            view.FindViewById<TextView>(Resource.Id.locationText).Text = x.Location;
            view.FindViewById<TextView>(Resource.Id.dateText).Text = x.Date;
            view.FindViewById<TextView>(Resource.Id.userText).Text = x.User;

            if (view.FindViewById<ImageView>(Resource.Id.Image).Drawable != null)
            {
                using (var image = view.FindViewById<ImageView>(Resource.Id.Image).Drawable as BitmapDrawable)
                {
                    if (image != null)
                    {
                        if (image.Bitmap != null)
                        {
                            image.Bitmap.Dispose();
                        }
                    }
                }
            }

            if (!String.IsNullOrWhiteSpace(x.ImageFilename))
            {
                Console.WriteLine("Test");
                context.Resources.GetBitmapAsync(x.ImageFilename).ContinueWith((t) =>
                {
                    var bitmap = t.Result;
                    if (bitmap != null)
                    {
                        view.FindViewById<ImageView>(Resource.Id.Image).SetImageBitmap(bitmap);
                        bitmap.Dispose();
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());
            }
            else
            {
                view.FindViewById<ImageView>(Resource.Id.Image).SetImageBitmap(null);
            }

            return view;
        }
    }
}