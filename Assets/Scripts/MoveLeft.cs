using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 10f;
    private float defaultSpeed;
    public int obstacleType; 
    private ObstacleObjectPool objectPool;
    
    void Awake()
    {
        defaultSpeed = speed;
        objectPool = FindObjectOfType<ObstacleObjectPool>();
    }
    
    void OnEnable()
    {
        speed = defaultSpeed;
    }

    void Update()
    {
        GameObject player = GameObject.Find("Player");
        if (player != null) 
        {
            bool isGameOver = player.GetComponent<PlayerController>().gameOver;
            if (isGameOver)
            {
                speed = 0;
            }
        }

        transform.Translate(Vector3.left * speed * Time.deltaTime);
        
        if (transform.position.x < -15 && gameObject.CompareTag("Obstacle"))
        {
            if (objectPool != null)
            {
                objectPool.Release(gameObject, obstacleType);
            }
            else
            {
                Destroy(gameObject); 
            }
        }
    }
}