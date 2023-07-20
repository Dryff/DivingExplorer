using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 5f;
    public float timeBeforeRotate = 1f;
    public float rotationSpeed = 5f;
    public bool isOnTop;

    public SpriteRenderer sp;
    public Sprite rotateSprite;
    public Sprite swimSprite;
    private Sprite baseSprite;
    private Rigidbody2D rb;
    private string state;
    public bool canRotate = false;
    public float counter = 0;

    void Start()
    {
        baseSprite = sp.sprite;
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        RocksAndGround(collision);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Water"))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            sp.sprite = swimSprite;
            state = "Water";
        }
    }

    private bool FromBelow(Collision2D collision)
    {
        Vector3 contactNormal = collision.GetContact(0).normal;
        isOnTop = Vector3.Dot(contactNormal, Vector3.up) > 0.5f;
        if (!isOnTop)
            return false;
        return true;
    }

    private void RocksAndGround(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("SolidRocks"))
            ReloadScene();
        if (!FromBelow(collision))
            return;
        if (collision.collider.gameObject.CompareTag("Ground"))
        {
            Debug.Log("salut");
            if (transform.rotation.z >= -0.5 && transform.rotation.z <= 0.5)
                transform.rotation = Quaternion.Euler(0, 0, 0);
            else ReloadScene();
            state = "Ground";
        }
    }

    void Update()
    {
        if (state == "Ground" || state == "Water")
        {
            if (canRotate)
            {
                canRotate = false;
                counter = 0;
                if (state == "Ground")
                    sp.sprite = baseSprite;
                else if (state == "Water")
                    sp.sprite = swimSprite;
            }
            if (Input.GetKeyDown(KeyCode.Space))
                Jump(jumpForce);
        }
        CheckRotate();
        if (state == "Air")
        {
            if (Input.GetKey(KeyCode.Space) && canRotate)
            {
                //Debug.Log("rotate");
                sp.sprite = rotateSprite;
                BackFlip();
            }
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene("Play");
    }

    private void Jump(float jumpF)
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpF);
        state = "Air";
    }

    private void CheckRotate()
    {
        counter += Time.deltaTime;
        if (canRotate == false && counter > timeBeforeRotate)
            canRotate = true;
    }

    private void BackFlip()
    {
        // Appliquer la rotation aux axes x et y
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime * 50);
    }

    private void Twist()
    {
        // Appliquer la rotation aux axes x et y
        transform.Rotate(0, rotationSpeed, 0);
    }
}