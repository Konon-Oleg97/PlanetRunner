using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField]
    Text TimeText;
    [SerializeField]
    Text NumberLapsText;
    [SerializeField]
    Text NumberSpawnObstacleText;
    [SerializeField]
    Text PercentLapText;

    private void Start()
    {
        TimeText.text = PlayerStats.Time.ToString("0.0");
        NumberLapsText.text = PlayerStats.NumberLaps.ToString();
        NumberSpawnObstacleText.text = PlayerStats.NumberSpawnObstacle.ToString();
        PercentLapText.text = PlayerStats.PercentLap.ToString("0");
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Menu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }


}
