using System;
using System.Collections.Generic;

namespace MyFinance.Models
{
    public struct ConversionRateResponse
    {
        public Boolean Success { get; init; }
        public string Terms { get; init; }
        public Int64 Timestamp { get; init; }
        public string Source { get; init; }
        public Dictionary<string, double> Quotes { get; init; }
    }
}


