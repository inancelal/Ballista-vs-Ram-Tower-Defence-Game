using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFeatures : MonoBehaviour
{
    [SerializeField] ParticleSystem ProjectileParticle;
    [SerializeField] float range = 15f;
    Transform targets;
    [SerializeField] Transform weapon;

    void Update()
    {
        FindClosestTarget();
        aimWeapon();
    }

    void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>(); 
        float maxDistance = Mathf.Infinity;
        Transform ClosestEnemy = null;

        foreach (Enemy enemy in enemies)
        {
            float TargetDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if(TargetDistance < maxDistance)
            {
                ClosestEnemy = enemy.transform;
                maxDistance = TargetDistance;
            }
        }
        targets = ClosestEnemy;
    }

    void aimWeapon()
    {
        float DistanceOfTarget = Vector3.Distance(transform.position, targets.transform.position);
        weapon.LookAt(targets); 
        if(DistanceOfTarget <= range)
        {
            Attack(true);
        }
        else if(DistanceOfTarget > range)
        {
            Attack(false);
        }
    }

    void Attack(bool isActive)
    {
            var emissionModule = ProjectileParticle.emission;
            emissionModule.enabled = isActive;
    }
}