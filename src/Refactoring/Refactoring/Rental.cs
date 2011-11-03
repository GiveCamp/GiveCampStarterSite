namespace Refactoring
{
    public class Rental
    {
        public Movie Movie { get; set; }

        public int DaysRented { get; set; }

        public Rental(Movie movie, int daysRented)
        {
            this.Movie = movie;
            this.DaysRented = daysRented;
        }
    }
}