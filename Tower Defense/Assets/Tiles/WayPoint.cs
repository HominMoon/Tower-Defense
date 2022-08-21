using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] bool isPlacable = false;
    [SerializeField] GameObject towerPrefab;

    public bool IsPlacable { get { return isPlacable; } }

    // public bool GetIsPlaceable(){
    //     return isPlacable;
    // }

    void OnMouseDown()
    {
        if (isPlacable)
        {
            Debug.Log(transform.name);
            Instantiate(towerPrefab, transform.position, Quaternion.identity);
            isPlacable = false;
        }

    }
}
