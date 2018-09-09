using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntermediateConsoleI
{
    /// <summary>
    /// This class describes a Book object with properties
    /// and methods required by the IMedia interface as
    /// well as custom book characteristics 
    /// </summary>
    class Book : IMedia
    {
        #region fields

        // Private Fields for the Properties
        private int _ID;
        private string _Title;
        private string _Publisher;
        private string _Creator;
        private DateTime _PublishDate;
        private int _Pages;

        // Object for the GetAge() method Time Span 
        private TimeSpan diff;

        #endregion fields

        #region properties

        // Book identification number
        public int ID
        {
            get { return _ID; }

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

        // Book title
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

        // Name of the book’s publisher or production company
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

        // Name of the book’s creator
        public string Creator
        {
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

        // Date the book was released
        public DateTime PublishDate
        {
            get
            {
                return _PublishDate;
            }
            set
            {
                if (value.CompareTo(DateTime.MinValue) > 0)
                {
                    _PublishDate = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("PublishDate: Date must be greater than the minimum DateTime");
                }
            }
        } // end of PublishDate

        // Number of Pages
        public int Pages
        {
            get { return _Pages; }

            set
            {
                // Must be > 0
                if (value > 0)
                {
                    _Pages = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Pages: The value must be greater than zero");
                }
            }
        } // end of property Pages

        #endregion properties

        #region constructors

        // Default constructor 
        public Book() : this(999, "Unknown", "Unknown", "Unknown", DateTime.Now, 1)
        {
            // Default constructor per the requirements
        }

        // fully parameterized constructor
        public Book(int iD, string title, string publisher, string creator, DateTime publishDate, int pages)
        {
            ID = iD;
            Title = title;
            Publisher = publisher;
            Creator = creator;
            PublishDate = publishDate;
            Pages = pages;
        }

        #endregion constructors

        #region methods

        // Method that returns the age of the book in years based on the
        // difference between the current date and PublishDate.
        public int GetAge()
        {
            diff = DateTime.Now.Subtract(PublishDate);
            return diff.Days / 365;
        }

        // Method that outputs a string representation of the book object to
        // the console window
        public void Print()
        {
            Console.WriteLine($"Book:  {ID,9} {Title,-10} {Publisher,-10} {Creator,-10} {PublishDate,10:d} {Pages,4}");
        }

        #endregion methods

    } // end of book class
} // end of namespace
