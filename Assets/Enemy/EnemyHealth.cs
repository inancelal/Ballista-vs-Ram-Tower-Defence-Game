using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [Tooltip("Health of rams")]
    [SerializeField] float health;
    int maxHealth = 5;
    // [SerializeField] [Range(1,5)] float diffuculty = 1;
    Enemy enemy;

    void OnEnable()
    {
        health = maxHealth;
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();        
    }

    void OnParticleCollision(GameObject other) 
    {
        DamageProcess();
    }

    void DamageProcess()
    {
        health--;
        if(health <= 0)
        {
            maxHealth++;
            gameObject.SetActive(false);
            enemy.RewardGold(); 
        }
    }
}
