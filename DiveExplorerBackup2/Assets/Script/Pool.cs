using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{

    public static Pool instance;

    [SerializeField] private GameObject RockPrefab;
    private List<GameObject> pooledRock = new List<GameObject>();
    private int amountToPoolRock = 5;

    [SerializeField] private GameObject SolidRockPrefab;
    private List<GameObject> pooledSolidRock = new List<GameObject>();
    private int amountToPoolSolidRock = 5;

    [SerializeField] private GameObject groundPrefab;
    private List<GameObject> pooledGround = new List<GameObject>();
    private int amountToPoolGround = 5;

    [SerializeField] private GameObject ZipPrefab;
    private List<GameObject> pooledZip = new List<GameObject>();
    private int amountToPoolZip = 5;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        for (int i = 0; i < amountToPoolRock; i++)
        {
            GameObject obj = Instantiate(RockPrefab);
            obj.SetActive(false);
            pooledRock.Add(obj);
            obj.transform.SetParent(gameObject.transform);
        }
        for (int i = 0; i < amountToPoolSolidRock; i++)
        {
            GameObject obj = Instantiate(SolidRockPrefab);
            obj.SetActive(false);
            pooledSolidRock.Add(obj);
            obj.transform.SetParent(gameObject.transform);
        }
        for(int i = 0; i < amountToPoolGround; i++)
        {
            GameObject obj = Instantiate(groundPrefab);
            obj.SetActive(false);
            pooledGround.Add(obj);
            obj.transform.SetParent(gameObject.transform);
        }
        for(int i = 0; i < amountToPoolZip; i++)
        {
            GameObject obj = Instantiate(ZipPrefab);
            obj.SetActive(false);
            pooledZip.Add(obj);
            obj.transform.SetParent(gameObject.transform);
        }
    }
    public GameObject GetPooledRocks()
    {
        for (int i = 0; i < pooledRock.Count; i++)
        {
            if (!pooledRock[i].activeInHierarchy)
                return pooledRock[i];
        }
        return null;
    }
    public GameObject GetPooledSolidRocks()
    {
        for (int i = 0; i < pooledSolidRock.Count; i++)
        {
            if (!pooledSolidRock[i].activeInHierarchy)
                return pooledSolidRock[i];
        }
        return null;
    }
    public GameObject GetPooledGround()
    {
        for (int i = 0; i < pooledGround.Count; i++)
        {
            if (!pooledGround[i].activeInHierarchy)
                return pooledGround[i];
        }
        return null;
    }
    public GameObject GetPooledZip()
    {
        for (int i = 0; i < pooledZip.Count; i++)
        {
            if (!pooledZip[i].activeInHierarchy)
                return pooledZip[i];
        }
        return null;
    }
}
