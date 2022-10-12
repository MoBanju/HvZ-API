using HvZWebAPI.Models;

namespace HvZWebAPI.Data
{
    public class SeedDataHelper
    {

        /*
         * [
 {
   firstname: "mordi",
   lastname: "007",
   keyCloakId: "f416c45a-2945-4047-b609-06de42279237"
 },
{
   firstname: "Øyvind",
   lastname: "Sande Reitan",
   keyCloakId: "2e951202-167e-40fd-8fb1-91d2416d0d10"
 },
{
   firstname: "Funny",
   lastname: "Man",
   keyCloakId: "816cf1b0-c9e5-47b1-92f0-5927695b238a"
 },
{
   firstname: "Bertelsen",
   lastname: "Eivind",
   keyCloakId: "d2cb4a5b-3bb1-4a36-b3ae-a370c26e9646"
 },
]
         */

        public static List<User> GetUsers()
        {
            List<User> users = new List<User>()
            {
                new User() {Id=1, KeyCloakId="f416c45a-2945-4047-b609-06de42279237", FirstName="mordi", LastName="007"},
                new User() {Id=2, KeyCloakId="2e951202-167e-40fd-8fb1-91d2416d0d10", FirstName="Øyvind", LastName="Sande Reitan"},
                new User() {Id=3, KeyCloakId="816cf1b0-c9e5-47b1-92f0-5927695b238a", FirstName="Funny", LastName="Man"},
                new User() {Id=4, KeyCloakId="d2cb4a5b-3bb1-4a36-b3ae-a370c26e9646", FirstName="Bertelsen", LastName="Eivind"},
            };
            return users;
        }

        public static List<Player> GetPlayers()
        {
            List<Player> players = new List<Player>()
            {
                new Player(){ Id=1, IsHuman=true, BiteCode="Street", IsPatientZero=false, UserId=1, GameId=2},
                new Player(){ Id=2, IsHuman=false, BiteCode="BooHoo", IsPatientZero=true, UserId=3, GameId=3},
                new Player(){ Id=3, IsHuman=false, BiteCode="Hello", IsPatientZero=false, UserId=4, GameId=3},
                new Player(){ Id=4, IsHuman=true, BiteCode="Helloma", IsPatientZero=false, UserId=2, GameId=2},
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
                new Kill(){ Id=4, TimeDeath= DateTime.UtcNow, GameId=3 },
            };
            return kills;
        }

        public static List<PlayerKill> GetPlayerKills()
        {
            List<PlayerKill> playerKills = new()
            {
                new PlayerKill(){ KillId=1, IsVictim = false, PlayerId=1 },
                new PlayerKill(){ KillId=1, IsVictim = true, PlayerId=4 },
                new PlayerKill(){ KillId=2, IsVictim = true, PlayerId=2 },
                new PlayerKill(){ KillId=2, IsVictim = false, PlayerId=3 },
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
