using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace TransportBedrijfBackEnd
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
    }
}