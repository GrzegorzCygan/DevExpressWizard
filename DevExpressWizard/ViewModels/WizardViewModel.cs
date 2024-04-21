using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace DevExpressWizard.ViewModels
{
    public class WizardViewModel : ViewModelBase, IDataErrorInfo
    {
        public WizardViewModel() 
        {
            FirstValues = new ObservableCollection<string>(new string[] { "Ala", "Ola", "Ela" });
            SecondValues = new ObservableCollection<string>();
            for (int i = 1; i < 100; i++)
            {
                SecondValues.Add($"Value{i}");
            }
            SetupValidators();
        }
        public enum Page
        {
            First,
            Second,
            Third
        }
        private string _first;
        public virtual ObservableCollection<string> FirstValues { get; set; }
        public virtual ObservableCollection<string> SecondValues { get; set; }
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
        class Validator
        {
            public string FieldName { get; set; }
            public Func<string> ExecValidate { get; set; }
            public Validator(string fieldName, Func<string> execValidate)
            {
                FieldName = fieldName;
                ExecValidate = execValidate;
            }
        }
        List<Validator> validators = new List<Validator>();
        private void SetupValidators()
        {
            validators.Add(new Validator(nameof(First), () =>
            {
                if (string.IsNullOrEmpty(First))
                {
                    return "Wymagany";
                }
                return null;
            }));

            validators.Add(new Validator(nameof(Second), () =>
            {
                if (string.IsNullOrEmpty(Second))
                {
                    return "Wymagany";
                }
                return null;
            }));

            validators.Add(new Validator(nameof(Third), () =>
            {
                if (string.IsNullOrEmpty(Third))
                {
                    return "Wymagany";
                }
                return null;
            }));
        }
        public string Error => "Błąd";

        public string this[string columnName]
        {
            get
            {
                foreach (var validator in validators.Where(v => v.FieldName == columnName))
                {
                    string error = validator.ExecValidate();
                    if (!string.IsNullOrEmpty(error))
                    {
                        return error;
                    }
                }
                return null;
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
                return string.IsNullOrEmpty(this[nameof(First)]) &&
                       string.IsNullOrEmpty(this[nameof(Second)]) &&
                       string.IsNullOrEmpty(this[nameof(Third)]);
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
