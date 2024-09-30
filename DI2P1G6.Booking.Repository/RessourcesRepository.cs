using Microsoft.Data.SqlClient;
using DI2P1G6.Booking.DataModel;
using DI2P1G6.Booking.Repository.Contract;
using System.Reflection.PortableExecutable;
using System.Data;

namespace DI2P1G6.Booking.Repository
{
    public class RessourcesRepository(string connectionString) : IRessourcesRepository
    {
        public List<Ressourse> GetAvailableRessources(int? siteId, int? capacite, DateTime? date, TimeSpan? heureDebut, TimeSpan? heureFin)
        {
            var ressources = new List<Ressourse>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = @"
                SELECT r.RessourceId, r.Nom, r.Capacite, r.Image, r.SiteId, r.TypeId
                FROM Ressources r
                WHERE r.SiteId = ISNULL(@SiteId, r.SiteId)
                AND r.Capacite >= ISNULL(@Capacite, r.Capacite)
                AND r.RessourceId NOT IN (
                    SELECT re.RessourceId FROM Reservation re
                    WHERE re.Date = @Date
                    AND (
                        (@HeureDebut >= re.HeureDebut AND @HeureDebut < re.HeureFin) OR
                        (@HeureFin > re.HeureDebut AND @HeureFin <= re.HeureFin) OR
                        (@HeureDebut <= re.HeureDebut AND @HeureFin >= re.HeureFin)
                    )
                )";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SiteId", (object)siteId ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Capacite", (object)capacite ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Date", (object)date?.Date ?? DBNull.Value);
                    command.Parameters.AddWithValue("@HeureDebut", (object)heureDebut ?? DBNull.Value);
                    command.Parameters.AddWithValue("@HeureFin", (object)heureFin ?? DBNull.Value);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ressources.Add(new Ressourse
                            {
                                RessourceId = reader.GetInt32(0),
                                Nom = reader.GetString(1),
                                Capacite = reader.GetInt32(2),
                                Image = reader.GetString(3),
                                SiteId = reader.GetInt32(4),
                                TypeId = reader.GetInt32(5)
                            });
                        }
                    }
                }
            }

            return ressources;
        }


        public List<Ressourse> GetAll()
        {
            var ressources = new List<Ressourse>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = @"
                SELECT *
                FROM Ressources";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ressources.Add(new Ressourse
                            {
                                RessourceId = reader.GetInt32(0),
                                Nom = reader.GetString(1),
                                Capacite = reader.GetInt32(2),
                                Image = reader.GetString(3),
                                SiteId = reader.GetInt32(4),
                                TypeId = reader.GetInt32(5)
                            });
                        }
                    }
                }
            }

            return ressources;
        }

        public List<Site> GetSite()
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
                                Ville = reader.GetString(3),
                            });
                        }
                    }
                }
            }

            return sites;
        }

        public void CreateRessource(Ressourse ressource)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = @"INSERT INTO Ressources (Nom, Capacite, Image, SiteId, TypeId) 
                      VALUES (@Nom, @Capacite, @Image, @SiteId, @TypeId)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nom", ressource.Nom);
                    command.Parameters.AddWithValue("@Capacite", ressource.Capacite);
                    command.Parameters.AddWithValue("@Image", ressource.Image);
                    command.Parameters.AddWithValue("@SiteId", ressource.SiteId);
                    command.Parameters.AddWithValue("@TypeId", ressource.TypeId);

                    command.ExecuteNonQuery();
                }
            }
        }


    }



}
