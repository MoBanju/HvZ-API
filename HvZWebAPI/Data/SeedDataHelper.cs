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
                // Game 1
                new Player(){ Id=5, IsHuman=true, BiteCode="8xl2v6cho4w", IsPatientZero=false, UserId=5, GameId=1},
                new Player(){ Id=7, IsHuman=true, BiteCode="7cbq3kjnz9f", IsPatientZero=false, UserId=4, GameId=1},
                new Player(){ Id=6, IsHuman=false, BiteCode="ao56yqf3nel", IsPatientZero=true, UserId=3, GameId=1},

                // Game 2
                new Player(){ Id=1, IsHuman=false, BiteCode="udo9zhwi9q", IsPatientZero=false, UserId=5, GameId=2},
                new Player(){ Id=4, IsHuman=false, BiteCode="gnr5uvef03", IsPatientZero=true, UserId=2, GameId=2},
                new Player(){ Id=13, IsHuman=false, BiteCode="7ijo6pppt9d", IsPatientZero=false, UserId=3, GameId=2},
                new Player(){ Id=14, IsHuman=false, BiteCode="n7p3cb0xoh", IsPatientZero=false, UserId=4, GameId=2},

                // Game 3
                new Player(){ Id=8, IsHuman=false, BiteCode="pzuaz7xxts", IsPatientZero=false, UserId=5, GameId=3},
                new Player(){ Id=9, IsHuman=true, BiteCode="pt4nv8yilk", IsPatientZero=false, UserId=2, GameId=3},
                new Player(){ Id=2, IsHuman=false, BiteCode="86bhuu95llh", IsPatientZero=false, UserId=3, GameId=3},
                new Player(){ Id=3, IsHuman=false, BiteCode="hphhgffkt27", IsPatientZero=true, UserId=4, GameId=3},

                // Game 4
                new Player(){ Id=10, IsHuman=true, BiteCode="0ox01mfifxu", IsPatientZero=false, UserId=4, GameId=4},
                new Player(){ Id=11, IsHuman=false, BiteCode="y4agjazrxt", IsPatientZero=false, UserId=3, GameId=4},
                new Player(){ Id=12, IsHuman=false, BiteCode="22k36equedx", IsPatientZero=true, UserId=2, GameId=4},
            };
            return players;
        }

        public static List<Game> GetGames()
        {
            List<Game> games = new List<Game>()
            {
                new Game(){ Id=1, Name="Jungle", State=State.Registration, Description="Hosted by George of the Jungle.", StartTime=new DateTime(2022, 10, 10), EndTime=new DateTime(2022, 10, 26),  Sw_lat=58.8574036443497, Sw_lng=5.65963540246227, Ne_lat=58.9056652423756, Ne_lng=5.755525336998},
                new Game(){ Id=2, Name="Island", State=State.Complete, Description="Match happens in Finland.",StartTime=new DateTime(2022, 10, 10), EndTime=new DateTime(2022, 10, 26), Sw_lat=58.983857, Sw_lng=5.613486, Ne_lat=58.984830, Ne_lng=5.619021},
                new Game(){ Id=3, Name="Ocean", State=State.Progress, Description = "Sharks, Bombs and Boats.",StartTime=new DateTime(2022, 10, 10), EndTime=new DateTime(2022, 10, 26), Sw_lat=58.8506558531135, Sw_lng=5.6369517620345, Ne_lat=58.8907681118828, Ne_lng=5.76205547590901},
                new Game(){ Id=4, Name="Space", State=State.Progress, Description = "Armstrong in the building.",StartTime=new DateTime(2022, 10, 10), EndTime=new DateTime(2022, 10, 26), Sw_lat=58.8844258924142, Sw_lng=5.6463966410603, Ne_lat=58.8957799309783, Ne_lng=5.76565759906708},
            };
            return games;
        }

        public static List<Kill> GetKills()
        {
            List<Kill> kills = new List<Kill>()
            {
                // Game 2
                new Kill(){ Id=1, TimeDeath= new DateTime(2022, 10, 13, 13, 37, 59), GameId=2, Description="CAMPER!!", Latitude=58.983936443497, Longitude=5.614},
                new Kill(){ Id=2, TimeDeath= new DateTime(2022, 10, 14, 13, 37, 59), GameId=2, Description="GET HIM!", Latitude=58.984173, Longitude=5.615167},
                // Game 3
                new Kill(){ Id=3, TimeDeath= new DateTime(2022, 10, 13, 13, 37, 59), GameId=3, Description="", Latitude=58.86, Longitude=5.7},
                new Kill(){ Id=4, TimeDeath= new DateTime(2022, 10, 14, 13, 37, 59), GameId=3, Description="", Latitude=58.87, Longitude=5.65},
                // Game 4
                new Kill(){ Id=5, TimeDeath= new DateTime(2022, 10, 13, 13, 37, 59), GameId=4, Description="Fiesty", Latitude=58.89, Longitude=5.68},

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
                new PlayerKill(){ KillId=2, IsVictim = true, PlayerId=13 },
                new PlayerKill(){ KillId=2, IsVictim = false, PlayerId=1 },
                // Game 3
                new PlayerKill(){ KillId=3, IsVictim = true, PlayerId=8 },
                new PlayerKill(){ KillId=3, IsVictim = false, PlayerId=3 },
                new PlayerKill(){ KillId=4, IsVictim = true, PlayerId=2 },
                new PlayerKill(){ KillId=4, IsVictim = false, PlayerId=8 },
                // Game 4
                new PlayerKill(){ KillId=5, IsVictim = true, PlayerId=11 },
                new PlayerKill(){ KillId=5, IsVictim = false, PlayerId=12 },
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



        public static List<Mission> GetMissions()
        {
            List<Mission> missions = new List<Mission>()
            {
                new Mission(){ Id=4, Description="Bring a pencil!", Is_zombie_visible=false, Is_human_visible=true,
                    GameId=1, Start_time=DateTime.UtcNow, End_time=DateTime.UtcNow.AddHours(4)
                    , Latitude=58.885, Longitude=5.72, Name = "Crossword" },

                new Mission(){ Id=2, Description="Touch your toes!", Is_zombie_visible=false, Is_human_visible=true,
                    GameId=2, Start_time=DateTime.UtcNow, End_time=DateTime.UtcNow.AddHours(1)
                    , Latitude=58.9839, Longitude=5.614, Name = "Take a trip"},
                new Mission(){ Id=3, Description="Jump up on the table and do a zombie dance!", Is_zombie_visible=true, Is_human_visible=false,
                    GameId=2, Start_time=DateTime.UtcNow, End_time=DateTime.UtcNow.AddHours(4)
                    , Latitude=58.98398, Longitude=5.617, Name = "JigglyBrains" },

                new Mission(){ Id=1, Description="Touch your head!", Is_zombie_visible=false, Is_human_visible=true,
                    GameId=3, Start_time=DateTime.UtcNow, End_time=DateTime.UtcNow.AddHours(2)
                , Latitude=58.893, Longitude=5.76, Name = "Head here"},
            };
            return missions;
        }


        public static List<Squad> GetSquads()
        {
            List<Squad> squads = new List<Squad>()
            {
                new Squad(){ Id=1, Is_human = true, Name = "ForeverYoung", GameId = 1},

                new Squad(){ Id=2, Is_human = false, Name = "DeadManWalking", GameId = 2},
                new Squad(){ Id=6, Is_human = true, Name = "IOnceLived", GameId = 2},

                new Squad(){ Id=3, Is_human = true, Name = "StayinAlive", GameId = 3},
                new Squad(){ Id=4, Is_human = false, Name = "StayinDead", GameId = 3},

                new Squad(){ Id=5, Is_human = true, Name = "SquadsGalore", GameId = 4},
            };
            return squads;
        }

        public static List<SquadMember> GetSquadMembers()
        {
            List<SquadMember> squadMembers = new List<SquadMember>()
            {
                new SquadMember(){ Id=1, Rank = "Boss", SquadId=1, PlayerId=5, GameId = 1},
                new SquadMember(){ Id=2, Rank = "Goon", SquadId=1, PlayerId=7, GameId = 1},

                new SquadMember(){ Id=3, Rank = "Boss", SquadId=2, PlayerId=1, GameId = 2},
                new SquadMember(){ Id=4, Rank = "Goon", SquadId=2, PlayerId=4, GameId = 2},
                new SquadMember(){ Id=10, Rank = "Boss", SquadId=6, PlayerId=13, GameId = 2},
                new SquadMember(){ Id=11, Rank = "Goon", SquadId=6, PlayerId=14, GameId = 2},

                new SquadMember(){ Id=5, Rank = "Boss", SquadId=3, PlayerId=9, GameId = 3},
                new SquadMember(){ Id=6, Rank = "Goon", SquadId=4, PlayerId=8, GameId = 3},
                new SquadMember(){ Id=7, Rank = "Goon", SquadId=4, PlayerId=2, GameId = 3},
                new SquadMember(){ Id=8, Rank = "Boss", SquadId=4, PlayerId=3, GameId = 3},

                new SquadMember(){ Id=9, Rank = "Boss", SquadId=5, PlayerId=10, GameId = 4},
            };
            return squadMembers;
        }


        public static List<SquadCheckin> GetSquadCheckins()
        {
            

            List<SquadCheckin> squadCheckins = new List<SquadCheckin>()
            {
                new SquadCheckin(){ Id = 1, Start_time = DateTime.UtcNow, End_time = DateTime.UtcNow.AddMinutes(30), GameId = 1, Latitude = 58.88, Longitude = 5.73, SquadId = 1, Squad_MemberId = 2},   

                new SquadCheckin(){ Id = 2, Start_time = DateTime.UtcNow, End_time = DateTime.UtcNow.AddMinutes(20), GameId = 2, Latitude = 58.9844, Longitude = 5.616, SquadId = 2, Squad_MemberId = 3},

                new SquadCheckin(){ Id = 3, Start_time = DateTime.UtcNow, End_time = DateTime.UtcNow.AddMinutes(55), GameId = 3, Latitude = 58.88, Longitude = 5.71, SquadId = 3, Squad_MemberId = 5},
                new SquadCheckin(){ Id = 4, Start_time = DateTime.UtcNow, End_time = DateTime.UtcNow.AddMinutes(55), GameId = 3, Latitude = 58.86, Longitude = 5.73, SquadId = 3, Squad_MemberId = 5},
                new SquadCheckin(){ Id = 5, Start_time = DateTime.UtcNow, End_time = DateTime.UtcNow.AddMinutes(3), GameId = 3, Latitude = 58.87, Longitude = 5.76, SquadId = 4, Squad_MemberId = 8},

                new SquadCheckin(){ Id = 6, Start_time = DateTime.UtcNow, End_time = DateTime.UtcNow.AddMinutes(55), GameId = 4, Latitude = 58.89, Longitude = 5.65, SquadId = 4, Squad_MemberId = 9},
            };
            return squadCheckins;
        }
    }
}
