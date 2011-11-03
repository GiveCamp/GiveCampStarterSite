namespace Refactoring
{
    using System.Collections;
    using System.Collections.Generic;

    public class Customer
    {
        private List<Rental> Rentals { get; set; }

        public string Name { get; set; }

        public Customer(string name)
        {
            this.Name = name;
        }

        public string Statement()
        {
            double totalAmount = 0;
            int frequentRentalPoints = 0;
            IEnumerable<Rental> rentals = this.Rentals;

            string result = "Rental Record for " + Name + "\n";

            foreach (var rental in rentals)
            {
                double thisAmount = 0;

                switch (rental.Movie.PriceCode)
                {
                    case Movie.Regular:
                        {
                            thisAmount += 2;
                            if (rental.DaysRented > 2) thisAmount += (rental.DaysRented - 2 * 1.5);
                            break;
                        }

                    case Movie.NewRelease:
                        {
                            thisAmount += rental.DaysRented * 3;
                            break;
                        }

                    case Movie.Children:
                        {
                            thisAmount += 1.5;
                            if (rental.DaysRented > 3) thisAmount += (rental.DaysRented - 3 * 1.5);
                            break;
                        }
                }

                // add frequent rental points
                frequentRentalPoints++;

                // add bonus for a two day new releast rental
                if (rental.Movie.PriceCode == Movie.NewRelease && rental.DaysRented > 1) frequentRentalPoints++;

                // Show figures for the Rental
                result += "\t" + rental.Movie.Title + "\t" + thisAmount + "\n";

                totalAmount += thisAmount;
            }

            // Add footer lines
            result += "Amount owed is " + totalAmount + "\n";
            result += "You earned " + frequentRentalPoints + " frequent renter points";

            return result;
        }
    }
}