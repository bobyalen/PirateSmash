using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public static class GM 
{
    public static int player1lives;
    public static int player2lives;

    public static void InitGame()
    {
        player1lives = 2;
        player2lives = 2;
    }

    public static void player1Death(int points)
    {
        player1lives--;
    }
    
    public static void player2Death(int points)
    {
        player2lives--;
    }
}
