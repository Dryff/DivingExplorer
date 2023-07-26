using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    [SerializeField] private GameObject Player;
    public float offsetX = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 camPos = new Vector3(Player.transform.position.x + offsetX, transform.position.y, transform.position.z);
        transform.position = camPos;
    }
}
