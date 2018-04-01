using System;
using System.Diagnostics;
using System.Threading.Tasks;
using CoreGraphics;
using MatchedBetMate.iOS.ViewModels.Interfaces;
using UIKit;

namespace MatchedBetMate.iOS.ViewControllers.Base
{
    public class BaseViewController<T> : UIViewController
    {
        protected T ViewModel { get; private set; }

        public BaseViewController(IMatchedBetMateViewModel viewModel) : base()
        {
            Initialise(viewModel);
        }

        public BaseViewController(IntPtr p, IMatchedBetMateViewModel viewModel) : base(p)
        {
            Initialise(viewModel);
        }

        private void Initialise(IMatchedBetMateViewModel viewModel)
        {
            ViewModel = (T)viewModel;
        }

        protected async Task<bool> ExecuteWithNetworkHandling(Func<Task> action, bool showLoader = true)
        {
            var success = true;

            UIView loadingView = null;

            try
            {
                if (showLoader)
                {
                    loadingView = new UIView(View.Frame) { UserInteractionEnabled = false };
                    ShowLoadingView(loadingView);
                }

                await action();
            }
            catch (Exception ex)
            {
                DisplayErrorPopup();

                Debug.Write(ex.Message);
                success = false;
            }
            finally
            {
                if (showLoader)
                {
                    HideLoadingView(loadingView);
                }
            }

            return success;
        }

        private void DisplayErrorPopup()
        {
            var alert = UIAlertController.Create("Error",
                "An error occurrec while processing the request, please check your network connection and try again",
                UIAlertControllerStyle.Alert);
            alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));

            PresentViewController(alert, true, null);
        }

        private void ShowLoadingView(UIView loadingView)
        {
            var uiIndicator = new UIActivityIndicatorView(new CGRect(loadingView.Center, new CGSize(50, 50)));
            loadingView.AddSubview(uiIndicator);

            View.AddSubview(loadingView);
        }

        private static void HideLoadingView(UIView loadingView)
        {
            loadingView?.RemoveFromSuperview();
        }
    }
}