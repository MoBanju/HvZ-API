using HvZWebAPI.Models;

namespace HvZWebAPI.Utils;

public class ErrorCategory
{
    public static string INTERNAL {
        get { return "Oops, internal error try again later"; }
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

    public static string PLAYER_NOT_FOUND(int player_id)
    {
        return $"No player with id {player_id} found";
    }

    public static string PLAYER_NOT_FOUND(string bitecode)
    {
        return $"No player with bitecode {bitecode} found";
    }

    public static string UNIQUE_PLAYER(string keycloak_id)
    {
        return $"User {keycloak_id} allready has a player in this game, no more are allowed";
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
}
