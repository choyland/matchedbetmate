// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//

using Foundation;

namespace MatchedBetMate.iOS.ViewControllers
{
    [Register ("LoginViewController")]
    partial class LoginViewController
    {
        [Outlet]
        UIKit.UILabel CreateNewAccountLabel { get; set; }

        [Outlet]
        ValidatedTextField EmailAddressInput { get; set; }

        [Outlet]
        UIKit.UIButton LoginButton { get; set; }

        [Outlet]
        ValidatedTextField PasswordInput { get; set; }

        [Action ("LoginButton_TouchUpInside:")]
        partial void LoginButton_TouchUpInside (Foundation.NSObject sender);

        void ReleaseDesignerOutlets ()
        {
            if (CreateNewAccountLabel != null) {
                CreateNewAccountLabel.Dispose ();
                CreateNewAccountLabel = null;
            }

            if (EmailAddressInput != null) {
                EmailAddressInput.Dispose ();
                EmailAddressInput = null;
            }

            if (LoginButton != null) {
                LoginButton.Dispose ();
                LoginButton = null;
            }

            if (PasswordInput != null) {
                PasswordInput.Dispose ();
                PasswordInput = null;
            }
        }
    }
}