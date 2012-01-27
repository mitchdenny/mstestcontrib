using System;
using WpfTodo.ViewModel;

namespace WpfTodo.Model
{
    public class Task : ViewModelBase
    {
        private string _title;
        private string _description;
        private DateTime? _dueDate;

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                RaisePropertyChanged(() => Title);
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                RaisePropertyChanged(() => Description);
            }
        }

        public DateTime? DueDate
        {
            get { return _dueDate; }
            set
            {
                _dueDate = value;
                RaisePropertyChanged(() => DueDate);
            }
        }
    }
}