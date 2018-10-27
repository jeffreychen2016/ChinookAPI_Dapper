using ChinookAPI_Dapper.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace ChinookAPI_Dapper.DataAccess
{
    public class Chinook
    {
        private string ConnectionString;

        public Chinook(IConfiguration config)
        {
            ConnectionString = config.GetSection("ConnectionString").Value;
        }

        public List<Invoice> GetInvoicesBySalesAgentID(int SalesRepId)
        {
            using (var dbConnection = new SqlConnection(ConnectionString))
            {
                dbConnection.Open();
                var result = dbConnection.Query<Invoice>(@"SELECT 
                                        ClientFullName = Customer.FirstName + ' ' + Customer.LastName,
                                        Invoice.*
                                        FROM Invoice
                                        INNER JOIN Customer
                                            ON Invoice.CustomerId = Customer.CustomerId
                                        INNER JOIN Employee
                                            ON Employee.EmployeeId = Customer.SupportRepId
                                        WHERE Customer.SupportRepId = @id", new { id = SalesRepId});
                return result.ToList();
            };
        }
    }
}
