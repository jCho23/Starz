using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using System.Threading;

namespace Starz
{
	[TestFixture(Platform.Android)]
	[TestFixture(Platform.iOS)]
	public class Tests
	{
		IApp app;
		Platform platform;

		public Tests(Platform platform)
		{
			this.platform = platform;
		}

		[SetUp]
		public void BeforeEachTest()
		{
			app = AppInitializer.StartApp(platform);
		}

		[Test]
		public void AppLaunches()
		{
			app.Repl();
		}

		[Test]
		public void NoAccountTest()
		{
			app.WaitForElement(x => x.Class("android.widget.ImageButton").Index(0), timeout: TimeSpan.FromSeconds(80)); ;
			app.Tap(x => x.Class("android.widget.ImageButton").Index(0));
			app.Screenshot("Let's start by Tapping on the 'Hamburger Menu' Button");
			app.Tap("FEATURED");
			app.Screenshot("Then we Tapped on 'Featured'");
			app.Tap("key_art_image_view");
			app.Screenshot("Next we Tapped on the first result");
			app.Tap("action_search");
			app.Screenshot("We Tapped on the 'Search' Button");

			app.EnterText("Marvel");
			app.Screenshot("Then we entered in our search 'Marvel'");
			app.PressEnter();
			app.Screenshot("And we Tapped the 'Return' Key");
			app.Back();
			app.Screenshot("We Tapped the 'Back' Button");
			Thread.Sleep(3000);
			app.Back();
			app.Screenshot("We Tapped the 'Back' Button");
			Thread.Sleep(3000);

			app.Tap(x => x.Class("android.widget.ImageButton").Index(0));
			app.Tap("MOVIES");
			app.Tap("key_art_image_view");
			app.Tap("bb_play_button");
			app.Screenshot("We Tap the 'Play' Button");
		}






	}
}
