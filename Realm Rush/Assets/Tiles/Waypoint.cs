using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] GameObject towerPrefab;
    [SerializeField] bool isPlaceble;
    void OnMouseDown() {
        if(isPlaceble)
        {
            Instantiate(towerPrefab, transform.position, Quaternion.identity);
            isPlaceble = false;
        }
    }
}
