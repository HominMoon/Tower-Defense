using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{

    [SerializeField] int maxHitPoints = 5;
    int currentHitPoints = 0;

    [Tooltip("to increase Enemy Health")]
    [SerializeField] int difficultyRamp = 1;

    Enemy enemy;

    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }

    private void Start() {
        enemy = GetComponent<Enemy>();
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    void ProcessHit()
    {
        currentHitPoints--;

        if (currentHitPoints <= 0)
        {
            gameObject.SetActive(false);
            maxHitPoints += difficultyRamp;
            enemy.ReawrdGold();
        }
    }
}
