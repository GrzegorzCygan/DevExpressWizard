using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;

namespace DevExpressWizard.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        protected IDocumentManagerService DocumentManagerService { get { return GetService<IDocumentManagerService>(); } }

        [Command]
        public void OpenWizard(object o)
        {
            var document = DocumentManagerService.CreateDocument("Wizard", new WizardViewModel());
            document.Title = "wizard";
            document.Show();
        }
    }
}
