using HvZWebAPI.Models;

namespace HvZWebAPI.Data
{
    public class SeedDataHelper
    {
        public static List<User> GetUsers()
        {
            List<User> users = new List<User>()
            {
                new User() {Id=1, KeyCloakId="KC11", FirstName="Ole", LastName="Streetman"},
                new User() {Id=2, KeyCloakId="KC12", FirstName="Eivind", LastName="Johnson"},
                new User() {Id=3, KeyCloakId="KC13", FirstName="Ibrahim", LastName="Banjai"},
                new User() {Id=4, KeyCloakId="KC14", FirstName="Hakon", LastName="Haga"},
                new User() {Id=5, KeyCloakId="KC15", FirstName="Patricia", LastName="Mahomes"},
                new User() {Id=6, KeyCloakId="KC16", FirstName="James", LastName="Jackson"},
                new User() {Id=7, KeyCloakId="KC17", FirstName="Lamar", LastName="Random"},
            };
            return users;
        }

        public static List<Player> GetPlayers()
        {
            List<Player> players = new List<Player>()
            {
                new Player(){ Id=1, IsHuman=true, BiteCode="Street", IsPatientZero=false, UserId=1, GameId=2},
                new Player(){ Id=2, IsHuman=false, BiteCode="BooHoo", IsPatientZero=true, UserId=3, GameId=2},
                new Player(){ Id=3, IsHuman=false, BiteCode="Hello", IsPatientZero=false, UserId=4, GameId=2},
                new Player(){ Id=4, IsHuman=true, BiteCode="Helloma", IsPatientZero=false, UserId=7, GameId=2},
            };
            return players;
        }

        public static List<Game> GetGames()
        {
            List<Game> games = new List<Game>()
            {
                new Game(){ Id=1, Name="Jungle", State=State.Registration, Description="Hosted by George of the Jungle."},
                new Game(){ Id=2, Name="Island", State=State.Progress, Description="Match happens in Finland."},
                new Game(){ Id=3, Name="Ocean", State=State.Progress, Description = "Sharks, Bombs and Boats."},
                new Game(){ Id=4, Name="Space", State=State.Complete, Description = "Armstrong in the building."},
            };
            return games;
        }

        public static List<Kill> GetKills()
        {
            List<Kill> kills = new List<Kill>()
            {
                new Kill(){ Id=1, TimeDeath= DateTime.UtcNow, GameId=2 },
                new Kill(){ Id=2, TimeDeath= DateTime.UtcNow, GameId=2 },
                new Kill(){ Id=3, TimeDeath= DateTime.UtcNow, GameId=2 },
            };
            return kills;
        }

        public static List<PlayerKill> GetPlayerKills()
        {
            List<PlayerKill> playerKills = new()
            {
                new PlayerKill(){ KillId=1, IsVictim = false, PlayerId=1 },
                new PlayerKill(){ KillId=1, IsVictim = true, PlayerId=1 },
            };
            return playerKills;
        }

        public static List<Chat> GetChats()
        {
            List<Chat> chats = new List<Chat>()
            {
                new Chat(){ Id=1, Message="Got him!", ChatTime=DateTime.UtcNow,
                    IsHumanGlobal=false, IsZombieGlobal= true, GameId=2, PlayerId=2},
                new Chat(){ Id=2, Message="Run away!", ChatTime=DateTime.UtcNow,
                    IsHumanGlobal=true, IsZombieGlobal= false, GameId=2, PlayerId=1},
                new Chat(){ Id=3, Message="Like... Hello", ChatTime=DateTime.UtcNow,
                    IsHumanGlobal=false, IsZombieGlobal= false, GameId=2, PlayerId=3},
            };
            return chats;
        }
    }
}
