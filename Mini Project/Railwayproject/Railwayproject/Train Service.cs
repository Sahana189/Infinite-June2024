using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Railwayproject.Models;
namespace Railwayproject
{
    public class TrainService
    {
        private readonly string connectionString;
        // Constructor to initialize connection string
        public TrainService(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public void AddTrain(Train train)
        {
            string query = "INSERT INTO Trains (tno, tname, [from], dest, price, class_of_travel, train_status, seats_available) VALUES (@tno, @tname, @from, @dest, @price, @class_of_travel, @train_status, @seats_available)";
            SqlParameter[] parameters = {
               new SqlParameter("@tno", train.Tno),
               new SqlParameter("@tname", train.Tname),
               new SqlParameter("@from", train.From),
               new SqlParameter("@dest", train.Dest),
               new SqlParameter("@price", train.Price),
               new SqlParameter("@class_of_travel", train.ClassOfTravel),
               new SqlParameter("@train_status", train.TrainStatus),
               new SqlParameter("@seats_available", train.SeatsAvailable)
           };
            ExecuteNonQuery(query, parameters);
        }
        public void UpdateTrain(Train train)
        {
            string query = "UPDATE Trains SET tname = @tname, [from] = @from, dest = @dest, price = @price, class_of_travel = @class_of_travel, train_status = @train_status, seats_available = @seats_available WHERE tno = @tno AND class_of_travel = @class_of_travel";
            SqlParameter[] parameters = {
               new SqlParameter("@tno", train.Tno),
               new SqlParameter("@tname", train.Tname),
               new SqlParameter("@from", train.From),
               new SqlParameter("@dest", train.Dest),
               new SqlParameter("@price", train.Price),
               new SqlParameter("@class_of_travel", train.ClassOfTravel),
               new SqlParameter("@train_status", train.TrainStatus),
               new SqlParameter("@seats_available", train.SeatsAvailable)
           };
            ExecuteNonQuery(query, parameters);
        }
        public void DeleteTrain(int tno, string classOfTravel)
        {
            string query = "DELETE FROM Trains WHERE tno = @tno AND class_of_travel = @class_of_travel";
            SqlParameter[] parameters = {
               new SqlParameter("@tno", tno),
               new SqlParameter("@class_of_travel", classOfTravel)
           };
            ExecuteNonQuery(query, parameters);
        }
        public List<Train> GetAvailableTrains()
        {
            string query = "SELECT * FROM Trains WHERE train_status = 'active' AND seats_available > 0";
            var dataTable = ExecuteQuery(query);
            var trains = new List<Train>();
            foreach (DataRow row in dataTable.Rows)
            {
                trains.Add(new Train
                {
                    Tno = (int)row["tno"],
                    Tname = row["tname"].ToString(),
                    From = row["from"].ToString(),
                    Dest = row["dest"].ToString(),
                    Price = (decimal)row["price"],
                    ClassOfTravel = row["class_of_travel"].ToString(),
                    TrainStatus = row["train_status"].ToString(),
                    SeatsAvailable = (int)row["seats_available"]
                });
            }
            return trains;
        }
        public string GetAvailableTrainsFormatted()
        {
            var availableTrains = GetAvailableTrains();
            var result = new StringBuilder();
            if (availableTrains.Count == 0)
            {
                result.AppendLine("No available trains at the moment.");
 
                result.AppendLine("No available trains at the moment.");
            }
            else
            {
                result.AppendLine("Available Trains:");
                result.AppendLine("---------------------------------------------------------------");
                foreach (var train in availableTrains)
                {
                    result.AppendLine($"Train No: {train.Tno}, Name: {train.Tname}, From: {train.From}, To: {train.Dest}, Price: {train.Price:C}, Seats Available: {train.SeatsAvailable}");
                }
                result.AppendLine("---------------------------------------------------------------");
            }
            return result.ToString();
        }
        // Helper methods for executing queries
        private void ExecuteNonQuery(string query, SqlParameter[] parameters)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand(query, connection))
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
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }
        private DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand(query, connection))
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
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }
    }
}
