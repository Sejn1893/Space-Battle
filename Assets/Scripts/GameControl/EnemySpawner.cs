using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<WaveConfig> waveConfigs;
    public int _startingWave = 0;
    public int waveCount = 3;                  // waveCount + 1 = Number of waves
   
    
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnAllWaves());


    }

    private IEnumerator SpawnAllWaves()
    {
        for (int i = 0; i <= waveCount; i++)
        {
            for (int k = 0; k < waveConfigs.Count; k++)
            {
                WaveConfig currentWave = waveConfigs[k];
                yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
            }
        }
    }
    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        for (int i = 0; i < waveConfig.GetNumberOfEnemies(); i++)
        {
            GameObject newEnemy = Instantiate(waveConfig.GetEnemyPrefab(), waveConfig.GetWaypoints()[0].transform.position, Quaternion.identity);

            newEnemy.GetComponent<EnemyPathing>().SetEnemyConfig(waveConfig);

            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawn());
        }
    }    

    // Update is called once per frame
    void Update()
    {
        
        

    }
}
