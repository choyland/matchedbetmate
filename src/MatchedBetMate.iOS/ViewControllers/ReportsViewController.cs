using System;
using UIKit;

namespace MatchedBetMate.iOS.ViewControllers
{
    public partial class ReportsViewController : UIViewController
    {
        public ReportsViewController (IntPtr handle) : base (handle)
        {
            
        }

        public override void ViewDidLoad()
        {
            ReportsLabel.TextColor = UIColor.Red;
        }
    }
}