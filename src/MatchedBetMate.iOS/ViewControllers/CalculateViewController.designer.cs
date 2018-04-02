// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace MatchedBetMate.iOS.ViewControllers
{
	[Register ("CalculateViewController")]
	partial class CalculateViewController
	{
		[Outlet]
		UIKit.UIButton AddBetButton { get; set; }

		[Outlet]
		UIKit.UIView BackCalcView { get; set; }

		[Outlet]
		UIKit.UITextField BackOddsInput { get; set; }

		[Outlet]
		UIKit.UILabel BackOddsLabel { get; set; }

		[Outlet]
		UIKit.UITextField BackStakeInput { get; set; }

		[Outlet]
		UIKit.UILabel BackStakeLabel { get; set; }

		[Outlet]
		UIKit.UIView BetCalcView { get; set; }

		[Outlet]
		UIKit.UISegmentedControl BetTypeSegment { get; set; }

		[Outlet]
		UIKit.UILabel BookmakerWinsLabel { get; set; }

		[Outlet]
		UIKit.UILabel BookmakerWinsValueLabel { get; set; }

		[Outlet]
		UIKit.UIView DividerView { get; set; }

		[Outlet]
		UIKit.UILabel ExchangeWinsLabel { get; set; }

		[Outlet]
		UIKit.UILabel ExchangeWinsValueLabel { get; set; }

		[Outlet]
		UIKit.UIView LayCalcView { get; set; }

		[Outlet]
		UIKit.UITextField LayCommissionInput { get; set; }

		[Outlet]
		UIKit.UILabel LayCommissionLabel { get; set; }

		[Outlet]
		UIKit.UITextField LayOddsInput { get; set; }

		[Outlet]
		UIKit.UILabel LayOddsLabel { get; set; }

		[Outlet]
		UIKit.UILabel LayStakeLabel { get; set; }

		[Outlet]
		UIKit.UILabel LayStakeValueLabel { get; set; }

		[Outlet]
		UIKit.UILabel LiabilityLabel { get; set; }

		[Outlet]
		UIKit.UILabel LiabilityValueLabel { get; set; }

		[Outlet]
		UIKit.UIView SpacerViewFive { get; set; }

		[Outlet]
		UIKit.UIView SpacerViewFour { get; set; }

		[Outlet]
		UIKit.UIView SpacerViewOne { get; set; }

		[Outlet]
		UIKit.UIView SpacerViewSix { get; set; }

		[Outlet]
		UIKit.UIView SpacerViewThree { get; set; }

		[Outlet]
		UIKit.UIView SpacerViewTwo { get; set; }

		[Action ("AddBetButton_TouchUpInside:")]
		partial void AddBetButton_TouchUpInside (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (BackCalcView != null) {
				BackCalcView.Dispose ();
				BackCalcView = null;
			}

			if (BackOddsInput != null) {
				BackOddsInput.Dispose ();
				BackOddsInput = null;
			}

			if (BackOddsLabel != null) {
				BackOddsLabel.Dispose ();
				BackOddsLabel = null;
			}

			if (BackStakeInput != null) {
				BackStakeInput.Dispose ();
				BackStakeInput = null;
			}

			if (BackStakeLabel != null) {
				BackStakeLabel.Dispose ();
				BackStakeLabel = null;
			}

			if (BetCalcView != null) {
				BetCalcView.Dispose ();
				BetCalcView = null;
			}

			if (BetTypeSegment != null) {
				BetTypeSegment.Dispose ();
				BetTypeSegment = null;
			}

			if (BookmakerWinsLabel != null) {
				BookmakerWinsLabel.Dispose ();
				BookmakerWinsLabel = null;
			}

			if (BookmakerWinsValueLabel != null) {
				BookmakerWinsValueLabel.Dispose ();
				BookmakerWinsValueLabel = null;
			}

			if (DividerView != null) {
				DividerView.Dispose ();
				DividerView = null;
			}

			if (ExchangeWinsLabel != null) {
				ExchangeWinsLabel.Dispose ();
				ExchangeWinsLabel = null;
			}

			if (ExchangeWinsValueLabel != null) {
				ExchangeWinsValueLabel.Dispose ();
				ExchangeWinsValueLabel = null;
			}

			if (LayCalcView != null) {
				LayCalcView.Dispose ();
				LayCalcView = null;
			}

			if (LayCommissionInput != null) {
				LayCommissionInput.Dispose ();
				LayCommissionInput = null;
			}

			if (LayCommissionLabel != null) {
				LayCommissionLabel.Dispose ();
				LayCommissionLabel = null;
			}

			if (LayOddsInput != null) {
				LayOddsInput.Dispose ();
				LayOddsInput = null;
			}

			if (LayOddsLabel != null) {
				LayOddsLabel.Dispose ();
				LayOddsLabel = null;
			}

			if (LayStakeLabel != null) {
				LayStakeLabel.Dispose ();
				LayStakeLabel = null;
			}

			if (LayStakeValueLabel != null) {
				LayStakeValueLabel.Dispose ();
				LayStakeValueLabel = null;
			}

			if (LiabilityLabel != null) {
				LiabilityLabel.Dispose ();
				LiabilityLabel = null;
			}

			if (LiabilityValueLabel != null) {
				LiabilityValueLabel.Dispose ();
				LiabilityValueLabel = null;
			}

			if (SpacerViewFive != null) {
				SpacerViewFive.Dispose ();
				SpacerViewFive = null;
			}

			if (SpacerViewFour != null) {
				SpacerViewFour.Dispose ();
				SpacerViewFour = null;
			}

			if (SpacerViewOne != null) {
				SpacerViewOne.Dispose ();
				SpacerViewOne = null;
			}

			if (SpacerViewThree != null) {
				SpacerViewThree.Dispose ();
				SpacerViewThree = null;
			}

			if (SpacerViewTwo != null) {
				SpacerViewTwo.Dispose ();
				SpacerViewTwo = null;
			}

			if (SpacerViewSix != null) {
				SpacerViewSix.Dispose ();
				SpacerViewSix = null;
			}

			if (AddBetButton != null) {
				AddBetButton.Dispose ();
				AddBetButton = null;
			}
		}
	}
}
