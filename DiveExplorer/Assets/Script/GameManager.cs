using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public PlayerJump playerJump;
    public bool pause;

    // Use this for initialization
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

}