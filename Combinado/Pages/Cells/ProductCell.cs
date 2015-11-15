using System;

using Xamarin.Forms;

namespace Combinado
{
	public class ProductCell : ViewCell
	{
		private Image productImage;
		private Label nameLabel;
		private Label priceLabel;
		private Label stockLabel;

		public ProductCell ()
		{
			// Para crear un Custom Cell aplican los mismos pasos que para un Page
			RelativeLayout layout = new RelativeLayout ();

			productImage = new Image ();
			productImage.Aspect = Aspect.AspectFit;
			productImage.SetBinding ( Image.SourceProperty, "ImageUrl" );

			layout.Children.Add (
				productImage,
				Constraint.Constant( 5 ),
				Constraint.Constant( 5 ),
				Constraint.Constant( 80 ),
				Constraint.Constant( 80 )
			);

			nameLabel = new Label ();
			nameLabel.XAlign = TextAlignment.Center;
			nameLabel.YAlign = TextAlignment.Center;
			nameLabel.FontSize = 18;
			nameLabel.SetBinding ( Label.TextProperty, "Name" );

			layout.Children.Add (
				nameLabel,
				Constraint.RelativeToView( productImage, ( p, v ) => v.X + v.Width + 5 ),
				Constraint.RelativeToView( productImage, ( p, v ) => v.Y ),
				Constraint.RelativeToView( productImage, ( p, v ) => p.Width - (v.X + v.Width + 5) - 5 ),
				Constraint.RelativeToView( productImage, ( p, v ) => v.Height / 2 )
			);

			priceLabel = new Label ();
			priceLabel.XAlign = TextAlignment.Start;
			priceLabel.YAlign = TextAlignment.Center;
			priceLabel.FontSize = 12;
			priceLabel.SetBinding ( Label.TextProperty, "Price" );

			layout.Children.Add (
				priceLabel,
				Constraint.RelativeToView( nameLabel, ( p, v ) => v.X ),
				Constraint.RelativeToView( nameLabel, ( p, v ) => v.Y + v.Height ),
				Constraint.RelativeToView( nameLabel, ( p, v ) => v.Width / 2 ),
				Constraint.RelativeToView( nameLabel, ( p, v ) => v.Height )
			);

			stockLabel = new Label ();
			stockLabel.XAlign = TextAlignment.End;
			stockLabel.YAlign = TextAlignment.Center;
			stockLabel.FontSize = 12;
			stockLabel.SetBinding ( Label.TextProperty, "Stock" );

			layout.Children.Add (
				stockLabel,
				Constraint.RelativeToView( nameLabel, ( p, v ) => v.X + v.Width / 2 ),
				Constraint.RelativeToView( nameLabel, ( p, v ) => v.Y + v.Height ),
				Constraint.RelativeToView( nameLabel, ( p, v ) => v.Width / 2 ),
				Constraint.RelativeToView( nameLabel, ( p, v ) => v.Height )
			);

			View = layout;
		}
	}
}


