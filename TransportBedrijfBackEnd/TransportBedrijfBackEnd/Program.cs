using TransportBedrijfBackEnd;

var repo = new VoertuigRepository();
var voertuigen = repo.GetAll();

foreach (var voertuig in voertuigen)
{
    Console.WriteLine($"ID: {voertuig.VoertuigId}, Kenteken: {voertuig.Kenteken}, Type: {voertuig.Type}");
}