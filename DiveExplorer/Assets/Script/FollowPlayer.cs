using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    [SerializeField] private GameObject Player;
    [SerializeField] private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //void LateUpdate()
    //{
    //    Vector3 camPos = new Vector3(Player.transform.position.x, Player.transform.position.y, transform.position.z);
    //    transform.position = camPos;
    //}
    private void Update()
    {
        if (Player.transform.position.y >= 5)
        {
            cam.orthographicSize = Player.transform.position.y + 1.5f;
            Debug.Log("ouii");
        }
        if (Player.transform.position.y < 5 && cam.orthographicSize != 5)
        {
            cam.orthographicSize = 6.6f;
            Debug.Log("ouii");
        }



    }
}
