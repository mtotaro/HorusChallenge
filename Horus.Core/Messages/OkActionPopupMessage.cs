using System;
using System.Collections.Generic;
using System.Text;

namespace Horus.Core.Messages
{
    public class OkActionPopupMessage
    {
        private string title;

        public string Title { get => title; set => title = value?.ToUpper(); }

        public string Description { get; set; }
    }
}
