using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Refactoring
{
    public class Movie
    {
        public const int Children = 2;

        public const int Regular = 0;

        public const int NewRelease = 1;

        public string Title { get; set; }

        public int PriceCode { get; set; }

        public Movie(string title, int priceCode)
        {
            this.Title = title;
            this.PriceCode = priceCode;
        }
    }
}
