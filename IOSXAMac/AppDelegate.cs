using Foundation;
using UIKit;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter;

namespace IOSXAMac
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : UIResponder, IUIApplicationDelegate
    {

        [Export("window")]
        public UIWindow Window { get; set; }

        [Export("application:didFinishLaunchingWithOptions:")]
        public bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            AppCenter.Start("276868bc-d521-4182-b0ac-ac6f9d8996fb",
                   typeof(Analytics), typeof(Crashes));


#if ENABLE_TEST_CLOUD
                Xamarin.Calabash.Start();
#endif
            // Override point for customization after application launch.
            // If not required for your application you can safely delete this method
            return true;
        }

        // UISceneSession Lifecycle

        [Export("application:configurationForConnectingSceneSession:options:")]
        public UISceneConfiguration GetConfiguration(UIApplication application, UISceneSession connectingSceneSession, UISceneConnectionOptions options)
        {
            // Called when a new scene session is being created.
            // Use this method to select a configuration to create the new scene with.
            return UISceneConfiguration.Create("Default Configuration", connectingSceneSession.Role);
        }

        [Export("application:didDiscardSceneSessions:")]
        public void DidDiscardSceneSessions(UIApplication application, NSSet<UISceneSession> sceneSessions)
        {
            // Called when the user discards a scene session.
            // If any sessions were discarded while the application was not running, this will be called shortly after `FinishedLaunching`.
            // Use this method to release any resources that were specific to the discarded scenes, as they will not return.
        }
    }
}

