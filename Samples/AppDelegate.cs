namespace Samples
{
	using System.Threading;
	using MonoMobile.MVVM;
	using MonoTouch.Foundation;
	using MonoTouch.UIKit;	

	[Register("AppDelegate")]
	public class AppDelegate : UIApplicationDelegate
	{
		private static UIImage _DefaultImage = UIImage.FromFile("Default.png");
		
		private UIWindow _Window;
		private UINavigationController _Navigation;

		// This method is invoked when the application has loaded its UI and its ready to run
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			_Navigation = new UINavigationController();

            _Window = new UIWindow(UIScreen.MainScreen.Bounds);
			
			if (_DefaultImage != null)
				_Window.BackgroundColor = UIColor.FromPatternImage(_DefaultImage);
		
			_Navigation.View.Alpha = 0.0f;

			_Window.AddSubview(_Navigation.View);
			_Window.MakeKeyAndVisible();

			Application.Window = _Window;
			Application.Navigation = _Navigation;

			// this method initializes the main NavigationController
			var startupThread = new Thread(Startup);
			startupThread.Start();
			
			return true;
		}

		private void Startup()
		{
			using (var pool = new NSAutoreleasePool()) 
			{
				InvokeOnMainThread(delegate 
				{
					var binding = new BindingContext(new TestView(), "Samples MVVM");
					_Navigation.ViewControllers = new UIViewController[] { new DialogViewController(UITableViewStyle.Grouped, binding, true) { Autorotate = true } };

					UIView.BeginAnimations("fadeIn");
					UIView.SetAnimationDuration(0.3f);
					_Navigation.View.Alpha = 1.0f;
					UIView.CommitAnimations();
				});
			}
		}

        // This method is allegedly required in iPhoneOS 3.0
        public override void OnActivated(UIApplication application)
        {
        }
		
		public override void WillTerminate(UIApplication application)
		{
			SaveScreen();
		}

		public override void DidEnterBackground(UIApplication application)
		{
			SaveScreen();
		}

		private void SaveScreen()
		{
			// Save screenshot as splashscreen
//			UIGraphics.BeginImageContext(_Window.Bounds.Size);
//
//			_Window.Layer.RenderInContext(UIGraphics.GetCurrentContext());
//			var image = UIGraphics.GetImageFromCurrentImageContext();
//
//			UIGraphics.EndImageContext();
//
//			NSError err = new NSError();
//			image.AsPNG().Save("Default.png", true, out err);
		}
	}
}

