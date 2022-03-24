using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDemo : MonoBehaviour
{
    // todo #1 set up properties
    public int health = 3;
    public float speed = 3f;
    public int coins = 3;
    

    public List<Transform> waypointList;
    //public List<Transform> nextWayPoint;

    private int targetWaypointIndex;
    
    //   health, speed, coin worth
    //   waypoints
    //   delegate event for outside code to subscribe and be notified of enemy death
    public delegate void EnemyDied(EnemyDemo deadEnemy); 
    public event EnemyDied OnEnemyDied;
    // NOTE! This code should work for any speed value (large or small)
    //private Camera camera;
    //-----------------------------------------------------------------------------
    void Start()
    {
        // todo #2
        //   Place our enemy at the starting waypoint
       
            transform.position = waypointList[0].position;
            targetWaypointIndex = 1;
        
    //transform.position = nextWayPoint[nextWayPoint++].transform.position;

    }

    //-----------------------------------------------------------------------------
    void Update()
    {
        // todo #3 Move towards the next waypoint
        // for (int i = 0; i < 5; i++){
        //    transform.position = waypointList[i].position;
        //    targetWaypointIndex = 4;
        // }
        Vector3 targetPosition = waypointList[targetWaypointIndex].position;
        //Vector3 targetPosition = nextWayPoint[nextWayPoint++].transform.position;
        Vector3 movementDir = (targetPosition - transform.position).normalized;
        Vector3 target = targetPosition - transform.position;

        Vector3 newPosition = targetPosition - transform.position;
        newPosition += movementDir * speed * Time.deltaTime;

        transform.position = newPosition;

        // todo #4 Check if destination reaches or passed and change target

        bool enemyDied = false;
       // if (enemyDied)
       // {
       //   OnEnemyDied?.Invoke(this);
       // }
        if (health <= 0f)
        {
            OnEnemyDied?.Invoke(this);
        }
        
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
    //        if (Physics.Raycast(ray, out var hit))
    //        {
    //            if (hit.transform.gameObject == gameObject)
    //            {
    //                health -= 1;
    //           }
    //        }
    //    }
    }

    //-----------------------------------------------------------------------------
    //private void TargetNextWaypoint()
    //{
    //}

 
}
