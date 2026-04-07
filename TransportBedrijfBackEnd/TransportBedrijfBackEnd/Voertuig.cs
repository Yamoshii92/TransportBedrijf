using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportBedrijfBackEnd
{
    internal class Voertuig
    {
        public int VoertuigId { get; set; }
        public string Kenteken { get; set; }
        public string Type { get; set; }
        public decimal Kilometerstand { get; set; }
        public decimal Afschrijving { get; set; }
        public int MaxPersonen { get; set; }
        public decimal MaxCapaciteit { get; set; }
    }
}
