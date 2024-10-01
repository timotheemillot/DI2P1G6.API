using DI2P1G6.Booking.DataModel;
using DI2P1G6.Booking.Repository.Contract;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI2P1G6.Booking.Repository
{
    public class SitesRepository(string connectionString) : ISitesRepository
    {
        public List<Site> GetAll()
        {
            var sites = new List<Site>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = @"
                SELECT *
                FROM Sites";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sites.Add(new Site
                            {
                                SiteId = reader.GetInt32(0),
                                Nom = reader.GetString(1),
                                Adresse = reader.GetString(2),
                                Ville = reader.GetString(3)
                            });
                        }
                    }
                }
            }

            return sites;
        }

    }
}
