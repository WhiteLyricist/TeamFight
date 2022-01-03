
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchForTheEnemy : MonoBehaviour
{
    public static GameObject[] team1 
    {
        private set;
        get;
    }
    public static GameObject[] team2 
    {
        private set;
        get;
    }

    void Awake()
    {
        SearchEnemy();
    }

    public static void SearchEnemy() 
    {
        team1 = GameObject.FindGameObjectsWithTag("Team 1");
        team2 = GameObject.FindGameObjectsWithTag("Team 2");
    }

}
