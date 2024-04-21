using DevExpress.Xpf.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevExpressWizard.Views
{
    internal class CustomWizardLocalizer : WizardLocalizer
    {
        protected override void PopulateStringTable()
        {
            base.PopulateStringTable();

            AddString(WizardStringId.NextButtonText, "Dalej");
            AddString(WizardStringId.BackButtonText, "Cofnij");
            AddString(WizardStringId.CancelButtonText, "Anuluj");
            AddString(WizardStringId.FinishButtonText, "Zatwierdź");
        }
    }
}
