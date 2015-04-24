using ConfDude.Infrastructure;
using ConfDude.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;
using DataContracts;

namespace ConfDude.ViewModels
{
    public class MainViewModel : ModelBase
    {
        private SpeakerService _speakerService;

        public MainViewModel()
        {
            this.State = "Normal";
            _speakerService = new SpeakerService();
            this.SpeakerList = new ObservableCollection<SpeakerDto>(_speakerService.GetSpeakerList());
            this.SpeakerView = new ListCollectionView(this.SpeakerList);
            this.SpeakerEditView = this.SpeakerView as IEditableCollectionView;
            this.SpeakerViewLive = this.SpeakerView as ICollectionViewLiveShaping;

            this.SpeakerViewLive.IsLiveFiltering = true;
            this.SpeakerViewLive.LiveFilteringProperties.Add("FirstName");

            //this.SpeakerEditView.EditItem(this.SpeakerView.CurrentItem);


            this.SpeakerView.CurrentChanged += SpeakerView_CurrentChanged;
            this.SpeakerView.SortDescriptions.Add(new SortDescription("FirstName", ListSortDirection.Ascending));
            //this.SpeakerView.Filter = (item) => ((SpeakerDto)item).FirstName.StartsWith("Christian");
            this.SpeakerView.MoveCurrentToLast();

            this.EditCommand = new DelegateCommand(this.CanExecuteEditCommand, this.ExecuteEditCommand);
            this.OkCommand = new DelegateCommand(this.CanExecuteOkCommand, this.ExecuteOkCommand);
            this.CancelCommand = new DelegateCommand(this.CanExecuteCancelCommand, this.ExecuteCancelCommand);
        }

        void SpeakerView_CurrentChanged(object sender, System.EventArgs e)
        {
        }

        private ObservableCollection<SpeakerDto> _speakerList;
        public ObservableCollection<SpeakerDto> SpeakerList
        {
            get { return _speakerList; }
            set { _speakerList = value; this.OnPropertyChanged(); }
        }

        private ICollectionView _speakerView;
        public ICollectionView SpeakerView
        {
            get { return _speakerView; }
            set { _speakerView = value; }
        }

        private IEditableCollectionView _speakerEditView;
        public IEditableCollectionView SpeakerEditView
        {
            get { return _speakerEditView; }
            set { _speakerEditView = value; this.OnPropertyChanged(); }
        }

        private ICollectionViewLiveShaping _speakerViewLive;
        public ICollectionViewLiveShaping SpeakerViewLive
        {
            get { return _speakerViewLive; }
            set { _speakerViewLive = value; }
        }

        private ICommand _editCommand;
        public ICommand EditCommand
        {
            get { return _editCommand; }
            set { _editCommand = value; this.OnPropertyChanged(); }
        }

        private ICommand _okCommand;
        public ICommand OkCommand
        {
            get { return _okCommand; }
            set { _okCommand = value; this.OnPropertyChanged(); }
        }

        private ICommand _cancelCommand;
        public ICommand CancelCommand
        {
            get { return _cancelCommand; }
            set { _cancelCommand = value; this.OnPropertyChanged(); }
        }

        private string _state;
        public string State
        {
            get { return _state; }
            set { _state = value; this.OnPropertyChanged(); }
        }

        private bool CanExecuteEditCommand(object parameter)
        {
            return this.SpeakerView != null && this.SpeakerView.CurrentItem != null &&
                !(this.SpeakerEditView.IsEditingItem &&
                this.SpeakerEditView.IsAddingNew);
        }

        private void ExecuteEditCommand(object parameter)
        {
            this.SpeakerEditView.EditItem(this.SpeakerView.CurrentItem);
            this.RefreshCommands();
            this.State = "Edit";
        }

        private bool CanExecuteOkCommand(object parameter)
        {
            return this.SpeakerView != null && this.SpeakerView.CurrentItem != null &&
                (this.SpeakerEditView.IsEditingItem ||
                this.SpeakerEditView.IsAddingNew);
        }

        private void ExecuteOkCommand(object parameter)
        {
            this.SpeakerEditView.CommitEdit();
            this.RefreshCommands();
            this.State = "Normal";

        }

        private bool CanExecuteCancelCommand(object parameter)
        {
            return this.SpeakerView != null && this.SpeakerView.CurrentItem != null &&
                (this.SpeakerEditView.IsEditingItem ||
                this.SpeakerEditView.IsAddingNew);
        }

        private void ExecuteCancelCommand(object parameter)
        {
            this.SpeakerEditView.CancelEdit();
            this.RefreshCommands();
            this.State = "Normal";
        }

        private void RefreshCommands()
        {
            this.EditCommand.CanExecute(null);
            this.OkCommand.CanExecute(null);
            this.CancelCommand.CanExecute(null);
        }
    }
}
