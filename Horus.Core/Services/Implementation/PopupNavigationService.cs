using Horus.Core.Services.Interfaces;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Horus.Core.Services.Implementation
{
    public class PopupNavigationService : IPopupNavigationService
    {
        public async Task PopAsync()
        {
            await PopupNavigation.Instance.PopAsync();
        }
    }
}
