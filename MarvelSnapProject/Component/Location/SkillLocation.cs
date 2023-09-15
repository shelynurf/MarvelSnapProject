namespace MarvelSnapProject;

public static class SkillLocation
{
    public static bool SkillDefault(GameController game)
    {
        return true;
    }
    public static bool SkillNidavellir(GameController game)
    {
        var locations = game.GetLocations();
        foreach (var loc in locations)
        {
            if (loc.CheckIsOpened())
            {
                foreach (var player in game.ListAllPlayer())
                        {
                            foreach (MarvelCard card in game.GetLocationCards(loc, player))
                            {
                                if (!card.IsAffected())
                                {
                                    game.GetLocationInfo()[loc].AddScore(player, 5);
                                    card.SetAffected(true);
                                }
                            }
                        }
            }

        }
        return false;
    }

    public static bool SkillCloningVat(GameController game)
    {
        var locations = game.GetLocations();
        foreach (var loc in locations)
        {
            if (loc.CheckIsOpened())
            {
                foreach (var player in game.ListAllPlayer())
                        {
                            foreach (MarvelCard card in game.GetLocationCards(loc, player))
                            {
                                if (!card.IsAffected())
                                {
                                    game.GenerateCard(player, card);
                                    card.SetAffected(true);
                                }
                            }
                        }
            }

        }
        return false;
    }

    public static bool SkillAtlantis(GameController game)
    {
        var locations = game.GetLocations();
        foreach (var loc in locations)
        {
            if (loc.CheckIsOpened())
            {
                foreach (var player in game.ListAllPlayer())
                        {
                            var cards = game.GetLocationCards(loc, player);
                            

                            if (cards.Count == 1)
                            {
                                MarvelCard card1 = (MarvelCard)cards[0];
                                if (!card1.IsAffected())
                                {
                                    game.GetLocationInfo()[loc].AddScore(player, 5);
                                    card1.SetAffected(true);
                                }
                            }
                            else if (cards.Count > 1)
                            {
                                foreach (MarvelCard card in cards)
                                {
                                    if (card.IsAffected())
                                    {
                                        MarvelCard card1 = (MarvelCard)cards[0];
                                        game.GetLocationInfo()[loc].AddScore(player, -5);
                                        card1.SetAffected(false);
                                    }
                                }
                            }
                        }
            }

        }
        return false;
    }
    // public static bool OnGoingLocs(GameController game)
    // {
    //     var locations = game.GetLocations();
    //     foreach (var loc in locations)
    //     {
    //         if (loc.CheckIsOpened())
    //         {
    //             switch (loc.GetSkill())
    //             {
    //                 case LocationSkill.Ruins:
    //                     break;
    //                 case LocationSkill.Nidavellir:
    //                     foreach (var player in game.ListAllPlayer())
    //                     {
    //                         foreach (MarvelCard card in game.GetLocationCards(loc, player))
    //                         {
    //                             if (!card.IsAffected())
    //                             {
    //                                 game.GetLocationInfo()[loc].AddScore(player, 5);
    //                                 card.SetAffected(true);
    //                             }
    //                         }
    //                     }
    //                     break;

    //                 case LocationSkill.CloningVat :
    //                     foreach (var player in game.ListAllPlayer())
    //                     {
    //                         foreach (MarvelCard card in game.GetLocationCards(loc, player))
    //                         {
    //                             if (!card.IsAffected())
    //                             {
    //                                 game.GenerateCard(player, card);
    //                                 card.SetAffected(true);
    //                             }
    //                         }
    //                     }
    //                     break;
    //                 case LocationSkill.Atlantis :
    //                     foreach (var player in game.ListAllPlayer())
    //                     {
    //                         var cards = game.GetLocationCards(loc, player);
                            

    //                         if (cards.Count == 1)
    //                         {
    //                             MarvelCard card1 = (MarvelCard)cards[0];
    //                             if (!card1.IsAffected())
    //                             {
    //                                 game.GetLocationInfo()[loc].AddScore(player, 5);
    //                                 card1.SetAffected(true);
    //                             }
    //                         }
    //                         else if (cards.Count > 1)
    //                         {
    //                             foreach (MarvelCard card in cards)
    //                             {
    //                                 if (card.IsAffected())
    //                                 {
    //                                     MarvelCard card1 = (MarvelCard)cards[0];
    //                                     game.GetLocationInfo()[loc].AddScore(player, -5);
    //                                     card1.SetAffected(false);
    //                                 }
    //                             }
    //                         }
    //                     }
    //                     break;
                    
    //             }
    //         }

    //     }
    //     return false;
    // }
}