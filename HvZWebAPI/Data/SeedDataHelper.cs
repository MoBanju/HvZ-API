using HvZWebAPI.Models;

namespace HvZWebAPI.Data
{
    public class SeedDataHelper
    {
        public static List<User> GetUsers()
        {
            List<User> users = new List<User>()
            {
                new User() {Id=1, FirstName="Ole", LastName="Streetman"},
                new User() {Id=2, FirstName="Eivind", LastName="Johnson"},
                new User() {Id=3, FirstName="Ibrahim", LastName="Banjai"},
                new User() {Id=4, FirstName="Hakon", LastName="Haga"},
                new User() {Id=5, FirstName="Patricia", LastName="Mahomes"},
                new User() {Id=6, FirstName="James", LastName="Jackson"},
                new User() {Id=7, FirstName="Lamar", LastName="Random"},
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
                new Player(){ Id=4, IsHuman=true, BiteCode="Hello", IsPatientZero=false, UserId=7, GameId=2},
            };
            return players;
        }

        public static List<Game> GetGames()
        {
            List<Game> games = new List<Game>()
            {
                new Game(){ Id=1, Name="Jungle", State=State.Registration},
                new Game(){ Id=2, Name="Island", State=State.Progress},
                new Game(){ Id=3, Name="Ocean", State=State.Progress},
                new Game(){ Id=4, Name="Space", State=State.Complete},
            };
            return games;
        }

        public static List<Kill> GetKills()
        {
            List<Kill> kills = new List<Kill>()
            {
                new Kill(){ Id=1, TimeDeath= DateTime.Now, GameId=2, KillerId=2, VictimId=1},
                new Kill(){ Id=2, TimeDeath= DateTime.Now, GameId=2, KillerId=4, VictimId=3},
                new Kill(){ Id=3, TimeDeath= DateTime.Now, GameId=2, KillerId=2, VictimId=4},
            };
            return kills;
        }

        public static List<Chat> GetChats()
        {
            List<Chat> chats = new List<Chat>()
            {
                new Chat(){ Id=1, Message="Got him!", ChatTime=DateTime.Now,
                    IsHumanGlobal=false, IsZombieGlobal= true, GameId=2, PlayerId=2},
                new Chat(){ Id=2, Message="Run away!", ChatTime=DateTime.Now,
                    IsHumanGlobal=true, IsZombieGlobal= false, GameId=2, PlayerId=1},
                new Chat(){ Id=3, Message="Like... Hello", ChatTime=DateTime.Now,
                    IsHumanGlobal=false, IsZombieGlobal= false, GameId=2, PlayerId=3},
            };
            return chats;
        }
    }
}
