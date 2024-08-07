using System;
using System.Data;
using System.Data.SqlClient;

namespace Railwayproject
{
    public class BookingService
    {
        private readonly string connectionString;

        public BookingService(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool BookTicket(int userId, int tno, string classOfTravel, int noOfSeats)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Check if enough seats are available
                        string checkSeatsQuery = @"
                    SELECT seats_available 
                    FROM Trains 
                    WHERE tno = @tno AND class_of_travel = @class_of_travel AND train_status = 'active'";

                        var checkParameters = new[]
                        {
                    new SqlParameter("@tno", SqlDbType.Int) { Value = tno },
                    new SqlParameter("@class_of_travel", SqlDbType.NVarChar) { Value = classOfTravel }
                };

                        var dataTable = ExecuteQuery(checkSeatsQuery, checkParameters, connection, transaction);
                        if (dataTable.Rows.Count == 0)
                        {
                            transaction.Rollback();
                            return false; // No such train or class
                        }

                        var seatsAvailable = (int)dataTable.Rows[0]["seats_available"];
                        if (seatsAvailable < noOfSeats)
                        {
                            transaction.Rollback();
                            return false; // Not enough seats available
                        }

                        // Update seats available
                        string updateSeatsQuery = @"
                    UPDATE Trains 
                    SET seats_available = seats_available - @no_of_seats 
                    WHERE tno = @tno AND class_of_travel = @class_of_travel";

                        var updateParameters = new[]
                        {
                    new SqlParameter("@no_of_seats", SqlDbType.Int) { Value = noOfSeats },
                    new SqlParameter("@tno", SqlDbType.Int) { Value = tno },
                    new SqlParameter("@class_of_travel", SqlDbType.NVarChar) { Value = classOfTravel }
                };

                        ExecuteNonQuery(updateSeatsQuery, updateParameters, connection, transaction);

                        // Insert booking record
                        string insertBookingQuery = @"
                    INSERT INTO Bookings (user_id, tno, class_of_travel, no_of_seats, booking_date) 
                    VALUES (@user_id, @tno, @class_of_travel, @no_of_seats, @booking_date)";

                        var bookingParameters = new[]
                        {
                    new SqlParameter("@user_id", SqlDbType.Int) { Value = userId },
                    new SqlParameter("@tno", SqlDbType.Int) { Value = tno },
                    new SqlParameter("@class_of_travel", SqlDbType.NVarChar) { Value = classOfTravel },
                    new SqlParameter("@no_of_seats", SqlDbType.Int) { Value = noOfSeats },
                    new SqlParameter("@booking_date", SqlDbType.DateTime) { Value = DateTime.Now }
                };

                        ExecuteNonQuery(insertBookingQuery, bookingParameters, connection, transaction);

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        LogError("Error during booking: " + ex.Message);
                        return false;
                    }
                }
            }
        }


        public bool CancelTicket(int bookingId, int seatsToCancel)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Get the booking details
                        string getBookingQuery = @"
                    SELECT tno, class_of_travel, no_of_seats 
                    FROM Bookings 
                    WHERE booking_id = @booking_id";

                        var parameters = new[]
                        {
                    new SqlParameter("@booking_id", SqlDbType.Int) { Value = bookingId }
                };

                        var dataTable = ExecuteQuery(getBookingQuery, parameters, connection, transaction);
                        if (dataTable.Rows.Count == 0)
                        {
                            transaction.Rollback();
                            return false; // No such booking
                        }

                        var row = dataTable.Rows[0];
                        int tno = (int)row["tno"];
                        string classOfTravel = row["class_of_travel"].ToString();
                        int bookedSeats = (int)row["no_of_seats"];
                        if (seatsToCancel > bookedSeats)
                        {
                            transaction.Rollback();
                            return false; // More seats to cancel than booked
                        }

                        // Insert cancellation record
                        string cancelQuery = @"
                    INSERT INTO Cancellations (booking_id, no_of_seats_cancelled, cancellation_date) 
                    VALUES (@booking_id, @no_of_seats_cancelled, @cancellation_date)";

                        var cancelParameters = new[]
                        {
                    new SqlParameter("@booking_id", SqlDbType.Int) { Value = bookingId },
                    new SqlParameter("@no_of_seats_cancelled", SqlDbType.Int) { Value = seatsToCancel },
                    new SqlParameter("@cancellation_date", SqlDbType.DateTime) { Value = DateTime.Now }
                };

                        ExecuteNonQuery(cancelQuery, cancelParameters, connection, transaction);

                        // Update seats available
                        string updateSeatsQuery = @"
                    UPDATE Trains 
                    SET seats_available = seats_available + @seats_to_cancel 
                    WHERE tno = @tno AND class_of_travel = @class_of_travel";

                        var updateParameters = new[]
                        {
                    new SqlParameter("@seats_to_cancel", SqlDbType.Int) { Value = seatsToCancel },
                    new SqlParameter("@tno", SqlDbType.Int) { Value = tno },
                    new SqlParameter("@class_of_travel", SqlDbType.NVarChar) { Value = classOfTravel }
                };

                        ExecuteNonQuery(updateSeatsQuery, updateParameters, connection, transaction);

                        // Update booking seats
                        string updateBookingQuery = @"
                    UPDATE Bookings 
                    SET no_of_seats = no_of_seats - @seats_to_cancel 
                    WHERE booking_id = @booking_id";

                        var updateBookingParameters = new[]
                        {
                    new SqlParameter("@seats_to_cancel", SqlDbType.Int) { Value = seatsToCancel },
                    new SqlParameter("@booking_id", SqlDbType.Int) { Value = bookingId }
                };

                        ExecuteNonQuery(updateBookingQuery, updateBookingParameters, connection, transaction);

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        LogError("Error during cancellation: " + ex.Message);
                        return false;
                    }
                }
            }
        }


        public DataTable GetAllBookings()
        {
            string query = "SELECT * FROM Bookings";
            return ExecuteQuery(query);
        }

        public DataTable GetAllCancellations()
        {
            string query = "SELECT * FROM Cancellations";
            return ExecuteQuery(query);
        }


        private void ExecuteNonQuery(string query, SqlParameter[] parameters, SqlConnection connection, SqlTransaction transaction)
        {
            try
            {
                using (var command = new SqlCommand(query, connection, transaction))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                LogError("Error executing non-query: " + ex.Message);
                throw;
            }
        }

        private DataTable ExecuteQuery(string query, SqlParameter[] parameters = null, SqlConnection connection = null, SqlTransaction transaction = null)
        {
            bool connectionCreated = false;

            if (connection == null)
            {
                connection = new SqlConnection(connectionString);
                connectionCreated = true;
            }

            try
            {
                if (connectionCreated)
                {
                    connection.Open();
                }

                using (var command = new SqlCommand(query, connection, transaction))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    using (var adapter = new SqlDataAdapter(command))
                    {
                        var table = new DataTable();
                        adapter.Fill(table);
                        return table;
                    }
                }
            }
            catch (Exception ex)
            {
                LogError("Error executing query: " + ex.Message);
                throw;
            }
            finally
            {
                if (connectionCreated)
                {
                    connection.Close();
                }
            }
        }



        private void LogError(string message)
        {
            // Implement proper logging here
            Console.WriteLine(message);
        }
    }
}
