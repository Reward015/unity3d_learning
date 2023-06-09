using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int cost = 75;

    public bool CreateTower(Tower tower, Vector3 positoin)
    {
        Bank bank = FindObjectOfType<Bank>();

        if(bank == null)
        {
            return false;
        }

        if(bank.CurrentBalance >= cost)
        {
            Instantiate(tower, positoin, Quaternion.identity);
            bank.Withdraw(cost);
            return true;
        }

        return false;
        
    }
}
