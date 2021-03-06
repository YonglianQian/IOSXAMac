﻿using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.iOS;
using Xamarin.UITest.Queries;

namespace IOSXAMacUITest
{
    [TestFixture]
    public class Tests
    {
        iOSApp app;

        [SetUp]
        public void BeforeEachTest()
        {
            // TODO: If the iOS app being tested is included in the solution then open
            // the Unit Tests window, right click Test Apps, select Add App Project
            // and select the app projects that should be tested.
            //
            // The iOS project should have the Xamarin.TestCloud.Agent NuGet package
            // installed. To start the Test Cloud Agent the following code should be
            // added to the FinishedLaunching method of the AppDelegate:
            //
            //    #if ENABLE_TEST_CLOUD
            //    Xamarin.Calabash.Start();
            //    #endif
            app = ConfigureApp
                .iOS
                // TODO: Update this path to point to your iOS app and uncomment the
                // code if the app is not included in the solution.
                //.AppBundle ("../../../iOS/bin/iPhoneSimulator/Debug/IOSXAMacUITest.iOS.app")
                //.AppBundle("/Users/abrahamqian/Desktop/Repos/IOSXAMac/IOSXAMac/bin/iPhoneSimulator/Release/IOSXAMac.app")
                .StartApp();
        }

        [Test]
        public void AppLaunches()
        {
            AppResult[] results = app.WaitForElement(e => e.Marked("Translate"));
            //app.Screenshot("First screen.");
            Assert.IsTrue(results.Any());
        }
    }
}
