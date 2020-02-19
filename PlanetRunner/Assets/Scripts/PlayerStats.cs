using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static float PercentLap;
    public static float Time;
    public static float NumberLaps;
    public static float NumberSpawnObstacle;

    private void Start()
    {
        PercentLap = 0;
        Time = 0;
        NumberLaps = 0;
        NumberSpawnObstacle = 0;
    }
}




