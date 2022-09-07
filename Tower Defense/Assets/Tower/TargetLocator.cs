using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] float range = 15f;
    [SerializeField] ParticleSystem projectileParticle;

    Transform target; // need not serialized

    void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }


    private void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        // 중요: null 해야하는 이유, 아무것도 지정하지 않으면 아래에서 불러올 때 할당되지 않은 변수로 뜨기 때문에
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach (Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if (targetDistance < maxDistance)
            {
                maxDistance = targetDistance;
                closestTarget = enemy.transform;
            }
        }

        target = closestTarget;
    }

    private void AimWeapon()
    {
        float targetDistance = Vector3.Distance(transform.position, target.position);

        if (targetDistance <= range)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }

        weapon.LookAt(target);
    }

    void Attack(bool isActive)
    {
        //projectileParticle.gameObject.SetActive(isActive);

        var emmisionModule = projectileParticle.emission;
        emmisionModule.enabled = isActive;
    }
}
