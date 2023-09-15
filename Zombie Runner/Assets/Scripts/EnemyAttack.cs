using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField] float damage = 40f;

    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }

    public void AttackHitEvnet()
    {
        if (target == null) return;
        target.TakeDamage(damage);
        Debug.Log ("bang bang");

    }
   
}
