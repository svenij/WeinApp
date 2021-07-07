﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using WeinApp.Models;
using WeinApp.Services;
using WeinApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeinApp.Views
{
    public partial class NewWinePage : ContentPage
    {
        public Wine Wine { get; set; }

        public NewWinePage()
        {
            InitializeComponent();
            BindingContext = new NewWineViewModel();
        }
    }
}