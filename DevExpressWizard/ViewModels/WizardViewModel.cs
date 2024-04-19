using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;

namespace DevExpressWizard.ViewModels
{
    public class WizardViewModel : ViewModelBase
    {
        public enum Page
        {
            First,
            Second,
            Third
        }
        private string _first;
        public string First
        {
            get
            {
                return _first;
            }
            set
            {
                _first = value;
                RaisePropertiesChanged(nameof(First), nameof(CanGoNext));
            }
        }
        private string _second;
        public string Second
        {
            get
            {
                return _second;
            }
            set
            {
                _second = value;
                RaisePropertiesChanged(nameof(Second), nameof(CanGoNext));
            }
        }
        private string _third;
        public string Third
        {
            get
            {
                return _third;
            }
            set
            {
                _third = value;
                RaisePropertiesChanged(nameof(Third), nameof(CanGoNext));
            }
        }
        public bool CanGoNext
        {
            get 
            {
                return IsValid((Page)SelectedIndex);
            }
        }
        private int _selectedIndex;
        public int SelectedIndex { 
            get
            {
                return _selectedIndex;
            }
            set
            {
                _selectedIndex = value;
                RaisePropertiesChanged(nameof(SelectedIndex), nameof(CanGoNext));
            }
        }
        [Command]
        public void Finish()
        {

        }
        private bool IsValid(Page page)
        {
            if (page == Page.First)
            {
                return !string.IsNullOrEmpty(_first);
            }
            else if (page == Page.Second)
            {
                return !string.IsNullOrEmpty(_second);
            }
            else if (page == Page.Third)
            {
                return !string.IsNullOrEmpty(_third);
            }
            return false;
        }
    }
}
