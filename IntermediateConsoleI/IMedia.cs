using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntermediateConsoleI
{
    /// <summary>
    /// This interface implements properties and methods
    /// that describe media such as movies, books, or games
    /// with common characteristics
    /// </summary>
    interface IMedia
    {
        #region properties

        // Identification value for a media object
        int ID { get; set; }

        // Title for the media
        string Title { get; set; }

        // Name of the media’s publisher
        string Publisher { get; set; }

        //Name of the media’s creator
        string Creator { get; set; }

        // Date the media was published
        DateTime PublishDate { get; set; }

        #endregion properties

        #region methods

        // Method that returns the age of the media in years based on the
        // difference between the current date and PublishDate
        int GetAge();

        // Method that outputs a string representation of the media object
        // to the console window
        void Print();

        #endregion methods

    } // end of interface
} // end of namespace
