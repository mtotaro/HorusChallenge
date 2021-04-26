﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Horus.Core.Models
{
    public class Challenge
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CurrentPoints { get; set; }
        public int TotalPoint { get; set; }
    }
}
