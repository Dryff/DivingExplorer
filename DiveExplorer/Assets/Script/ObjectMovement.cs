using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.pause)
        {
            transform.Translate(-EnvironnementSpawner.EnvironnementSpeed * Time.deltaTime, 0, 0);
            if (gameObject.transform.position.x < -30)
                gameObject.SetActive(false);
        }
    }
}
