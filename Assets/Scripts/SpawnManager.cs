using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform spawnPoint;
    
    public ObstacleObjectPool objectPool; 

    void Start()
    {
        InvokeRepeating(nameof(Spawn), 0, 2f);
    }

    void Spawn()
    {
        GameObject player = GameObject.Find("Player");
        if (player != null)
        {
            bool isGameOver = player.GetComponent<PlayerController>().gameOver;
            if (isGameOver)
            {
                return;
            }
        }
        
        int randomObstacleType = Random.Range(0, 3);
        
        GameObject obstacle = objectPool.Acquire(randomObstacleType);

        if (obstacle != null)
        {
            obstacle.transform.position = spawnPoint.position;
            obstacle.transform.rotation = obstacle.transform.rotation;
            obstacle.SetActive(true);
        }
    }
}