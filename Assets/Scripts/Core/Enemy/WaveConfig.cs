using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config ")]
public class WaveConfig : ScriptableObject
    
{
    public GameObject enemyPrefab;
    public GameObject pathPrefab;
    public float timeBetweenSpawns = 0.5f;
    public float spawnRandomFactor = 0.3f;
    public int numberOfEnemies = 5;
    public float moveSpeed = 2f;
    public int waveCount = 1;

    public GameObject GetEnemyPrefab()  {return enemyPrefab;}  
    public int GetWaveCount() { return waveCount; }
    public List<Transform> GetWaypoints()
    {
        List<Transform> waveWaypoints = new List<Transform>();
        foreach (Transform item in pathPrefab.transform)
        {
            waveWaypoints.Add(item);
        }

        return waveWaypoints; 
    }
   
    public float GetTimeBetweenSpawn() { return timeBetweenSpawns; }
    public float GetSpawnRandomFactor() { return spawnRandomFactor; }
    public int GetNumberOfEnemies() { return numberOfEnemies; }
    public float GetMoveSpeed() { return moveSpeed; }
    
}
