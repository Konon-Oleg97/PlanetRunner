using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour
{
    [SerializeField]
    Text TimeText;
    [SerializeField]
    Text NumberLapsText;
    [SerializeField]
    Text NumberSpawnObstacleText;
    [SerializeField]
    Text PercentLapText;

    private void Update()
    {
        TimeText.text = PlayerStats.Time.ToString("0.0");
        NumberLapsText.text = PlayerStats.NumberLaps.ToString();
        NumberSpawnObstacleText.text = PlayerStats.NumberSpawnObstacle.ToString();
        PercentLapText.text = PlayerStats.PercentLap.ToString("0");
    }
}
