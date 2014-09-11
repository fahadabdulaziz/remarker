﻿// ***********************************************************************
// Assembly         : Options.Dialog
// Solution         : YoderZone.Com.Extensions
// File name        : BooleanToFontWeightConverter.cs
// Author           : Gil Yoder
// Created          : 09 09,  2014
//
// Last Modified By : Gil Yoder
// Last Modified On : 09 09, 2014
// ***********************************************************************
namespace YoderZone.Extensions.OptionsDialog.ViewModel
{
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

public class BooleanToFontWeightConverter : IValueConverter
{
    /// <summary>
    /// Converts a value.
    /// </summary>
    /// <returns>
    /// A converted value. If the method returns null, the valid null value is used.
    /// </returns>
    /// <param name="value">The value produced by the binding source.</param><param name="targetType">The type of the binding target property.</param><param name="parameter">The converter parameter to use.</param><param name="culture">The culture to use in the converter.</param>
    public object Convert(object value, Type targetType, object parameter,
                          CultureInfo culture)
    {
        return ((bool)value) ? FontWeights.Bold : FontWeights.Normal;
    }

    /// <summary>
    /// Converts a value.
    /// </summary>
    /// <returns>
    /// A converted value. If the method returns null, the valid null value is used.
    /// </returns>
    /// <param name="value">The value that is produced by the binding target.</param><param name="targetType">The type to convert to.</param><param name="parameter">The converter parameter to use.</param><param name="culture">The culture to use in the converter.</param>
    public object ConvertBack(object value, Type targetType, object parameter,
                              CultureInfo culture)
    {
        return null;
    }
}
}