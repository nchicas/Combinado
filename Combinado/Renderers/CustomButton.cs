using System;

using Xamarin.Forms;

namespace Combinado
{
	public class CustomButton : Button
	{
		public static BindableProperty BackgroundImageProperty = 
			BindableProperty.Create<CustomButton,string>(
				( c ) => c.BackgroundImage, string.Empty
			);

		public string BackgroundImage {
			get { 
				return (string)GetValue ( BackgroundImageProperty );
			}
			set {
				SetValue ( BackgroundImageProperty, value );
			}
		}
	}
}

