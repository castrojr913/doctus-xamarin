using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Autofac;
using TipsExam.Model.Domain;
using TipsExam.Model.Dto;
using TipsExam.Utilities;
using Xamarin.Forms;
using static TipsExam.AppSettings;

namespace TipsExam.ViewModel
{
    /// <summary>
    /// Tip view model.
    /// </summary>
    public class TipViewModel : BaseViewModel
    {

        private bool _isBusy;
        private bool _isEditable;
        private bool _isReadonly;
        private string _title;
        private string _description;
        private string _dateFormatted;
        private DateTime _date;
        private readonly ITipDomain _domain;

        #region COMMANDS

        public ICommand RegisterTipCommand { get; set; }

        #endregion

        public TipViewModel()
        {
            _domain = DependencyInjector.Resolve<ITipDomain>();
            RegisterTipCommand = new Command(async () => await SaveTip(), () => true);
        }

        #region BINDABLE_PROPS

        public int Id { get; set; }

        public bool IsEditable
        {
            get => _isEditable;
            set { _isEditable = value;  NotifyPropertyChanged(); }
        }

        public bool IsReadonly
        {
            get => _isReadonly;
            set { _isReadonly = value; NotifyPropertyChanged(); }
        }

        public string Title
        {
            get => _title;
            set { _title = value; NotifyPropertyChanged(); }
        }

        public string Description
        {
            get => _description;
            set { _description = value; NotifyPropertyChanged(); }
        }

        public DateTime Date
        {
            get => _date;
            set { _date = value; NotifyPropertyChanged(); }
        }

        public string DateFormatted
        {
            get => DateHelper.Format(Date, DefaultDateFormat);
            set { _dateFormatted = value; NotifyPropertyChanged(); }
        }

        #endregion

            #region ACTIONS

        public void Load(TipDto dto = default(TipDto))
        {
            IsEditable = dto == default(TipDto) || string.IsNullOrEmpty(dto.Title);
            IsReadonly = !IsEditable;
            Title = dto.Title;
            Description = dto.Description;
            Date = dto.Date;
            DateFormatted = dto.DateFormatted;
        }

        private async Task SaveTip()
        {
            if (_isBusy || IsFormInvalid()) return;
            _isBusy = true;
            var domain = DependencyInjector.Resolve<ITipDomain>();
            domain.AddTip(new TipDto
            {
                Title = this.Title,
                Description = this.Description,
                Date = this.Date
            });
            await Application.Current.MainPage.Navigation.PopAsync();
            _isBusy = false;
        }

        #endregion

        #region VALIDATION

        private bool IsFormInvalid() => string.IsNullOrEmpty(this.Title) || string.IsNullOrEmpty(this.Description);

        #endregion

    }

}
