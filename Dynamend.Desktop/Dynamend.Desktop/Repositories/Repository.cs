using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Xml.Linq;
using Dynamend.Desktop.Data;
using Dynamend.Desktop.Models;

namespace Dynamend.Desktop.Repositories
{
    internal class Repository
    {
        private readonly DataContext _dataContext = new DataContext();

        public Repository()
        {
            CreateCustomerTable();
            CreateServiceReportsTable();
        }

        private void CreateCustomerTable()
        {
            string createTableQuery = @"
            CREATE TABLE  IF NOT EXISTS Customer (
            CustomerId INTEGER PRIMARY KEY AUTOINCREMENT,
            Name VARCHAR(100) NOT NULL,
            ContactNumber VARCHAR(12) NOT NULL,
            Address VARCHAR(200) NOT NULL,
            VehicleModelName VARCHAR(100) NOT NULL,
            LicenseNumber VARCHAR(10) NOT NULL
            );";
            
            var connection = _dataContext.GetConnection();
            using (SQLiteCommand command = new SQLiteCommand(createTableQuery, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        private void CreateServiceReportsTable()
        {
            string createTableQuery = @"
            CREATE TABLE IF NOT EXISTS ServiceRecord (
            ServiceId INTEGER PRIMARY KEY AUTOINCREMENT,
            ServiceDate DateTime NOT NULL,
            EngineOperation VARCHAR(200) NOT NULL,
            ShiftOperation VARCHAR(200) NOT NULL,
            ClutchAndBrake VARCHAR(200) NOT NULL,
            Steering VARCHAR(200) NOT NULL,
            GrilleAndTrimAndRoofRack VARCHAR(200) NOT NULL,
            DoorsAndHoodAndDecklidAndTailGate VARCHAR(200) NOT NULL,
            BodyPanelsAndBumpers VARCHAR(200) NOT NULL,
            GlassAndOutsideMirrors VARCHAR(200) NOT NULL,
            ExteriorLights VARCHAR(200) NOT NULL,
            AirBagAndSafetyBelts VARCHAR(200) NOT NULL,
            AudioAndAlarmsSystems VARCHAR(200) NOT NULL,
            HeatAndVentAndACDeFogAndDeposit VARCHAR(200) NOT NULL,
            InteriorAmenities VARCHAR(200) NOT NULL,
            TotalCost  VARCHAR(200) NOT NULL,
            Kms VARCHAR(100) NOT NULL,
            CustomerName VARCHAR(100),
            CONSTRAINT FK_Customer_Name FOREIGN KEY (CustomerName) REFERENCES Customer(Name)
            );";
            var connection = _dataContext.GetConnection();
            using (SQLiteCommand command = new SQLiteCommand(createTableQuery, connection))
            {
                command.ExecuteNonQuery();
            }
        }
        public void AddCustomer(Customer customer)
        {
            string query = "INSERT INTO Customer (Name, ContactNumber, Address, VehicleModelName, LicenseNumber   ) VALUES (@Name, @ContactNumber, @Address, @VehicleModelName, @LicenseNumber )";
            var connection = _dataContext.GetConnection();
            SQLiteCommand command = new SQLiteCommand(query, connection);
            
                command.Parameters.AddWithValue("@Name", customer.Name);
                command.Parameters.AddWithValue("@ContactNumber", customer.ContactNumber);
                command.Parameters.AddWithValue("@Address", customer.Address);
                command.Parameters.AddWithValue("@VehicleModelName", customer.VehicleModelName);
                command.Parameters.AddWithValue("@LicenseNumber", customer.LicenseNumber);
                command.ExecuteNonQuery();
            
        }
        public void AddServiceReport(ServiceReport serviceReport)
        {
            string query = "INSERT INTO ServiceRecord (Customername, ServiceDate, EngineOperation, ShiftOperation, ClutchAndBrake, Steering, GrilleAndTrimAndRoofRack, DoorsAndHoodAndDecklidAndTailGate, BodyPanelsAndBumpers, GlassAndOutsideMirrors, ExteriorLights, AirBagAndSafetyBelts, AudioAndAlarmsSystems, HeatAndVentAndACDeFogAndDeposit, InteriorAmenities, TotalCost, Kms) VALUES (@CustomerName, @ServiceDate, @EngineOperation, @ShiftOperation, @ClutchAndBrake, @Steering, @GrilleAndTrimAndRoofRack, @DoorsAndHoodAndDecklidAndTailGate, @BodyPanelsAndBumpers, @GlassAndOutsideMirrors, @ExteriorLights, @AirBagAndSafetyBelts, @AudioAndAlarmsSystems, @HeatAndVentAndACDeFogAndDeposit, @InteriorAmenities, @TotalCost, @Kms)";
            var connection = _dataContext.GetConnection();
            SQLiteCommand command = new SQLiteCommand(query, connection);
            
                command.Parameters.AddWithValue("@CustomerName", serviceReport.CustomerName);
                command.Parameters.AddWithValue("@ServiceDate", serviceReport.ServiceDate);
                command.Parameters.AddWithValue("@EngineOperation", serviceReport.EngineOperation);
                command.Parameters.AddWithValue("@ShiftOperation", serviceReport.ShiftOperation);
                command.Parameters.AddWithValue("@ClutchAndBrake", serviceReport.ClutchAndBrake);
                command.Parameters.AddWithValue("@Steering", serviceReport.Steering);
                command.Parameters.AddWithValue("@GrilleAndTrimAndRoofRack", serviceReport.GrilleAndTrimAndRoofRack);
                command.Parameters.AddWithValue("@DoorsAndHoodAndDecklidAndTailGate", serviceReport.DoorsAndHoodAndDecklidAndTailGate);
                command.Parameters.AddWithValue("@BodyPanelsAndBumpers", serviceReport.BodyPanelsAndBumpers);
                command.Parameters.AddWithValue("@GlassAndOutsideMirrors", serviceReport.GlassAndOutsideMirrors);
                command.Parameters.AddWithValue("@ExteriorLights", serviceReport.ExteriorLights);
                command.Parameters.AddWithValue("@AirBagAndSafetyBelts", serviceReport.AirBagAndSafetyBelts);
                command.Parameters.AddWithValue("@AudioAndAlarmsSystems", serviceReport.AudioAndAlarmsSystems);
                command.Parameters.AddWithValue("@HeatAndVentAndACDeFogAndDeposit", serviceReport.HeatAndVentAndACDeFogAndDeposit);
                command.Parameters.AddWithValue("@InteriorAmenities", serviceReport.InteriorAmenities);
                command.Parameters.AddWithValue("@TotalCost", serviceReport.TotalCost);
                command.Parameters.AddWithValue("@Kms", serviceReport.Kms);
                command.ExecuteNonQuery();
            
        }
        public List<Customer> GetCustomerList()
        {
            List<Customer> list = new List<Customer>();
            var connection = _dataContext.GetConnection();
            string query = @"SELECT * FROM Customer";
            var command = new SQLiteCommand(query, connection);
            SQLiteDataReader reader = command.ExecuteReader();
            {
                while (reader.Read())
                {
                    list.Add(new Customer
                    {
                        CustomerId = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        ContactNumber = reader.GetString(2),
                        Address = reader.GetString(3),
                        VehicleModelName = reader.GetString(4),
                        LicenseNumber = reader.GetString(5),
                    });
                }
            }

            foreach (var item in list)
            {
                Console.WriteLine($"{item.Name} - {item.VehicleModelName}");
            }
            return list;
        }
        public Customer GetCustomer(string name)
        {
            var connection = _dataContext.GetConnection();
            string query = @"SELECT * FROM Customer WHERE Name = @name";
            var command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@name", name);
             SQLiteDataReader reader = command.ExecuteReader();
              {
                        if (reader.Read())
                        {
                            return new Customer
                            {
                                CustomerId = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                ContactNumber = reader.GetString(2),
                                Address = reader.GetString(3),
                                LicenseNumber = reader.GetString(4),
                                VehicleModelName = reader.GetString(5),
                            };
                        }
                        return null;
              }
                
        }
        public Customer GetCustomerByLicense(string license)
        {
            var connection = _dataContext.GetConnection();
            string query = @"SELECT * FROM Customer WHERE LicenseNumber = @license";
            var command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@license", license);
            SQLiteDataReader reader = command.ExecuteReader();
            {
                if (reader.Read())
                {
                    return new Customer
                    {
                        CustomerId = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        ContactNumber = reader.GetString(2),
                        Address = reader.GetString(3),
                        LicenseNumber = reader.GetString(4),
                        VehicleModelName = reader.GetString(5),
                    };
                }
                return null;
            }
        }

        public ServiceReport GetServiceReport(string name)
        {
            string query = @"SELECT * FROM ServiceRecord WHERE CustomerName = @name";
            using (var connection = _dataContext.GetConnection())
            {
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new ServiceReport
                            {
                               
                                ServiceDate = DateTime.Parse(reader.GetString(0)),
                                EngineOperation = reader.GetString(1),
                                ShiftOperation = reader.GetString(2),
                                ClutchAndBrake = reader.GetString(3),
                                Steering = reader.GetString(4),
                                GrilleAndTrimAndRoofRack = reader.GetString(5),
                                DoorsAndHoodAndDecklidAndTailGate = reader.GetString(6),
                                BodyPanelsAndBumpers = reader.GetString(7),
                                GlassAndOutsideMirrors = reader.GetString(8),
                                ExteriorLights = reader.GetString(9),
                                AirBagAndSafetyBelts = reader.GetString(10),
                                AudioAndAlarmsSystems = reader.GetString(11),
                                HeatAndVentAndACDeFogAndDeposit = reader.GetString(12),
                                InteriorAmenities = reader.GetString(13),

                            };
                        }
                    }
                }
                return null;
            }
        }
    }
}

