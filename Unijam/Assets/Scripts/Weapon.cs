using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] public bool canAttract = true;
    [SerializeField] public float range = 3f;
    [SerializeField] public int rotat = 0;
    private void Start()
    {
        rotat = 0;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) && rotat<2)
        {
            rotat += 1;
            changerotation(rotat);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && rotat > -2)
        {
            rotat -= 1;
            changerotation(rotat);
        }
    }
    private void changerotation(int n)
    {
        if (n == -2)
        {
            transform.rotation = new Quaternion(0, 0, -0.7071068f, 0.7071068f);
        }
        if (n == -1)
        {
            transform.rotation = new Quaternion(0, 0, -0.3826834f, 0.9238796f);
        }
        if (n == 0)
        {
            transform.rotation = new Quaternion(0, 0, 0, 1);
        }
        if (n == 1)
        {
            transform.rotation = new Quaternion(0, 0, 0.3826834f, 0.9238796f);
        }
        if (n == 2)
        {
            transform.rotation = new Quaternion(0, 0, 0.7071068f, 0.7071068f);
        }
    }
}
