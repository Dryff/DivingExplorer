using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnvironnementSpawner : MonoBehaviour
{
    [Range(1f, 10f)] public float timeBtwSpawn;
    [Range(1f, 10f)] public float timeBtwSpawnGround;

    public static float EnvironnementSpeed;

    public float timerDistance = 0;
    public Text DistanceText;
    [SerializeField] private float limit;
    [SerializeField] private float CampfireThreshold;
    public GameObject campfireGo;

    [SerializeField] private Vector3 SpawnPos;

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(SpawnRockCo());
        //StartCoroutine(SpawnSolidRockCo());
        StartCoroutine(SpawnGroundCo());
        StartCoroutine(SpawnZipLineCo());
        EnvironnementSpeed = 5;
        limit = 0.1f;
    }

    private void Update()
    {
        if (!GameManager.instance.pause)
        {
            DistanceCalculation();
            EnvAcceleration();
        }
    }
    private void DistanceCalculation()
    {
        timerDistance += Time.deltaTime * EnvironnementSpeed;
        if (timerDistance > limit * 100)
        {
            float rounded = Mathf.Round(limit * 10) / 10;
            DistanceText.text = rounded.ToString() + " Km";
            limit += 0.1f;
            Debug.Log(limit + " - " + CampfireThreshold);
            if (limit >= CampfireThreshold) 
            {
                Debug.Log("Spawn");
                SpawnFireCamp();
                CampfireThreshold += 1;
            }
        }
    }
    private void EnvAcceleration()
    {
        EnvironnementSpeed += Time.deltaTime / 10;
        timeBtwSpawn -= Time.deltaTime / 100;
    }
    private void SpawnFireCamp()
    {
        SpawnPos.x = 30;
        SpawnPos.y = -3f;
        campfireGo.SetActive(true);
        campfireGo.transform.position = SpawnPos;
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
    //public IEnumerator SpawnSolidRockCo()
    //{
    //    yield return new WaitForSeconds(timeBtwSpawn + Random.Range(4, 5));
    //    SpawnPos.y = Random.Range(-5, -3.5f);
    //    SpawnPos.x = 30;
    //    GameObject go = Pool.instance.GetPooledSolidRocks();
    //    if (go != null)
    //    {
    //        go.transform.position = SpawnPos;
    //        go.SetActive(true);
    //    }
    //    StartCoroutine(SpawnSolidRockCo());

    //}

    float GetTimeSpwnGround()
    {
        return (Random.Range(0, 4) == 4 ? 4 : 0);
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


