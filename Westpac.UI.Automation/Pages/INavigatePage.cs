using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Westpac.UI.Automation.Pages
{
    public interface INavigatePage
    {
        void OpenURL();
        void ClickOnKiwiSaverCaluculatorButton();
        void ClickOnRetirementCalculatorLink();
    }
}
