using System;
using MatchedBetMate.iOS.Business.Interfaces.Services;
using MatchedBetMate.iOS.ViewControllers.Base;
using MatchedBetMate.iOS.ViewModels;
using UIKit;

namespace MatchedBetMate.iOS.ViewControllers
{
    public partial class CalculateViewController : BaseViewController<CalculateViewModel>
    {
        public CalculateViewController (IntPtr handle) : base (handle, new CalculateViewModel())
        {

        }
    }
}