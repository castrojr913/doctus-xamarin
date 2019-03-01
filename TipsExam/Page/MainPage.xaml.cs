using TipsExam.ViewModel;
using Xamarin.Forms;

namespace TipsExam
{
    /// <summary>
    /// Main page.
    /// </summary>
    public partial class MainPage : ContentPage
    {

        private TipCollectionViewModel _viewModel { get; set; }

        public MainPage()
        {
            InitializeComponent();
            _viewModel = BindingContext as TipCollectionViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.Update();
        }

    }
}
