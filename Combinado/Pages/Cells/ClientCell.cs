using System;

using Xamarin.Forms;

namespace Combinado
{
	public class ClientCell : ViewCell
	{
		private Image profileImage;
		private Label nameLabel;
		private Label phoneLabel;

		public ClientCell ()
		{
			// Para crear un Custom Cell aplican los mismos pasos que para un Page
			RelativeLayout layout = new RelativeLayout ();

			profileImage = new Image ();
			profileImage.Aspect = Aspect.AspectFit;
			profileImage.SetBinding ( Image.SourceProperty, "PictureUrl" );

			layout.Children.Add (
				profileImage,
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
				Constraint.RelativeToView( profileImage, ( p, v ) => v.X + v.Width + 5 ),
				Constraint.RelativeToView( profileImage, ( p, v ) => v.Y ),
				Constraint.RelativeToView( profileImage, ( p, v ) => p.Width - (v.X + v.Width + 5) - 5 ),
				Constraint.RelativeToView( profileImage, ( p, v ) => v.Height / 2 )
			);

			phoneLabel = new Label ();
			phoneLabel.XAlign = TextAlignment.Center;
			phoneLabel.YAlign = TextAlignment.Center;
			phoneLabel.FontSize = 12;
			phoneLabel.SetBinding ( Label.TextProperty, "Phone" );

			layout.Children.Add (
				phoneLabel,
				Constraint.RelativeToView( nameLabel, ( p, v ) => v.X ),
				Constraint.RelativeToView( nameLabel, ( p, v ) => v.Y + v.Height ),
				Constraint.RelativeToView( nameLabel, ( p, v ) => v.Width ),
				Constraint.RelativeToView( nameLabel, ( p, v ) => v.Height )
			);

			View = layout;
		}
	}
}


