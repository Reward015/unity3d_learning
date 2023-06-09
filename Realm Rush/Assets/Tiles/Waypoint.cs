using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] bool isPlaceble;
    public bool IsPlaceble { get { return isPlaceble; } }


    void OnMouseDown() 
    {
        if(isPlaceble)
        {
            bool isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position);
            
            isPlaceble = !isPlaced;
        }
    }
}
