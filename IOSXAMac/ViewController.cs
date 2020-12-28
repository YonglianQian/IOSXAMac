using Foundation;
using Microsoft.AppCenter.Analytics;
using System;
using UIKit;

namespace IOSXAMac
{
    public record Person
    {
        public string FirstName { get; }
        public string LastName { get; }
        public Person(string first, string last) => (FirstName, LastName) = (first, last);
        public override string ToString()
        {
            return $"{FirstName},{LastName}";
        }
    }

    /// <summary>
    /// Segment1, for testing the latest language feature. c#8
    /// </summary>
    public enum Rainbow
    {
        Red,
        Orange,
        Yellow,
        Green,
        Blue,
        Indigo,
        Violet
    }
    /// <summary>
    /// Segment2, for testing the latest language feature. c#8
    /// </summary>
    public class RGBColor
    {
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }

        public RGBColor(int a,int b,int c)
        {
            A = a;
            B = b;
            C = c;
        }
    }
    public partial class ViewController : UIViewController
    {
        /// <summary>
        /// Segment3, for testing the latest language feature. c#8
        /// </summary>
        /// <param name="colorBand"></param>
        /// <returns></returns>
        public static RGBColor FromRainbow(Rainbow colorBand) =>
    colorBand switch
    {
        Rainbow.Red => new RGBColor(0xFF, 0x00, 0x00),
        Rainbow.Orange => new RGBColor(0xFF, 0x7F, 0x00),
        Rainbow.Yellow => new RGBColor(0xFF, 0xFF, 0x00),
        Rainbow.Green => new RGBColor(0x00, 0xFF, 0x00),
        Rainbow.Blue => new RGBColor(0x00, 0x00, 0xFF),
        Rainbow.Indigo => new RGBColor(0x4B, 0x00, 0x82),
        Rainbow.Violet => new RGBColor(0x94, 0x00, 0xD3),
        _ => throw new ArgumentException(message: "invalid enum value", paramName: nameof(colorBand)),
    };

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            string translatedNumber = "";

            //Segment4, for testing C#8 feature.
            TranslateButton.TouchUpInside += (object sender, EventArgs e) => {

                Analytics.TrackEvent("First button is clicked at :" + DateTime.Now.ToLongTimeString());
                Person p = new Person("Abraham", "Qian");
                Analytics.TrackEvent($"{p.ToString()}: Custom event name: {FromRainbow(Rainbow.Indigo).A}");
                // Convert the phone number with text to a number
                // using PhoneTranslator.cs
                translatedNumber = PhoneTranslator.ToNumber(
                    PhoneNumberText.Text);

                // Dismiss the keyboard if text field was tapped
                PhoneNumberText.ResignFirstResponder();

                if (translatedNumber == "")
                {
                    CallButton.SetTitle("Call ", UIControlState.Normal);
                    CallButton.Enabled = false;
                }
                else
                {
                    CallButton.SetTitle("Call " + translatedNumber,
                        UIControlState.Normal);
                    CallButton.Enabled = true;
                }
            };

            CallButton.TouchUpInside += (object sender, EventArgs e) => {
                // Use URL handler with tel: prefix to invoke Apple's Phone app...
                var url = new NSUrl("tel:" + translatedNumber);

                // ...otherwise show an alert dialog
                if (!UIApplication.SharedApplication.OpenUrl(url))
                {
                    var alert = UIAlertController.Create("Not supported", "Scheme 'tel:' is not supported on this device", UIAlertControllerStyle.Alert);
                    alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
                    PresentViewController(alert, true, null);
                }
            };
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }

}