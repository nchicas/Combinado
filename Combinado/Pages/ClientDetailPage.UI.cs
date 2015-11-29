using System;

using Xamarin.Forms;

namespace Combinado
{
	public partial class ClientDetailPage : ContentPage
	{
		private Label nameLabel;
		private Image profileImage;
		private Label phoneLabel;

		private void InitializeComponents()
		{
			StackLayout layout = new StackLayout ();

			nameLabel = new Label () { 
				Text = client.Name,
				FontSize = 18,
				XAlign = TextAlignment.Center
			};

			layout.Children.Add ( nameLabel );

			profileImage = new Image () { 
				Source = client.PictureUrl,
				Aspect = Aspect.AspectFit
			};

			layout.Children.Add ( profileImage );

			phoneLabel = new Label () { 
				Text = client.Phone,
				FontSize = 14,
				XAlign = TextAlignment.Center
			};

			layout.Children.Add ( phoneLabel );

			Content = layout;
		}
	}
}


