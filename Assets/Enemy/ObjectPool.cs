using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObkectPool : MonoBehaviour
{
    [SerializeField] GameObject RamPrefab;
    float RamCount=0f;
    [SerializeField] [Range(0.1f,30f)] float RamTimer = 1f;
    [SerializeField] [Range(0,50)] int poolSize = 5;
    GameObject[] pool;

    void Awake()
    {
        populatePool();
    }

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    void populatePool()
    {
        pool = new GameObject[poolSize];

        for(int i = 0; i < poolSize; i++)
        {
            pool[i] = Instantiate(RamPrefab, transform);
            pool[i].SetActive(false);
        }
    }

    void EnableObjectInPool()
    {
        for(int i = 0; i < pool.Length; i++)
        {
            if(!pool[i].activeSelf)
            {
                pool[i].SetActive(true);
                return;
            }  
        }
    }

    IEnumerator SpawnEnemy()
    {
        while(true)
        {
        EnableObjectInPool();
        yield return new WaitForSeconds(RamTimer);
        }
    }
}
