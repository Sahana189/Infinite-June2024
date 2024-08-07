using Railwayproject;
using Railwayproject.Models;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Railwayproject
{
    class Program
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["RailwayReservationsDB"].ConnectionString;
        private static readonly UserService userService = new UserService(connectionString);
        private static readonly AdminService adminService = new AdminService(connectionString);

        static void Main(string[] args)
        {
            var bookingService = new BookingService(connectionString);
            var trainService = new TrainService(connectionString);
            Console.WriteLine("Welcome to Railway Reservations");

            while (true)
            {
                Console.WriteLine("1. User");
                Console.WriteLine("2. Admin");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            UserAuthentication();
                            UserPage(bookingService, trainService);
                            break;
                        case 2:
                            AdminAuthentication();
                            AdminPage(trainService, bookingService);
                            break;
                        case 3:
                            return;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }
            }
        }

        static void UserAuthentication()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("*User Authentication*");
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Back");
                Console.Write("Choose an option: ");

                if (int.TryParse(Console.ReadLine(), out int authChoice))
                {
                    switch (authChoice)
                    {
                        case 1:
                            RegisterUser();
                            break;
                        case 2:
                            if (LoginUser())
                            {
                                Console.WriteLine("Login successful!");
                                return; // Exit authentication loop and proceed to UserPage
                            }
                            else
                            {
                                Console.WriteLine("Login failed! Please try again.");
                            }
                            break;
                        case 3:
                            return; // Back to main menu
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        static void RegisterUser()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine(); // Use hashing in production
            Console.Write("Enter email: ");
            string email = Console.ReadLine();
            Console.Write("Enter full name: ");
            string fullName = Console.ReadLine();

            bool success = userService.RegisterUser(username, password, email, fullName);
            Console.WriteLine(success ? "Registration successful!" : "Registration failed!");
        }

        static bool LoginUser()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine(); // Use hashing in production

            return userService.AuthenticateUser(username, password);
        }

        static void AdminAuthentication()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("*Admin Authentication*");
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Back");
                Console.Write("Choose an option: ");

                if (int.TryParse(Console.ReadLine(), out int authChoice))
                {
                    switch (authChoice)
                    {
                        case 1:
                            RegisterAdmin();
                            break;
                        case 2:
                            if (LoginAdmin())
                            {
                                Console.WriteLine("Login successful!");
                                return; // Exit authentication loop and proceed to AdminPage
                            }
                            else
                            {
                                Console.WriteLine("Login failed! Please try again.");
                            }
                            break;
                        case 3:
                            return; // Back to main menu
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        static void RegisterAdmin()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine(); // Use hashing in production
            Console.Write("Enter full name: ");
            string fullName = Console.ReadLine();

            bool success = adminService.RegisterAdmin(username, password, fullName);
            Console.WriteLine(success ? "Registration successful!" : "Registration failed!");
        }

        static bool LoginAdmin()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine(); // Use hashing in production

            return adminService.AuthenticateAdmin(username, password);
        }

        static void UserPage(BookingService bookingService, TrainService trainService)
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("*User Page*");
                Console.WriteLine("1. Book Ticket");
                Console.WriteLine("2. Cancel Ticket");
                Console.WriteLine("3. Check Available Trains");
                Console.WriteLine("4. Logout");
                Console.WriteLine();
                Console.Write("Choose an option: ");
                if (int.TryParse(Console.ReadLine(), out int userChoice))
                {
                    switch (userChoice)
                    {
                        case 1:
                            BookTicket(bookingService);
                            break;
                        case 2:
                            CancelTicket(bookingService);
                            break;
                        case 3:
                            string availableTrainsInfo = trainService.GetAvailableTrainsFormatted();
                            Console.WriteLine(availableTrainsInfo);
                            break;
                        case 4:
                            Console.WriteLine("Logged out.");
                            return;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        static void BookTicket(BookingService bookingService)
        {
            Console.Write("Enter train number: ");
            if (int.TryParse(Console.ReadLine(), out int tno))
            {
                Console.Write("Enter class of travel (e.g., 1AC, 2AC): ");
                string classOfTravel = Console.ReadLine();
                Console.Write("Enter number of seats: ");
                if (int.TryParse(Console.ReadLine(), out int noOfSeats))
                {
                    if (noOfSeats < 1 || noOfSeats > 3)
                    {
                        Console.WriteLine("Booking failed! You can only book 1 to 3 seats.");
                    }
                    else
                    {
                        if (bookingService.BookTicket(1, tno, classOfTravel, noOfSeats))
                        {
                            Console.WriteLine("Booking successful!");
                        }
                        else
                        {
                            Console.WriteLine("Booking failed!");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input for number of seats.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input for train number.");
            }
        }

        static void CancelTicket(BookingService bookingService)
        {
            Console.Write("Enter booking ID: ");
            if (int.TryParse(Console.ReadLine(), out int bookingId))
            {
                Console.Write("Enter number of seats to cancel: ");
                if (int.TryParse(Console.ReadLine(), out int seatsToCancel))
                {
                    if (bookingService.CancelTicket(bookingId, seatsToCancel))
                    {
                        Console.WriteLine("Cancellation successful!");
                    }
                    else
                    {
                        Console.WriteLine("Cancellation failed!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input for number of seats to cancel.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input for booking ID.");
            }
        }

        static void AdminPage(TrainService trainService, BookingService bookingService)
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("*Admin Page*");
                Console.WriteLine("1. View Available Trains");
                Console.WriteLine("2. View All Bookings");
                Console.WriteLine("3. View All Cancellations");
                Console.WriteLine("4. Add Train");
                Console.WriteLine("5. Revise Train Amount");
                Console.WriteLine("6. Logout");
                Console.WriteLine();
                Console.Write("Choose an option: ");
                if (int.TryParse(Console.ReadLine(), out int adminChoice))
                {
                    switch (adminChoice)
                    {
                        case 1:
                            string availableTrainsInfo = trainService.GetAvailableTrainsFormatted();
                            Console.WriteLine(availableTrainsInfo);
                            break;
                        case 2:
                            try
                            {
                                DataTable bookings = bookingService.GetAllBookings();
                                if (bookings.Rows.Count > 0)
                                {
                                    Console.WriteLine("Bookings:");
                                    foreach (DataRow row in bookings.Rows)
                                    {
                                        Console.WriteLine($"Booking ID: {row["booking_id"]}, User ID: {row["user_id"]}, Train No: {row["tno"]}, Class: {row["class_of_travel"]}, Seats: {row["no_of_seats"]}, Date: {row["booking_date"]}");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("No bookings found.");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error retrieving bookings: " + ex.Message);
                            }
                            break;
                        case 3:
                            try
                            {
                                DataTable cancellations = bookingService.GetAllCancellations();
                                if (cancellations.Rows.Count > 0)
                                {
                                    Console.WriteLine("Cancellations:");
                                    foreach (DataRow row in cancellations.Rows)
                                    {
                                        Console.WriteLine($"Cancellation ID: {row["cancellation_id"]}, Booking ID: {row["booking_id"]}, Seats Cancelled: {row["no_of_seats_cancelled"]}, Date: {row["cancellation_date"]}");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("No cancellations found.");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error retrieving cancellations: " + ex.Message);
                            }
                            break;
                        case 4:
                            AddTrain(trainService);
                            break;
                        case 5:
                            ReviseTrainAmount();
                            break;
                        case 6:
                            Console.WriteLine("Logged out.");
                            return;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }


        static void AddTrain(TrainService trainService)
        {
            Console.Write("Enter Train Number: ");
            if (int.TryParse(Console.ReadLine(), out int tno))
            {
                Console.Write("Enter Train Name: ");
                string tname = Console.ReadLine();
                Console.Write("Enter From Location: ");
                string from = Console.ReadLine();
                Console.Write("Enter Destination: ");
                string dest = Console.ReadLine();
                Console.Write("Enter Price: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal price))
                {
                    Console.Write("Enter Class of Travel (e.g., 1AC, 2AC): ");
                    string classOfTravel = Console.ReadLine();
                    Console.Write("Enter Status (active/inactive): ");
                    string trainStatus = Console.ReadLine();
                    Console.Write("Enter Seats Available: ");
                    if (int.TryParse(Console.ReadLine(), out int seatsAvailable))
                    {
                        trainService.AddTrain(new Train
                        {
                            Tno = tno,
                            Tname = tname,
                            From = from,
                            Dest = dest,
                            Price = price,
                            ClassOfTravel = classOfTravel,
                            TrainStatus = trainStatus,
                            SeatsAvailable = seatsAvailable
                        });
                        Console.WriteLine("Train added successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input for seats available.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input for price.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input for train number.");
            }
        }

        static void ReviseTrainAmount()
        {
            Console.Write("Enter Train Number: ");
            if (int.TryParse(Console.ReadLine(), out int trainNo))
            {
                Console.Write("Enter Class of Travel: ");
                string classOfTravel = Console.ReadLine();
                Console.Write("Enter New Price: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal newPrice))
                {
                    string query = "UPDATE Trains SET price = @price WHERE tno = @tno AND class_of_travel = @class_of_travel";
                    SqlParameter[] parameters = {
                        new SqlParameter("@price", newPrice),
                        new SqlParameter("@tno", trainNo),
                        new SqlParameter("@class_of_travel", classOfTravel)
                    };
                    ExecuteNonQuery(query, parameters);
                    Console.WriteLine("Price updated successfully!");
                }
                else
                {
                    Console.WriteLine("Invalid input for new price.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input for train number.");
            }
        }

        private static void ExecuteNonQuery(string query, SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
