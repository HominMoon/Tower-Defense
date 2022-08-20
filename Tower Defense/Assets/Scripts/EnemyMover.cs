using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{

    [SerializeField] List<WayPoint> path = new List<WayPoint>();
    [SerializeField] float waitTime = 1f;

    void Start()
    {
        Debug.Log("Start");
        StartCoroutine(FindingPath());
        Debug.Log("Start End");
    }

    IEnumerator FindingPath() //coroutine
    {
        foreach (WayPoint wayPoint in path)
        {
            Debug.Log(wayPoint.name);
            transform.position = wayPoint.transform.position;
            yield return new WaitForSeconds(waitTime);
        }
    }
}
