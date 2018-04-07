using System;
using System.Globalization;
using MatchedBetMate.DTO.Enum;
using MatchedBetMate.iOS.Business.Interfaces.Services;
using MatchedBetMate.iOS.Model.ViewModel;
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

		public override void ViewDidLoad()
		{
            base.ViewDidLoad();

            SubscribeToValuesChangedEvents();
		}

        async partial void AddBetButton_TouchUpInside(Foundation.NSObject sender)
        {
            var betType = (BetType)Convert.ToInt16(BetTypeSegment.SelectedSegment);
            var backStake = decimal.Parse(BackStakeInput.Text, System.Globalization.CultureInfo.InvariantCulture);
            var backOdds = decimal.Parse(BackOddsInput.Text, System.Globalization.CultureInfo.InvariantCulture);
            var layOdds = decimal.Parse(LayOddsInput.Text, System.Globalization.CultureInfo.InvariantCulture);
            var layCommission = decimal.Parse(LayCommissionInput.Text, System.Globalization.CultureInfo.InvariantCulture);
            var layStake = decimal.Parse(LayStakeValueLabel.Text, System.Globalization.CultureInfo.InvariantCulture);


            var betToAdd = new BetViewModel
            {
                BetType = betType,
                BackStake = backStake,
                BackOdds = backOdds,
                LayOdds = layOdds,
                LayStake = layStake,
                LayCommission = layCommission
            };
          
           await ExecuteWithNetworkHandling(async () =>
            {
                await ViewModel.AddBet(betToAdd);
            });

            // TODO display success message
        }

		private void SubscribeToValuesChangedEvents()
        {
            BackStakeInput.EditingChanged += (sender, e) => ValidateAndCalculateBet();
            BackOddsInput.EditingChanged += (sender, e) => ValidateAndCalculateBet();
            LayOddsInput.EditingChanged += (sender, e) => ValidateAndCalculateBet();
            LayCommissionInput.EditingChanged += (sender, e) => ValidateAndCalculateBet();

            BetTypeSegment.ValueChanged += (sender, e) => ValidateAndCalculateBet();
        }

        private void ValidateAndCalculateBet()
        {
            if (ValidForBetCalculation())
            {
                var betCalcViewModel = CalculateBet();

                LayStakeValueLabel.Text = FormatWithPoundSign(betCalcViewModel.LayStake.ToString("0.00"));
                LiabilityValueLabel.Text = FormatWithPoundSign(betCalcViewModel.Liability.ToString("0.00"));
                BookmakerWinsValueLabel.Text = FormatWithPoundSign(betCalcViewModel.BookMakerWinProfit.ToString("0.00"));
                ExchangeWinsValueLabel.Text = FormatWithPoundSign(betCalcViewModel.BookMakerWinProfit.ToString("0.00"));
            }
        }

        private BetCalculationViewModel CalculateBet()
        {
            var betType =  (BetType)Convert.ToInt16(BetTypeSegment.SelectedSegment);
            var backStake = decimal.Parse(BackStakeInput.Text, System.Globalization.CultureInfo.InvariantCulture);
            var backOdds = decimal.Parse(BackOddsInput.Text, System.Globalization.CultureInfo.InvariantCulture);
            var layOdds = decimal.Parse(LayOddsInput.Text, System.Globalization.CultureInfo.InvariantCulture);
            var layCommission = decimal.Parse(LayCommissionInput.Text, System.Globalization.CultureInfo.InvariantCulture);

            return ViewModel.CalculateBet(betType, backStake, backOdds, layOdds, layCommission);
        }

        private bool ValidForBetCalculation()
        {
            return 
                !string.IsNullOrWhiteSpace(BackStakeInput.Text) &&
                !string.IsNullOrWhiteSpace(BackOddsInput.Text) &&
                !string.IsNullOrWhiteSpace(LayOddsInput.Text) &&
                !string.IsNullOrWhiteSpace(LayCommissionInput.Text);
         }

        private string FormatWithPoundSign(string calculationValue)
        {
            return $"£{calculationValue}";
        }
    }
}