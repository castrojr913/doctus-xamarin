using System;
using System.Collections.Generic;
using TipsExam.Model.Dto;
using TipsExam.ViewModel;
using Xamarin.Forms;

namespace TipsExam.Page
{
    /// <summary>
    /// Tip page.
    /// </summary>
    public partial class TipPage : ContentPage
    {

        private TipViewModel _viewModel { get; set; }
        public TipDto Data { get; set; }

        public TipPage()
        {
            InitializeComponent();
            _viewModel = BindingContext as TipViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.Load(Data);
        }

    }
}
