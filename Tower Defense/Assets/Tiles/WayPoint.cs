using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] bool isPlacable = false;
    [SerializeField] Tower towerPrefab;

    public bool IsPlacable { get { return isPlacable; } }

    // public bool GetIsPlaceable(){
    //     return isPlacable;
    // }

    void OnMouseDown()
    {
        if (isPlacable)
        {
            bool isPlaced =  towerPrefab.CreateTower(towerPrefab, transform.position);
            isPlacable = !isPlaced;
        }

    }
}
