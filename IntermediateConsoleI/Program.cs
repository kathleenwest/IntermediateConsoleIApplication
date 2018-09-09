using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace IntermediateConsoleI
{
    class Program
    {
        static List<IMedia> media = new List<IMedia>();     // List IMedia Interface objects
        static Movie movie = null;                          // Holds the movie object for adding to the list
        static Book book = null;                            // Holds the book object for adding to the list
        static Game game = null;                            // Holds the game object for adding to the list
        static MenuChoices choice;                          // Enum for user menu choice, Initialized for while loop logic

        /// <summary>
        /// Main entry for the program of IntermediateConsoleI
        /// Kathleen West
        /// </summary>
        /// <param name="args">No arguments are processed</param>
        static void Main(string[] args)
        {
            // User Prompt Loop and Main Program Loop
            do
            {
                // Parse and Validate the User Data Entry before proceeding to the Menu calls
                choice = ConsoleHelpers.ReadEnum<MenuChoices>("Please choose from the following menu options:");

                //if (Enum.TryParse(Console.ReadLine(), out choice))
                if (Enum.IsDefined(typeof(MenuChoices), choice))
                {
                    // Calls to Method based on user choice
                    switch (choice)
                    {
                        case MenuChoices.AddMovie:     // Choice for Adding a Movie item
                            AddMovie();
                            break;
                        case MenuChoices.AddBook:     // Choice for Adding a Book item
                            AddBook();
                            break;
                        case MenuChoices.AddGame:     // Choice for Adding a Game item
                            AddGame();
                            break;
                    } // end of switch

                    Console.WriteLine();
                } // end of if

            } while (choice != MenuChoices.Quit); // end of while

            // Pause the program for user to observe Console
            Console.Write("Press <Enter> to quit...");
            Console.ReadLine();

        } // end of Main method

        /// <summary>
        /// Method allows the user to add a Movie object while validating
        /// the user input
        /// </summary>
        public static void AddMovie()
        {

            try
            {
                // Prompt the User to Add Movie Properties
                int _ID = ConsoleHelpers.ReadInt("Enter movie ID:", 1, 999999999);
                string _Title = ConsoleHelpers.ReadString("Enter movie title:", 1, 10);
                string _Publisher = ConsoleHelpers.ReadString("Enter movie producer/publisher:", 1, 10);
                string _Creator = ConsoleHelpers.ReadString("Enter movie screenwriter:", 1, 10);
                DateTime _PublishDate = ConsoleHelpers.ReadDate("Enter release date:", Movie.EarlyDate, DateTime.Now);
                int _RunLength = ConsoleHelpers.ReadInt("Enter run length:", 1, 9999);
                Ratings _Rating = ConsoleHelpers.ReadEnum<Ratings>("Movie rating:");

                // Try to Create a Movie Object

                movie = new Movie(_ID, _Title, _Publisher, _Creator, _PublishDate, _RunLength, _Rating);
                media.Add(movie);
                Console.WriteLine($"Movie Age: {movie.GetAge()} years");
                Print();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Your movie entry did not meet business logic rules. Try Again.");
                Console.WriteLine(ex.Message);
            }

        } // end of AddMovie() method

        /// <summary>
        /// Method allows the user to add a Book object while validating
        /// the user input
        /// </summary>
        public static void AddBook()
        {
            try
            {
                // Prompt the User to Add Book Properties
                int _ID = ConsoleHelpers.ReadInt("Enter book ID:", 1, 999999999);
                string _Title = ConsoleHelpers.ReadString("Enter book title:", 1, 10);
                string _Publisher = ConsoleHelpers.ReadString("Enter book publisher:", 1, 10);
                string _Creator = ConsoleHelpers.ReadString("Enter book author:", 1, 10);
                DateTime _PublishDate = ConsoleHelpers.ReadDate("Enter release date:", DateTime.MinValue, DateTime.Now);
                int _Pages = ConsoleHelpers.ReadInt("Enter page length:", 1, 9999);

                // Try to Create a Book Object

                book = new Book(_ID, _Title, _Publisher, _Creator, _PublishDate, _Pages);
                media.Add(book);
                Console.WriteLine($"Book Age: {book.GetAge()} years");
                Print();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Your book entry did not meet business logic rules. Try Again.");
                Console.WriteLine(ex.Message);
            }
        } // end of AddBook() method

        /// <summary>
        /// Method allows the user to add a Game object while validating
        /// the user input
        /// </summary>
        public static void AddGame()
        {
            try
            {
                // Prompt the User to Add Game Properties
                int _ID = ConsoleHelpers.ReadInt("Enter game ID:", 1, 999999999);
                string _Title = ConsoleHelpers.ReadString("Enter game title:", 1, 10);
                string _Publisher = ConsoleHelpers.ReadString("Enter game publisher:", 1, 10);
                string _Creator = ConsoleHelpers.ReadString("Enter game author:", 1, 10);
                DateTime _PublishDate = ConsoleHelpers.ReadDate("Enter release date:", DateTime.MinValue, DateTime.Now);
                int _Players = ConsoleHelpers.ReadInt("Enter number of players:", 1, 9999);

                // Try to Create a Game Object

                game = new Game(_ID, _Title, _Publisher, _Creator, _PublishDate, _Players);
                media.Add(game);
                Console.WriteLine($"Game Age: {game.GetAge()} years");
                Print();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Your game entry did not meet business logic rules. Try Again.");
                Console.WriteLine(ex.Message);
            }

        } // end of AddGame() method

        /// <summary>
        /// Method prints all items added to the IMedia interface
        /// list through the individual object print methods via
        /// the interface.
        /// </summary>
        public static void Print()
        {
            foreach (IMedia item in media)
            {
                item.Print();
            }
            Console.WriteLine();
        } // end of Print() method

    } // end of Program class
} // end of namespace
