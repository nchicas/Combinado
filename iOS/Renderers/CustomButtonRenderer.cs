using System;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

using UIKit;

[assembly: ExportRenderer(
	typeof(Combinado.CustomButton),
	typeof(Combinado.iOS.CustomButtonRenderer))]

namespace Combinado.iOS
{
	public class CustomButtonRenderer : ButtonRenderer
	{
		// Este es apra inicializar
		protected override void OnElementChanged (ElementChangedEventArgs<Button> e)
		{
			base.OnElementChanged (e);

			// Validamos que haya una instancia del control compartido
			if( e.NewElement == null ) {
				return;
			}

			// e.NewElement se refiere al control en el código compartido
			CustomButton button = (CustomButton)e.NewElement;
			// Control se refiere al control especifico de la plataforma
			Control.SetBackgroundImage ( 
				UIImage.FromBundle( button.BackgroundImage ),
				UIControlState.Normal
			);
		}

		// Este es para actualizar con los valores del compartido
		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);
			CustomButton button = (CustomButton)sender;

			if( e.PropertyName == CustomButton.BackgroundImageProperty.PropertyName ) {
				Control.SetBackgroundImage ( 
					UIImage.FromBundle( button.BackgroundImage ),
					UIControlState.Normal
				);
			}
		}
	}
}

