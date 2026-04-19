using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using TransportBedrijfMVC.Models;
namespace TransportBedrijfMVC.Repositories
{
    internal class VoertuigRepository
    {
        private string connectionString = "Server=127.0.0.1;Port=3306;Database=transportbedrijf;Uid=root;Pwd=root;";
        public List<Voertuig> GetAll()
        {
            List<Voertuig> voertuigen = new List<Voertuig>();
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Voertuig";
                var command = new MySqlCommand(query, connection);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Voertuig v = new Voertuig();
                    v.VoertuigId = Convert.ToInt32(reader["voertuig_id"]);
                    v.Kenteken = reader["kenteken"].ToString();
                    v.Type = reader["type"].ToString();
                    v.Kilometerstand = Convert.ToDecimal(reader["kilometerstand"]);
                    v.Afschrijving = Convert.ToDecimal(reader["afschrijving"]);
                    voertuigen.Add(v);
                }
            }
            return voertuigen;
        }

        // HIER BEGINT DE NIEUWE METHODE
        public void Add(Voertuig voertuig)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Voertuig (kenteken, type, kilometerstand, afschrijving, max_personen, max_capaciteit) VALUES (@kenteken, @type, @kilometerstand, @afschrijving, @maxPersonen, @maxCapaciteit)";
                var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@kenteken", voertuig.Kenteken);
                command.Parameters.AddWithValue("@type", voertuig.Type);
                command.Parameters.AddWithValue("@kilometerstand", voertuig.Kilometerstand);
                command.Parameters.AddWithValue("@afschrijving", voertuig.Afschrijving);
                command.Parameters.AddWithValue("@maxPersonen", voertuig.MaxPersonen ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@maxCapaciteit", voertuig.MaxCapaciteit ?? (object)DBNull.Value);
                command.ExecuteNonQuery();
            }
        }
    }
}