﻿using Energym.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Energym.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UnidadMedidaPage2 : ContentPage
    {
        public UnidadMedidaPage2()
        {
            BindingContext = new UnidadMedidaViewModel();
            InitializeComponent();
        }
    }
}