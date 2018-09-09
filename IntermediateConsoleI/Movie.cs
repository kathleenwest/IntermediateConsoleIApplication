using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntermediateConsoleI
{
    /// <summary>
    /// Ratings: Enumeration of the Movie object possible ratings
    /// </summary>
    enum Ratings
    {
        Unknown,
        G,
        PG,
        PG13,
        R,
        NC17
    }

    /// <summary>
    /// This class describes a Movie object with properties
    /// and methods required by the IMedia interface as
    /// well as custom movie characteristics 
    /// </summary>
    class Movie : IMedia
    {
        #region fields

        // Private Fields for the Properties
        private int _ID;
        private string _Title;
        private string _Publisher;
        private string _Creator;
        private DateTime _PublishDate;
        private int _RunLength;
        private Ratings _Rating;

        // Object for the GetAge() method Time Span 
        private TimeSpan diff; 

        #endregion fields

        #region properties

        // Movie identification number
        public int ID
        {
            get { return _ID;}

            set
            {
                // Must be > 0
                if (value > 0)
                {
                    _ID = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("ID: The value must be greater than zero");
                }              
            } 
        } // end of property ID

        // Movie title
        public string Title
        {
            get
            {
                return _Title;
            }
            set
            {
                // Cannot be blank
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _Title = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Title: Value must not be null, empty, or full of white space.");
                }             
            }
        } // end of property Title

        // Name of the movie’s publisher or production company
        public string Publisher
        {
            get
            {
                return _Publisher;
            }
            set
            {
                // Cannot be blank
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _Publisher = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Publisher: Value must not be null, empty, or full of white space.");
                }
            }
        } // end of property Publisher

        // Name of the movie’s screenwriter
        public string Creator {
            get
            {
                return _Creator;
            }
            set
            {
                // Cannot be blank
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _Creator = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Creator: Value must not be null, empty, or full of white space.");
                }
            }
        } // end of property Creator

        // Date the movie was released
        public DateTime PublishDate
        {
            get
            {
                return _PublishDate;
            }
            set
            {
                // DateTime Comparison for Movie PublishDate
                // Must be greater than January 1,1878 (earliest known movies)
                if (value.CompareTo(Movie.EarlyDate) > 0)
                {
                    _PublishDate = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("PublishDate: Date must be greater than January 1,1878 (earliest known movies)");
                }              
            }
        } // end of PublishDate

        // Length of the movie in minutes
        public int RunLength
        {
            get
            {
                return _RunLength;
            }
            private set
            {
                //Must be greater than 0 (seconds are rounded up to the next minute)
                if (value > 0)
                {
                    _RunLength = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("RunLength: Value must be greater than 0 (seconds are rounded up to the next minute)");
                }            
            }
        } // end of RunLength

        // MPAA rating (such as PG, R, etc.)
        public Ratings Rating
        {
            get
            {
                return _Rating;
            }
            private set
            {
                // Must be one of the values contained in the Ratings enum
                if (Enum.IsDefined(typeof(Ratings), value))
                {
                    _Rating = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Rating: Value must be one of the values contained in the Ratings enum");
                }                            
            }
        } // end of property Rating

        // Property for the Earliest Movie Date
        public static DateTime EarlyDate { get;} = new DateTime(1878, 01, 01);

        #endregion properties

        #region constructors

        /// <summary>
        /// Default constructor 
        /// </summary>
        public Movie() : this (999, "Unknown", "Unknown", "Unknown", DateTime.Now, 999, Ratings.Unknown)
        {
            // Default constructor per the requirements
        }

        /// <summary>
        /// fully parameterized constructor
        /// </summary>
        /// <param name="iD">ID of the Movie (int)</param>
        /// <param name="title">Title of the Movie (string)</param>
        /// <param name="publisher">Publisher of the Movie (string)</param>
        /// <param name="creator">Creator of the Movie (string)</param>
        /// <param name="publishDate">Publish Date of the Movie (Date)</param>
        /// <param name="runLength">Time Length of the Movie (int)</param>
        /// <param name="rating">Rating of the Movie (enumeration Ratings)</param>
        public Movie(int iD, string title, string publisher, string creator, DateTime publishDate, int runLength, Ratings rating)
        {
            ID = iD;
            Title = title;
            Publisher = publisher;
            Creator = creator;
            PublishDate = publishDate;
            RunLength = runLength;
            Rating = rating;
        }

        #endregion constructors

        #region methods

        /// <summary>
        /// Method that returns the age of the movie in years based on the
        /// difference between the current date and PublishDate.
        /// </summary>
        /// <returns>Age of Movie in Years (0 if less than 1 year old)</returns>
        public int GetAge()
        {
            diff = DateTime.Now.Subtract(PublishDate);
            return diff.Days / 365;
        }

        /// <summary>
        /// Method that outputs a string representation of the movie object to
        /// the console window
        /// </summary>
        public void Print()
        {
            Console.WriteLine($"Movie: {ID, 9} {Title, -10} {Publisher, -10} {Creator, -10} {PublishDate, 10:d} {RunLength, 4} {Rating,7}");
        }

        #endregion methods
    } // end of class
} // end of namespace
