// using System.Linq;
// namespace MarvelSnapProject;

// public class AbilityOnGoing
// {
//     public static bool SkillDefault(GameController game)
//     {
//         return true;
//     }
//     public static bool SkillIronMan(GameController game)
//     {
//         List<MarvelLocation> locs = game.GetLocations();
//         IEnumerable<IPlayer> players = game.ListAllPlayer();

//         foreach (MarvelLocation loc in locs)
//         {
//             foreach (IPlayer player in players)
//             {
//                 MarvelCard? ironManCard = game.GetAllCards().Find(x => x.GetCardName() == "Iron Man");
//                 LocationInfo locsInfo = game.GetLocationInfo()[loc];
//                 List<MarvelCard> cards = locsInfo.GetCardsOnLoc()[player];
//                 int score = game.GetLocationScore(loc, player);
//                 if (cards.Contains(ironManCard))
//                 {
//                     game.SetLocationScore(loc, player, score *2);
//                 }
                             

//                 // MarvelLocation loc = game.CheckCardLocation(player, ironManCard);
//             }

//         }
//         return true;

//     }

//     public bool SkillAntMan(GameController game)
//     {
//         List<MarvelLocation> locs = game.GetLocations();
//         IEnumerable<IPlayer> players = game.ListAllPlayer();
//         foreach (var loc in locs)
//         {
//             foreach (var player in players)
//             {
                
//             }
//         }
//         return true;
//     }
// }