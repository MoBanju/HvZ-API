using HvZWebAPI.Models;

namespace HvZWebAPI.Utils;

public class ErrorCategory
{
    public static string INTERNAL
    {
        get { return "Oops, internal error try again later"; }
    }
    public static string INVALID_CHAT_SCOPE
    {
        get { return "A chat message can only be zombie, human or global scoped."; }
    }
    public static string POST_PLAYER_HUMAN_AND_PATIENT_ZERO
    {
        get { return "Cant add new player being human and patient zero simultaneously"; }
    }
    public static string ONLY_A_ZOMBIE_CAN_POST_TO_ZOMBIE_CHAT(int game_id, int player_id)
    {
        return $"player {player_id} cant post to the zombie chat because she/he is human";
    }
    public static string ONLY_A_HUMAN_CAN_POST_TO_HUMAN_CHAT(int game_id, int player_id)
    {
        return $"player {player_id} cant post to the human chat because she/he is a zombie";
    }
    public static string PLAYER_NOT_IN_GAME(int game_id, int player_id)
    {
        return $"No player with player id {player_id} is participating in a game with game id {game_id}";
    }

    public static string PLAYER_NOT_IN_GAME(int game_id, string bitecode)
    {
        return $"No player with player bitecode {bitecode} is participating in a game with game id {game_id}";
    }

    public static string GAME_NOT_FOUND(int game_id)
    {
        return $"No game with id {game_id} found";
    }

    public static string KILL_NOT_FOUND(int kill_id, int game_id)
    {
        return $"No kill with id {kill_id} found, atleast not in game {game_id}";
    }

    public static string PLAYER_NOT_FOUND(int player_id)
    {
        return $"No player with id {player_id} found";
    }

    public static string PLAYER_NOT_FOUND(string bitecode)
    {
        return $"No player with bitecode {bitecode} found";
    }

    public static string MISSION_NOT_FOUND(int mission_id)
    {
        return $"No kill with id {mission_id} found";
    }

    public static string UNIQUE_PLAYER_GAME(string keycloak_id)
    {
        return $"User {keycloak_id} allready has a player in this game, no more are allowed";
    }

    public static string UNIQUE_PLAYER_WORLD(string bitecode)
    {
        return $"The player bitecode {bitecode} is not globally unique, and thus cannot be used";
    }

    public static string FAILURE
    {
        get { return "The database failed to change any rows"; }
    }

    public static string FAILED_TO_CREATE(string entity)
    {
        return $"Failed to create {entity}";
    }

    public static string FAILED_TO_UPDATE(string entity)
    {
        return $"Failed to update {entity}";
    }


    public static string CHAT_NOT_FOUND(int chat_id, int game_id)
    {
        return $"No chat with id {chat_id} found in game with id {game_id}";
    }


    public static string NO_KEYCLOAK_ID
    {
        get { return $"No keycloak-identifier found on the current user token"; }
    }

    public static string NO_KEYCLOAK_ID_ADMIN
    {
        get { return $"A keycloak-identifier must be included in the request"; }
    }


    public static string VICTIM_NOT_FOUND_IN_GAME(int game_id, string bitecode)
    {
        return $"No victim with id {bitecode} found in game with id {game_id}";
    }

    public static string KILLER_NOT_FOUND_IN_GAME(int game_id, int killer_id)
    {
        return $"No killer with id {killer_id} found in game with id {game_id}";
    }

    public static string KILLER_VICTIM_NOT_SAME_GAME(int game_id, int killer_id, string bitecode)
    {
        return $"Killer with id {killer_id} and Victim with bitecode {bitecode} are not found in the same game. They are supposed to be in the game with id {game_id}";
    }

    public static string ALREADY_ZOMBIE(string bitecode)
    {
        return $"The player with bitecode {bitecode} is already a zombie and therefore it cannot be killed!";
    }
    public static string KILLER_HUMAN(int killer_id)
    {
        return $"The player with Id {killer_id} is a human and therefore cant execute the kill!";
    }

    public static string KILL_OUT_GAME_AREA()
    {
        return $"The zombie must execute the kill inside of the area game!";
    }

    public static string MISSION_OUT_GAME_AREA()
    {
        return $"The mission must be set inside the gamearea!";
    }

    public static string COORDINATES()
    {
        return $"The cordinates from North East must be bigger than South West";
    }


    public static string ILLEGAL_SQUAD_TYPE()
    {
        return "You can only be in a squadtype of your own faction";
    }

    public static string SQUAD_NOT_FOUND(int game_id, int squad_id)
    {
        return $"No squad with id {squad_id} found in that game {game_id}";
    }

    public static string NOT_MEMBER_OF_SQUAD(int squad_member_id, int squad_id)
    {
        return $"No squadmember with id {squad_member_id} found in that squad {squad_id}";
    }

    public static string SQUADMEMBER_NOT_FOUND(int squad_member_id)
    {
        return $"No squad with id {squad_member_id} found";
    }

    public static string USER_NOT_FOUND()
    {
        return $"No user with your keycloakid was found";
    }

    public static string USER_HAS_NO_PLAYERS()
    {
        return $"No user with your keycloakid has players";
    }

    public static string CANT_LOOK_AT_OTHER_FACTIONS_MISSIONS()
    {
        return "You cannot look at human missions if you are dead or zombie missions if you are alive";
    }

    public static string ILLEGAL_TO_SHOW_MISSION_TO_BOTH_FACTIONS()
    {
        return "Mission can only be visible to one faction at a time, or neither";
    }

    public static string TOPRANK
    {
        get { return "Boss"; }
    }

    public static string TOPRANK_IS_RESERVED
    {
        get { return "Only the founder can have this rank"; }
    }

    public static string UNIQUE_PLAYER_SQUAD(int game_id)
    {
        return $"Player is allready in a squad this game {game_id}, no more are allowed";
    }
}
