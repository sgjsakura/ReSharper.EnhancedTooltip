﻿using System;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using JetBrains.Annotations;
using JetBrains.Util;

namespace GammaJul.ReSharper.EnhancedTooltip.Presentation {

	public static class IconScaling {

		public static readonly DependencyProperty IsScalingWithFontSizeProperty = DependencyProperty.RegisterAttached(
			"IsScalingWithFontSize",
			typeof(bool),
			typeof(IconScaling),
			new FrameworkPropertyMetadata(BooleanBoxes.False, OnFontSizeForScaleChanged));

		public static double GetIsScalingWithFontSize([NotNull] DependencyObject owner) {
			if (owner == null)
				throw new ArgumentNullException(nameof(owner));
			return (double) owner.GetValue(IsScalingWithFontSizeProperty);
		}

		public static void SetIsScalingWithFontSize([NotNull] DependencyObject owner, bool value) {
			if (owner == null)
				throw new ArgumentNullException(nameof(owner));
			owner.SetValue(IsScalingWithFontSizeProperty, value);
		}

		private static void OnFontSizeForScaleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
			var element = d as FrameworkElement;
			if (element == null)
				return;

			FontFamily fontFamily = TextElement.GetFontFamily(element);
			if (fontFamily == null)
				return;

			double fontSize = TextElement.GetFontSize(element);
			if (Double.IsNaN(fontSize))
				return;


			double size = fontFamily.LineSpacing * fontSize;
			if (size < 18.0) {
				// Scaling isn't a real need at these small sizes, use the best looking 16x16 instead.
				size = 16.0;
			}
			element.Width = element.Height = size;
		}

	}

}