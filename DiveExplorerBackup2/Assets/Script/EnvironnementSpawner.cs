using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironnementSpawner : MonoBehaviour
{
    [Range(1f, 10f)] public float timeBtwSpawn;
    [Range(1f, 10f)] public float timeBtwSpawnGround;

    public static float EnvironnementSpeed;

    [SerializeField] private Vector3 SpawnPos;

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(SpawnRockCo());
        StartCoroutine(SpawnSolidRockCo());
        StartCoroutine(SpawnGroundCo());
        StartCoroutine(SpawnZipLineCo());
        EnvironnementSpeed = 5;
    }

    private void Update()
    {
        EnvironnementSpeed += Time.deltaTime / 10;
        timeBtwSpawn -= Time.deltaTime / 100;
    }
    public IEnumerator SpawnZipLineCo()
    {
        SpawnPos.x = 30;
        GameObject go = Pool.instance.GetPooledZip();
        if (go != null)
        {
            go.transform.position = SpawnPos;
            go.SetActive(true);
        }
        yield return new WaitForSeconds(timeBtwSpawn + Random.Range(3, 7));
        StartCoroutine(SpawnZipLineCo());
    }
    public IEnumerator SpawnRockCo()
    {
        SpawnPos.y = Random.Range(-7, -4);
        SpawnPos.x = 30;
        GameObject go = Pool.instance.GetPooledRocks();
        if (go != null)
        {
            go.transform.position = SpawnPos;
            go.SetActive(true);
        }
        yield return new WaitForSeconds(timeBtwSpawn + Random.Range(1, 2));
        StartCoroutine(SpawnRockCo());
    }
    public IEnumerator SpawnSolidRockCo()
    {
        yield return new WaitForSeconds(timeBtwSpawn + Random.Range(4, 5));
        SpawnPos.y = Random.Range(-5, -3.5f);
        SpawnPos.x = 30;
        GameObject go = Pool.instance.GetPooledSolidRocks();
        if (go != null)
        {
            go.transform.position = SpawnPos;
            go.SetActive(true);
        }
        StartCoroutine(SpawnSolidRockCo());

    }

    float GetTimeSpwnGround()
    {
        int rand = Random.Range(0, 4);
        if (rand == 0)
            return 4f;
        else
            return 0f;
    }

    public IEnumerator SpawnGroundCo()
    {
        float additionalTime = GetTimeSpwnGround();
        yield return new WaitForSeconds(timeBtwSpawnGround + additionalTime);
        SpawnPos.y = -6;
        SpawnPos.x = 30;
        GameObject go = Pool.instance.GetPooledGround();
        if (go != null)
        {
            go.transform.position = SpawnPos;
            go.SetActive(true);
        }
        StartCoroutine(SpawnGroundCo());

    }
}


