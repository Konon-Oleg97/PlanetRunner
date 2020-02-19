using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [Header("Obstacle")]
    [SerializeField]
    GameObject Obstacle;
    public float TimeBetweenSpawnObstacle;
    [Header("Player Settings")]
    public float PlayerSpeed;
    [Range(0,100)]
    public int PercentSpeed;
    [Header("Game Canvas")]
    [SerializeField]
    GameObject StatsGameCanvas;
    [SerializeField]
    GameObject GameOverCanvas;
    [Space]
    [SerializeField]
    float[] H;
    [SerializeField]
    ParticleSystem ps;

    GameObject player;
    int i;

    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Time.timeScale = 1f;
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(SpawnObstacle());
        i = 0;
    }
    private void Update()
    {
        PlayerStats.Time += Time.deltaTime;


        PlayerStats.PercentLap += Time.deltaTime*2;
        if (PlayerStats.PercentLap>=100)
        {

            PlayerStats.PercentLap = 0;
            PlayerStats.NumberLaps++;
            NextLap();
        }
    }

    IEnumerator SpawnObstacle()
    {
        while (true)
        {
            yield return new WaitForSeconds(TimeBetweenSpawnObstacle);
            Vector3 playerPosition = player.transform.position;
            Quaternion playerRotation = player.transform.rotation;
            yield return new WaitForSeconds(1f);
            Instantiate(Obstacle, playerPosition, playerRotation);
            PlayerStats.NumberSpawnObstacle++;
        }
    }

    public void EndGame()
    {
        Time.timeScale = 0f;
        StatsGameCanvas.SetActive(false);
        GameOverCanvas.SetActive(true);
    }

    public void NextLap()
    {
        if (i == H.Length-1)
            i = 0;
        else
            i++;

        PlayerSpeed += PlayerSpeed * PercentSpeed / 100;
        TimeBetweenSpawnObstacle -= TimeBetweenSpawnObstacle * PercentSpeed / 10;
        var main = ps.main;
        main.startColor = Color.HSVToRGB(H[i]/360f,1f,1f);
    }

}
