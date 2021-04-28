using System;
using System.Collections.Generic;
using System.Text;

namespace Horus.Core.Models
{
    public class Challenge
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float CurrentPoints { get; set; }
        public float TotalPoints { get; set; }
        public double PercentageBar
        {
            get => Math.Round(CurrentPoints/TotalPoints,1);
            set => PercentageBar = value;
        }
        public double PercentageCompleted
        {
            get => Math.Round((CurrentPoints*100) / TotalPoints, 1);
            set => PercentageCompleted = value;
        }

        public bool IsCompletedChallenge
        {
            get => CurrentPoints == TotalPoints;
            set => IsCompletedChallenge = value;
        }

    }
}
