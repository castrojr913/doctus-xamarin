using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Autofac;
using TipsExam.Model.Domain;
using TipsExam.Model.Dto;
using TipsExam.Model.Persistence;
using TipsExam.Page;
using TipsExam.Utilities;
using Xamarin.Forms;
using static TipsExam.AppSettings;

namespace TipsExam.ViewModel
{
    /// <summary>
    /// TipCollectionViewModel
    /// </summary>
    public class TipCollectionViewModel : BaseViewModel
    {
        
        private bool _isBusy;
        private bool _isNoneVisible;
        private bool _isCollectionVisible;
        private readonly ITipDomain _domain;
        private ObservableCollection<TipViewModel> _items { get; set; }
        private List<Tip> _itemsData { get; set; }

        #region COMMANDS

        public ICommand GetTipsCommand { get; set; }
        public ICommand NewTipCommand { get; set; }
        public ICommand ShowTipCommand { get; set; }
        public ICommand RemoveTipCommand { get; set; }

        #endregion

        public TipCollectionViewModel()
        {
            _domain = DependencyInjector.Resolve<ITipDomain>();
            // Setup commands
            GetTipsCommand = new Command(async () => await GetTips(), () => true);
            ShowTipCommand = new Command(async item => await ShowTip(item as TipViewModel), item => true);
            RemoveTipCommand = new Command(item => RemoveTip(item as TipViewModel), item => true);
        }

        #region BINDABLE_PROPS

        public ObservableCollection<TipViewModel> Items
        {
            get => _items;
            set { _items = value; NotifyPropertyChanged(); }
        }

        public bool IsNoneVisible
        {
            get => _isNoneVisible;
            set { _isNoneVisible = value; NotifyPropertyChanged(); }
        }

        public bool IsCollectionVisible
        {
            get => _isCollectionVisible;
            set { _isCollectionVisible = value; NotifyPropertyChanged(); }
        }

        #endregion

        #region ACTIONS

        public void Update() => GetTipsCommand.Execute(true);

        private async Task GetTips()
        {
            if (_isBusy) return;
            _isBusy = true;
            _itemsData = await _domain.GetTips();
            _itemsData = _itemsData.OrderBy(x => x.DateTime).Reverse().ToList(); // Sort by time
            IsCollectionVisible = _itemsData.Count != 0;
            IsNoneVisible = !IsCollectionVisible;
            Items = new ObservableCollection<TipViewModel>();
            foreach (var item in _itemsData)
            {
                Items.Add(new TipViewModel
                {
                    Id = item.Id,
                    Title = item.Title,
                    Description = item.Description,
                    Date = DateHelper.Parse(item.Date, DefaultDateFormat)
                });
            }
            _isBusy = false;
        }

        private async Task ShowTip(TipViewModel item = default(TipViewModel))
        {
            if (_isBusy) return;
            _isBusy = true;
            var isDefault = item == default(TipViewModel);
            var dto = new TipDto { Description = item?.Description, Title = item?.Title, Date = isDefault ? DateTime.Now : item.Date };
            await Application.Current.MainPage.Navigation.PushAsync(new TipPage { Data = dto  });
            _isBusy = false;
        }

        private void RemoveTip(TipViewModel item)
        {
            _domain.RemoveTip(item.Id);
            Update();
        }

        #endregion

    }
}
