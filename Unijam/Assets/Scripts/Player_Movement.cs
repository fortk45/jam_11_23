using System;
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
        canJump = true;
        maxHeigt = 1f;
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
        if((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && canJump)
        {
            jump();
        }
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
        {
            canJump = false;
        }
        if (rb.position.y >= maxHeigt)
        {
            stopJump();
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (!col.gameObject.CompareTag("Plateform")) return;
        canJump = true;
        maxHeigt = rb.position.y + 1f;
    }

    void jump()
    {
        if (canJump)
        {
            Vector3 jumpVector = Vector3.up * jumpForce * 0.1f;
            rb.AddForce(jumpVector, ForceMode.Impulse);
        }
    }

    void stopJump()
    {
        canJump = false;
        Vector3 jumpVector = Vector3.down * jumpForce * 0.05f;
        rb.AddForce(jumpVector, ForceMode.Impulse);
    }
}
 