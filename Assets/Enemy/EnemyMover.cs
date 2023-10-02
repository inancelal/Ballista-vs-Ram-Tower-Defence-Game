using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoints> path = new List<Waypoints>();
    [SerializeField] [Range(0f,5f)] float speed = 1f;
    Enemy enemy;

    void OnEnable()
    {
        FindPath();
        returnToStart();
        StartCoroutine(WayPointDebugger());
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void FindPath()
    {
        path.Clear();

        GameObject parent = GameObject.FindGameObjectWithTag("path");

        foreach(Transform child in parent.transform)
        {
            Waypoints waypoints = (child.GetComponent<Waypoints>());
            if(waypoints != null)
            {
            path.Add(waypoints);
            }
        }         
    }

    void returnToStart()
    {
        transform.position = path[0].transform.position;
    }     


    IEnumerator WayPointDebugger()
    {
        foreach (Waypoints waypoints in path)
        {
            Vector3 startingPosition = transform.position; 
            Vector3 endPosition = waypoints.transform.position;
            float passingTime = 0f;
            
            transform.LookAt(endPosition);

            while(passingTime < 1)
            {
                passingTime += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startingPosition, endPosition, passingTime);
                yield return new WaitForEndOfFrame();
            }
        }
        FinishPath();
    }

    void FinishPath()
    {
        enemy.StealGold();
        gameObject.SetActive(false);
    }
}
