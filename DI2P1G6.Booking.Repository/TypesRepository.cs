using DI2P1G6.Booking.DataModel;
using DI2P1G6.Booking.Repository.Contract;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = DI2P1G6.Booking.DataModel.Type;

namespace DI2P1G6.Booking.Repository
{
    public class TypesRepository(string connectionString) : ITypesRepository
    {
        public List<Type> GetAll()
        {
            var types = new List<Type>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = @"
                SELECT *
                FROM Types";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            types.Add(new Type
                            {
                                TypeId = reader.GetInt32(0),
                                Nom = reader.GetString(1),
                            });
                        }
                    }
                }
            }

            return types;
        }
    }
}
