using System.Runtime.Serialization.Json;
using System.Text;

namespace MarvelSnapProject;
public class MarvelSerialized{
    DataContractJsonSerializer serCard = new DataContractJsonSerializer(typeof(List<MarvelCard>));
    DataContractJsonSerializer serLoc = new DataContractJsonSerializer(typeof(List<MarvelLocation>));

    public void SerialCard(){
        List<MarvelCard> cards = new List<MarvelCard>();
        cards.Add(new("Hawkeye", 1, 1, CardType.OnReveal, CardSkill.Hawkeye));
        cards.Add(new("Misty Knight", 1, 2, CardType.Normal, CardSkill.MistyKnight));
        cards.Add(new("Abomination", 5, 9, CardType.Normal, CardSkill.Abomination));
        cards.Add(new("Cyclops", 3, 4, CardType.Normal, CardSkill.Cyclops));
        cards.Add(new("Hulk", 6, 12, CardType.Normal, CardSkill.Hulk));
        cards.Add(new("Iron Man", 5, 0, CardType.OnGoing, CardSkill.IronMan));
        cards.Add(new("Medusa", 2, 2, CardType.OnReveal, CardSkill.Medusa));
        cards.Add(new("Punisher", 3, 2, CardType.OnGoing, CardSkill.Punisher));
        cards.Add(new("Quicksilver", 1, 2, CardType.Normal, CardSkill.Quicksilver));
        cards.Add(new("Sentinel", 2, 3, CardType.OnReveal, CardSkill.Sentinel));
        cards.Add(new("Shocker", 2, 3, CardType.Normal, CardSkill.Shocker));
        cards.Add(new("Star-Lord", 2, 2, CardType.OnReveal, CardSkill.StarLord));
        cards.Add(new("The Thing", 4, 6, CardType.Normal, CardSkill.TheThing));
        cards.Add(new("Jessica Jones", 4, 4, CardType.OnReveal, CardSkill.JessicaJones));
        cards.Add(new("Ant Man", 1, 1, CardType.OnGoing, CardSkill.AntMan));
        cards.Add(new("Squirrel", 1, 1, CardType.Normal, CardSkill.Squirrel));

        FileStream streamCard = new FileStream("cards.json", FileMode.Create);
        using (var writerCard = JsonReaderWriterFactory.CreateJsonWriter(streamCard, Encoding.UTF8, true, true, "   "))
        {
            serCard.WriteObject(writerCard, cards);

        }
    }

    public void SerialLocation(){
        List<MarvelLocation> locations = new List<MarvelLocation>{
            new("Necrosha", LocationSkill.Necrosha),
            new("Central Park", LocationSkill.CentralPark),
            new("Negative Zone", LocationSkill.NegativeZone),
            new("The Superflow", LocationSkill.TheSuperflow),
            new("Asgard", LocationSkill.Asgard),
            new("Lemuria", LocationSkill.Lemuria),
            new("The Big House", LocationSkill.TheBigHouse),
            new("Subterranea", LocationSkill.Subterranea)
        };

        FileStream streamLoc = new FileStream("locations.json", FileMode.Create);
        using (var writerLoc = JsonReaderWriterFactory.CreateJsonWriter(streamLoc, Encoding.UTF8, true, true, "   "))
        {
            serLoc.WriteObject(writerLoc, locations);

        }
    }

    public List<MarvelCard> ImportCards(){
        List<MarvelCard> importCards;
        using (FileStream streamCard2 = new FileStream(@".\Component\Database\cards.json", FileMode.OpenOrCreate))
        {
            importCards = (List<MarvelCard>)serCard.ReadObject(streamCard2);
        }
        return importCards;
    }
//@".\Component\Database\locations.json"
    public List<MarvelLocation> ImportLocations(){
        List<MarvelLocation> importLocations;
        using (FileStream streamLoc2 = new FileStream(@".\Component\Database\locations.json", FileMode.OpenOrCreate))
        {
            importLocations = (List<MarvelLocation>)serLoc.ReadObject(streamLoc2);
        }
        return importLocations;
    }
        

        
}