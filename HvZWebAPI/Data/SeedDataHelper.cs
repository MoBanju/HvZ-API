﻿using HvZWebAPI.Models;

namespace HvZWebAPI.Data
{
    public class SeedDataHelper
    {
        public static List<User> GetUsers()
        {
            List<User> users = new List<User>()
            {
                new User() {Id=1, KeyCloakId="f416c45a-2945-4047-b609-06de42279237", FirstName="mordi", LastName="007"}, //Admin
                new User() {Id=2, KeyCloakId="2e951202-167e-40fd-8fb1-91d2416d0d10", FirstName="Øyvind", LastName="Sande Reitan"},
                new User() {Id=3, KeyCloakId="816cf1b0-c9e5-47b1-92f0-5927695b238a", FirstName="Funny", LastName="Man"},
                new User() {Id=4, KeyCloakId="d2cb4a5b-3bb1-4a36-b3ae-a370c26e9646", FirstName="Bertelsen", LastName="Eivind"},
                new User() {Id=5, KeyCloakId="fa31d802-1e3c-4909-b9e9-210978fd9688", FirstName="Kaffi", LastName="Elsker"},
                new User() {Id=6, KeyCloakId="cd501590-5292-41cd-a170-7fea0b879bb0", FirstName="Vann", LastName="Elsker"},
                new User() {Id=7, KeyCloakId="6cbfe3cb-9e81-438a-a56c-625624efc2a4", FirstName="Cola", LastName="Elske"},
            };
            return users;
        }

        public static List<Player> GetPlayers()
        {
            List<Player> players = new List<Player>()
            {
                new Player(){ Id=5, IsHuman=true, BiteCode="Five", IsPatientZero=false, UserId=1, GameId=1},
                new Player(){ Id=7, IsHuman=true, BiteCode="Seven", IsPatientZero=false, UserId=4, GameId=1},
                new Player(){ Id=6, IsHuman=true, BiteCode="Six", IsPatientZero=false, UserId=3, GameId=1},
                new Player(){ Id=1, IsHuman=false, BiteCode="Street", IsPatientZero=false, UserId=1, GameId=2},
                new Player(){ Id=4, IsHuman=false, BiteCode="Helloma", IsPatientZero=true, UserId=2, GameId=2},
                new Player(){ Id=8, IsHuman=true, BiteCode="Eight", IsPatientZero=false, UserId=1, GameId=3},
                new Player(){ Id=9, IsHuman=true, BiteCode="Nine", IsPatientZero=false, UserId=2, GameId=3},
                new Player(){ Id=2, IsHuman=true, BiteCode="BooHoo", IsPatientZero=false, UserId=3, GameId=3},
                new Player(){ Id=3, IsHuman=false, BiteCode="Hello", IsPatientZero=true, UserId=4, GameId=3},
            };
            return players;
        }

        public static List<Game> GetGames()
        {
            List<Game> games = new List<Game>()
            {
                new Game(){ Id=1, Name="Jungle", State=State.Registration, Description="Hosted by George of the Jungle.", Sw_lat=60.395123, Sw_lng=5.314687, Ne_lat=60.395528, Ne_lng=5.320989},
                new Game(){ Id=2, Name="Island", State=State.Progress, Description="Match happens in Finland.",Sw_lat=58.983857, Sw_lng=5.613486, Ne_lat=58.984830, Ne_lng=5.619021},
                new Game(){ Id=3, Name="Ocean", State=State.Progress, Description = "Sharks, Bombs and Boats.", Sw_lat=58.870288, Sw_lng=5.602136, Ne_lat=58.895002, Ne_lng=5.644981},
                new Game(){ Id=4, Name="Space", State=State.Complete, Description = "Armstrong in the building.", Sw_lat=58.940605, Sw_lng=5.803512, Ne_lat=58.964327, Ne_lng=5.846468},
            };
            return games;
        }

        public static List<Kill> GetKills()
        {
            List<Kill> kills = new List<Kill>()
            {
                new Kill(){ Id=1, TimeDeath= DateTime.UtcNow, GameId=2, Description="CAMPER!!", Latitude=58.9839, Longitude=5.615},
                new Kill(){ Id=2, TimeDeath= DateTime.UtcNow, GameId=2, Description="GET HIM!", Latitude=58.984173, Longitude=5.615167},
                new Kill(){ Id=3, TimeDeath= DateTime.UtcNow, GameId=3, Description="", Latitude=58.885642, Longitude=5.633585},
                new Kill(){ Id=4, TimeDeath= DateTime.UtcNow, GameId=3, Description="", Latitude=58.893353, Longitude=5.637278},
            };
            return kills;
        }

        public static List<PlayerKill> GetPlayerKills()
        {
            List<PlayerKill> playerKills = new()
            {
                // Game 2
                new PlayerKill(){ KillId=1, IsVictim = true, PlayerId=4 },
                new PlayerKill(){ KillId=1, IsVictim = false, PlayerId=1 },
                new PlayerKill(){ KillId=2, IsVictim = true, PlayerId=2 },
                new PlayerKill(){ KillId=2, IsVictim = false, PlayerId=3 },
                // Game 3
                new PlayerKill(){ KillId=3, IsVictim = true, PlayerId=8 },
                new PlayerKill(){ KillId=3, IsVictim = false, PlayerId=3 },
                new PlayerKill(){ KillId=4, IsVictim = true, PlayerId=2 },
                new PlayerKill(){ KillId=4, IsVictim = false, PlayerId=8 },
            };
            return playerKills;
        }

        public static List<Chat> GetChats()
        {
            List<Chat> chats = new List<Chat>()
            {
                new Chat(){ Id=1, Message="Got him!", ChatTime=DateTime.UtcNow,
                    IsHumanGlobal=false, IsZombieGlobal= true, GameId=3, PlayerId=2},
                new Chat(){ Id=2, Message="Run away!", ChatTime=DateTime.UtcNow,
                    IsHumanGlobal=false, IsZombieGlobal= false, GameId=2, PlayerId=1},
                new Chat(){ Id=3, Message="Like... Hello", ChatTime=DateTime.UtcNow,
                    IsHumanGlobal=true, IsZombieGlobal= false, GameId=1, PlayerId=7},
            };
            return chats;
        }
    }
}
