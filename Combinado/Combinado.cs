using System;

using Xamarin.Forms;

namespace Combinado
{
	public class App : Application
	{
		public App ()
		{
			// Todas las apps deben tener NavigationPage como Page principal
			MainPage = new NavigationPage( new HomePage() ) {
				BarBackgroundColor = Color.Blue,
				BarTextColor = Color.White
			};
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

