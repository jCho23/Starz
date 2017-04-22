using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

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
			app.Tap(x => x.Class("android.widget.ImageButton").Index(0));
			app.Tap("FEATURED");
			app.Tap("key_art_image_view");
			app.Tap("action_search");

			app.EnterText("Marvel");
			app.Back();
			app.Back();

			app.Tap(x => x.Class("android.widget.ImageButton").Index(0));
			app.Tap("MOVIES");
			app.Tap("key_art_image_view");
			app.Tap("bb_play_button");
			app.Screenshot("We Tap the 'Play' Button");
		}






	}
}
