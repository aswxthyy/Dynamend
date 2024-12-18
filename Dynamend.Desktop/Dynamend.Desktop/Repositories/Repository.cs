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
        private readonly DataContext _dataContext;

        public Repository()
        {
            CreateCustomerTable();
            CreateServiceReportTable();
        }

        private void CreateCustomerTable()
        {
            string createTableQuery = @"
            IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Customer' AND xtype='U')
            BEGIN
            CREATE TABLE Customer (
            CustomerId INT PRIMARY KEY IDENTITY,
            Name VARCHAR(100) NOT NULL,
            ContactNumber VARCHAR(12) NOT NULL,
            Address VARCHAR(200) NOT NULL,
            Vehicle Model Name VARCHAR(100) NOT NULL,
            License Number VARCHAR(10) NOT NULL,
            );
            END";
            var connection = _dataContext.GetConnection();
            SQLiteCommand command = new SQLiteCommand(createTableQuery, connection);
            command.ExecuteNonQuery();
        }

        private void CreateServiceReportTable()
        {
            string createTableQuery = @"
            IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='ServiceReport' AND xtype='U')
            BEGIN
            CREATE TABLE ServiceReport (
            ServiceId INT PRIMARY KEY IDENTITY,
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
            CustomerId INT ,
            CONSTRAINT FK_Customer_Id FOREIGN KEY (CustomerId) REFERENCES Customer(CustomerId)
            );
            END";
            var connection = _dataContext.GetConnection();
            SQLiteCommand command = new SQLiteCommand(createTableQuery, connection);
            command.ExecuteNonQuery();
        }
        public void AddCustomer(Customer customer)
        {
            string query = "INSERT INTO Customer (Name, ContactNumber, Address, Vehicle Model Name, License Number   ) VALUES (@Name, @ContactNumber, @Address, @Vehicle Model Name, @License Number )";
            var connection = _dataContext.GetConnection();
            SQLiteCommand command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@Name", customer.Name);
            command.Parameters.AddWithValue("@ContactNumber", customer.ContactNumber);
            command.Parameters.AddWithValue("@Address", customer.Address);
            command.Parameters.AddWithValue("@Vehicle Model Name", customer.VehicleModelName);
            command.Parameters.AddWithValue("@License Number", customer.LicenseNumber);

            command.ExecuteNonQuery();
        }
        public void AddServiceReport(ServiceReport serviceReport)
        {
            string query = "INSERT INTO Customer (CustomerId, ServiceDate, EngineOperation, ShiftOperation, ClutchAndBrake, Steering, GrilleAndTrimAndRoofRack, DoorsAndHoodAndDecklidAndTailGate, BodyPanelsAndBumpers, GlassAndOutsideMirrors, ExteriorLights, AirBagAndSafetyBelts, AudioAndAlarmsSystems, HeatAndVentAndACDeFogAndDeposit, InteriorAmenities) VALUES (@CustomerId, @ServiceDate, @EngineOperation, @ShiftOperation, @ClutchAndBrake, @Steering, @GrilleAndTrimAndRoofRack, @DoorsAndHoodAndDecklidAndTailGate, @BodyPanelsAndBumpers, @GlassAndOutsideMirrors, @ExteriorLights, @AirBagAndSafetyBelts, @AudioAndAlarmsSystems, @HeatAndVentAndACDeFogAndDeposit, @InteriorAmenities)";
            var connection = _dataContext.GetConnection();
            SQLiteCommand command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@CustomerId", serviceReport.CustomerId);
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
        public ServiceReport GetServiceReport(string name)
        {
            string query = "@ SELECT Customer.Name, FROM Customer JOIN ServiceReport ON Customer.CustomerId = ServiceReport.CustomerId WHERE Customer.Name = @ name ";
            var connection = _dataContext.GetConnection();
           var result = new ServiceReport();
            var command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@name", name);
            SQLiteDataReader reader = command.ExecuteReader();
            {
                while (reader.Read())
                {
                    result =new ServiceReport
                    {
                        CustomerId = reader.GetInt32(0),
                        ServiceDate = DateTime.Parse(reader.GetString(1)),
                        EngineOperation = reader.GetString(2),
                        ShiftOperation = reader.GetString(3),
                        ClutchAndBrake = reader.GetString(4),
                        Steering = reader.GetString(5),
                        GrilleAndTrimAndRoofRack = reader.GetString(6),
                        DoorsAndHoodAndDecklidAndTailGate = reader.GetString(7),
                        BodyPanelsAndBumpers = reader.GetString(8),
                        GlassAndOutsideMirrors = reader.GetString(9),
                        ExteriorLights = reader.GetString(10),
                        AirBagAndSafetyBelts = reader.GetString(11),
                        AudioAndAlarmsSystems = reader.GetString(12),
                        HeatAndVentAndACDeFogAndDeposit = reader.GetString(13),
                        InteriorAmenities = reader.GetString(14),

                    };
                }
            }
            return result;
        }
    }
}

