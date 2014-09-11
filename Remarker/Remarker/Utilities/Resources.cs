﻿// ***********************************************************************
// Assembly         : Remarker
// Solution         : CommentPlus
// File name        : Resources.cs
// Author           : Gil Yoder
// Created          : 08 29,  2014
//
// Last Modified By : Gil Yoder
// Last Modified On : 08 29, 2014
// ***********************************************************************

namespace YoderZone.Extensions.OptionsPackage.Remarker.Utilities
{
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Media;

using Microsoft.VisualStudio.Text.Tagging;

/// <summary>
/// A resources.
/// </summary>
public static class Resources
{
    #region Static Fields

    public static readonly List<ITagSpan<ClassificationTag>> EmptyTags = new
    List<ITagSpan<ClassificationTag>>();

    public static string ConvertColorToString(this System.Drawing.Color color)
    {
        var colorString = string.Format("{0:x2}{1:x2}{2:x2}", color.R, color.G,
                                        color.B);
        return colorString;
    }

    public static string ConvertWpfColorToString(this
            System.Windows.Media.Color color)
    {
        var colorString = string.Format("{0:x2}{1:x2}{2:x2}", color.R, color.G,
                                        color.B);
        return colorString;
    }

    public static Color ConvertStringToWpfColor(this string colorString)
    {
        var result = Colors.Black;
        if (string.IsNullOrEmpty(colorString))
        {
            return result;
        }

        try
        {
            string redField = colorString.Substring(0, 2);
            string greenField = colorString.Substring(2, 2);
            string blueField = colorString.Substring(4, 2);

            byte redByte = redField.ConvertColorComponentToByte();
            var greenByte = greenField.ConvertColorComponentToByte();
            var blueByte = blueField.ConvertColorComponentToByte();

            result = Color.FromArgb(255, redByte, greenByte, blueByte);
        }
        catch (Exception ex)
        {
        }

        return result;
    }

    public static System.Drawing.Color ConvertStringToColor(
        this string colorString)
    {
        var result = System.Drawing.Color.Black;
        if (string.IsNullOrEmpty(colorString))
        {
            return result;
        }

        try
        {
            string redField = colorString.Substring(0, 2);
            string greenField = colorString.Substring(2, 2);
            string blueField = colorString.Substring(4, 2);

            byte redByte = redField.ConvertColorComponentToByte();
            var greenByte = greenField.ConvertColorComponentToByte();
            var blueByte = blueField.ConvertColorComponentToByte();

            result = System.Drawing.Color.FromArgb(redByte, greenByte, blueByte);
        }
        catch (Exception ex)
        {
        }

        return result;
    }

    public static byte ConvertColorComponentToByte(this string colorComponent)
    {
        if (colorComponent == null || colorComponent.Length != 2)
        {
            throw new ArgumentException("colorComponent");
        }

        colorComponent = colorComponent.ToLower();
        return (byte)(colorComponent[0].ConvertHexCharToDecimal() * 16 +
                      colorComponent[1].ConvertHexCharToDecimal());

    }

    public static byte ConvertHexCharToDecimal(this char hexChar)
    {
        switch (hexChar)
        {
            case '0':
            case '1':
            case '2':
            case '3':
            case '4':
            case '5':
            case '6':
            case '7':
            case '8':
            case '9':
                return (byte)(hexChar - '0');
            case 'a':
            case 'b':
            case 'c':
            case 'd':
            case 'e':
            case 'f':
                return (byte)(hexChar - 'a' + 10);
            default:
                throw new ArgumentException("hexChar");
        }
    }

    /// <summary>
    /// The bug color.
    /// </summary>
    public static readonly Color BugColor = Colors.Red;

    /// <summary>
    /// The hack color.
    /// </summary>
    public static readonly Color HackColor = Colors.Chocolate;

    /// <summary>
    /// The normal comment color.
    /// </summary>
    public static readonly Color NormalCommentColor = Colors.Green;

    /// <summary>
    /// The normal important color.
    /// </summary>
    public static readonly Color NormalImportantColor = Colors.Red;

    /// <summary>
    /// The normal question color.
    /// </summary>
    public static readonly Color NormalQuestionColor = Colors.Blue;

    /// <summary>
    /// The normal strikeout color.
    /// </summary>
    public static readonly Color NormalStrikeoutColor = Colors.Gray;

    /// <summary>
    /// The note color.
    /// </summary>
    public static readonly Color NoteColor = Colors.BlueViolet;

    /// <summary>
    /// The question color.
    /// </summary>
    public static readonly Color QuestionColor = Colors.Green;

    /// <summary>
    /// The todo color.
    /// </summary>
    public static readonly Color TodoColor = Colors.Blue;

    #endregion
}
}