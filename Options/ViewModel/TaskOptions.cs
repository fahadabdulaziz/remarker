﻿// ***********************************************************************
// Assembly         : Options.Dialog
// Solution         : YoderZone.Com.Extensions
// File name        : TaskOptionsControl.cs
// Author           : Gil Yoder
// Created          : 09 07,  2014
//
// Last Modified By : Gil Yoder
// Last Modified On : 09 07, 2014
// ***********************************************************************

namespace YoderZone.Extensions.Options.ViewModel
{
#region Imports

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

using global::Options;

    #endregion

/// <summary>
///     A task's options.
/// </summary>
/// <seealso cref="T:System.ComponentModel.INotifyPropertyChanged" />
public class TaskOptions : INotifyPropertyChanged
{
    #region Static Fields

    #endregion

    #region Fields

    /// <summary>
    ///     The tasks.
    /// </summary>
    private readonly ObservableCollection<TaskAttributes> tasks;

    /// <summary>
    ///     The selected color.
    /// </summary>
    private Color selectedColor = Colors.Beige;

    /// <summary>
    ///     true to selected font weight.
    /// </summary>
    private bool selectedFontWeight;

    /// <summary>
    ///     The selected name.
    /// </summary>
    private string selectedName;

    private TaskAttributes selectedTask;

    private FontAttributes selectedFontFamily;

    // private string selectedFont;

    #endregion

    #region Constructors and Destructors

    /// <summary>
    ///     Prevents a default instance of the
    ///     YoderZone.Extensions.OptionsDialog.ViewModel.TaskOptionsControl class from being
    ///     created.
    /// </summary>
    public TaskOptions()
    {
        this.tasks = new ObservableCollection<TaskAttributes>();
        this.FontFamilies = FontHelper.FontFamilies;
        this.SelectedFontFamily = FontHelper.Verdana;

    }

    public FontAttributes SelectedFontFamily
    {
        get
        {
            return this.selectedFontFamily;
        }
        private set
        {
            if (value == this.selectedFontFamily)
            {
                return;
            }
            this.selectedFontFamily = value;
            OnPropertyChanged();
        }
    }

    public List<FontAttributes> FontFamilies { get; private set; }

    #endregion

    #region Public Events

    /// <summary>
    ///     Occurs when a property value changes.
    /// </summary>
    public event PropertyChangedEventHandler PropertyChanged;

    #endregion

    #region Public Properties

    // public List<string> FontNames { get; set; }

    /// <summary>
    ///     Gets or sets the selected color.
    /// </summary>
    /// <value>
    ///     The color of the selected.
    /// </value>
    public Color SelectedColor
    {
        get
        {
            return this.selectedColor;
        }
        set
        {
            this.selectedColor = value;
            this.OnPropertyChanged();
        }
    }

    /// <summary>
    ///     Gets or sets a value indicating whether the selected font weight.
    /// </summary>
    /// <value>
    ///     true if selected font weight, false if not.
    /// </value>
    public bool SelectedFontWeight
    {
        get
        {
            return this.selectedFontWeight;
        }
        set
        {
            this.selectedFontWeight = value;
            this.OnPropertyChanged();
        }
    }

    /// <summary>
    ///     Gets or sets the selected name.
    /// </summary>
    /// <value>
    ///     The name of the selected.
    /// </value>
    public string SelectedName
    {
        get
        {
            return this.selectedName;
        }
        set
        {
            this.selectedName = string.IsNullOrWhiteSpace(value) ? null :
                                value.Trim();
            this.OnPropertyChanged();
        }
    }

    /// <summary>
    ///     Gets the tasks.
    /// </summary>
    /// <value>
    ///     The tasks.
    /// </value>
    public ObservableCollection<TaskAttributes> Tasks
    {
        get
        {
            return this.tasks;
        }
    }

    public TaskAttributes SelectedTask
    {
        get
        {
            return this.selectedTask;
        }
        set
        {
            if (this.selectedTask != null)
            {
                this.selectedTask.PropertyChanged -= this.selectedTask_PropertyChanged;
            }

            this.selectedTask = value;

            if (this.selectedTask != null)
            {
                this.selectedTask.PropertyChanged += this.selectedTask_PropertyChanged;
            }
            this.OnPropertyChanged();
            if(value == null)
            {
                return;
            }

            this.SelectedColor = value.Color;
            this.SelectedFontWeight = value.IsBold;
            this.SelectedName = value.Name;
            this.SelectedFontFamily = value.Typeface;
        }
    }

    private void selectedTask_PropertyChanged(object sender,
            PropertyChangedEventArgs e)
    {
        switch (e.PropertyName)
        {
            case "Typeface":
                this.SelectedFontFamily = this.selectedTask.Typeface;
                break;
            case "Name":
                this.SelectedName = this.selectedTask.Name;
                break;
            case "IsBold":
                this.SelectedFontWeight = this.selectedTask.IsBold;
                break;
            case "Color":
                this.SelectedColor = this.selectedTask.Color;
                break;
        }
    }

    //public string SelectedFont
    //{
    //    get
    //    {
    //        return this.selectedFont;
    //    }
    //    set
    //    {
    //        this.selectedFont = value;
    //        this.OnPropertyChanged();
    //    }
    //}

    #endregion

    #region Public Methods and Operators


    public void LoadTasks(IEnumerable<TaskAttributes> taskInstances)
    {
        this.Tasks.Clear();
        foreach (var taskInstance in taskInstances)
        {
            this.Tasks.Add(taskInstance);
        }

        if (this.Tasks.Count != 10)
        {
            throw new ArgumentOutOfRangeException("taskInstances");
        }
    }

    #endregion

    #region Methods

    /// <summary>
    ///     Executes the property changed action.
    /// </summary>
    /// <param name="propertyName" type="string">
    ///     Name of the property.
    /// </param>
    protected virtual void OnPropertyChanged([CallerMemberName] string
            propertyName = null)
    {
        PropertyChangedEventHandler handler = this.PropertyChanged;
        if (handler != null)
        {
            handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    #endregion
}
}