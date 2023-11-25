using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    // Les valeurs sont choisies de manière arbitraire pour l'instant
    [SerializeField] public float speed = 8f;
    [SerializeField] public float jumpForce = 5f;
    [SerializeField] public float maxHeigt;
    [SerializeField] private bool canJump;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = new Quaternion(0f,0f,0f,0f);
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            jump();
        }
        if(rb.position.y > maxHeigt)
        {
            stopJump();
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (!col.gameObject.CompareTag("Plateform")) return;
        canJump = true;
        maxHeigt = rb.position.y + 3f;
    }

    void jump()
    {
        if(canJump)
        {
            rb.AddForce(Vector3.up * jumpForce);
        }
        else
        {
            stopJump();
        }
    }

    void stopJump()
    {
        if(canJump == false)
        {}
        else
        {
            canJump = false;
            rb.velocity = Vector3.zero;
        }
    }
}
