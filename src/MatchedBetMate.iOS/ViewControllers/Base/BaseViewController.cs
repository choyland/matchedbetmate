using System;
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
    }

    
}