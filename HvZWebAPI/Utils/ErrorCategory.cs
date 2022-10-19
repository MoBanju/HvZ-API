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

    public static string OUT_GAME_AREA()
    {
        return $"The zombie must execute he kill inside of the area game!";
    }

    public static string COORDINATES()
    {
        return $"The cordinates from North East must be bigger than South West";
    }
}
