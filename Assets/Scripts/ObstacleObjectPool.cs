using System.Collections.Generic;
using UnityEngine;

public class ObstacleObjectPool : MonoBehaviour
{
    public GameObject obstacleBarrelPrefab;
    public GameObject obstacleBarrierPrefab;
    public GameObject obstacleStoneWallPrefab;
    public int poolSize = 10;

    private List<GameObject> obstacleBarrelPool;
    private List<GameObject> obstacleBarrierPool;
    private List<GameObject> obstacleStoneWallPool;

    void Awake()
    {
        obstacleBarrelPool = new List<GameObject>();
        obstacleBarrierPool = new List<GameObject>();
        obstacleStoneWallPool = new List<GameObject>();
        
        GeneratePool(obstacleBarrelPrefab, obstacleBarrelPool, poolSize);
        GeneratePool(obstacleBarrierPrefab, obstacleBarrierPool, poolSize);
        GeneratePool(obstacleStoneWallPrefab, obstacleStoneWallPool, poolSize);
    }
    
    private void GeneratePool(GameObject prefab, List<GameObject> pool, int size)
    {
        for (int i = 0; i < size; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }
    
    public GameObject Acquire(int obstacleType)
    {
        List<GameObject> targetPool = null;
        GameObject targetPrefab = null;
        
        switch (obstacleType)
        {
            case 0:
                targetPool = obstacleBarrelPool;
                targetPrefab = obstacleBarrelPrefab;
                break;
            case 1:
                targetPool = obstacleBarrierPool;
                targetPrefab = obstacleBarrierPrefab;
                break;
            case 2:
                targetPool = obstacleStoneWallPool;
                targetPrefab = obstacleStoneWallPrefab;
                break;
            default:
                Debug.LogWarning("Invalid Obstacle Type");
                return null;
        }
        
        foreach (GameObject obj in targetPool)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }
        
        GameObject newObj = Instantiate(targetPrefab);
        newObj.SetActive(false);
        targetPool.Add(newObj);
        return newObj;
    }
    
    public void Release(GameObject obstacle, int obstacleType)
    {
        obstacle.SetActive(false);
    }
}