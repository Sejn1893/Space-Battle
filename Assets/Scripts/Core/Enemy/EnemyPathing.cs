using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    List<Transform> waypoints;
    WaveConfig waveConfig;
    private int _waypointIndex = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[_waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    public void SetEnemyConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }    

    private void Move()
    {
        if (_waypointIndex <= waypoints.Count - 1)
        {
            Vector3 targetPosition = waypoints[_waypointIndex].transform.position;
            float moveSpeed = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed);

            if (transform.position == targetPosition)
            {
                _waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
