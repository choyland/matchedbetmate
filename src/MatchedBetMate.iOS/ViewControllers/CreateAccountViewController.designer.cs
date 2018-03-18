// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//

using Foundation;

namespace MatchedBetMate.iOS.ViewControllers
{
    [Register ("CreateAccountViewController")]
    partial class CreateAccountViewController
    {
        [Outlet]
        ValidatedTextField ConfirmPasswordInput { get; set; }


        [Outlet]
        UIKit.UILabel ConfirmPasswordLabel { get; set; }


        [Outlet]
        UIKit.UIButton CreateAccountButton { get; set; }


        [Outlet]
        ValidatedTextField EmailInput { get; set; }


        [Outlet]
        UIKit.UILabel EmailLabel { get; set; }


        [Outlet]
        ValidatedTextField PasswordInput { get; set; }


        [Outlet]
        UIKit.UILabel PasswordLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ConfirmPasswordInput != null) {
                ConfirmPasswordInput.Dispose ();
                ConfirmPasswordInput = null;
            }

            if (CreateAccountButton != null) {
                CreateAccountButton.Dispose ();
                CreateAccountButton = null;
            }

            if (EmailInput != null) {
                EmailInput.Dispose ();
                EmailInput = null;
            }

            if (EmailLabel != null) {
                EmailLabel.Dispose ();
                EmailLabel = null;
            }

            if (PasswordInput != null) {
                PasswordInput.Dispose ();
                PasswordInput = null;
            }

            if (PasswordLabel != null) {
                PasswordLabel.Dispose ();
                PasswordLabel = null;
            }
        }
    }
}