using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController characherCon;
    public float speed = 5;
    public float smooth = 5;

    private void Start()
    {
        characherCon = gameObject.GetComponent<CharacterController>();
    }

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.Rotate(Vector3.up, h * smooth);
        characherCon.SimpleMove(transform.forward * v * speed);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            speed = 10;
        }
        if (Input.GetKeyUp(KeyCode.Space)) 
        {
            speed = 5;
        }
    }
}
