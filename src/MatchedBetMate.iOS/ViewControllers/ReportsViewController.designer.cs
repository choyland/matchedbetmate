// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//

using Foundation;

namespace MatchedBetMate.iOS.ViewControllers
{
    [Register ("ReportsViewController")]
    partial class ReportsViewController
    {
        [Outlet]
        UIKit.UILabel ReportsLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ReportsLabel != null) {
                ReportsLabel.Dispose ();
                ReportsLabel = null;
            }
        }
    }
}