﻿using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class DiceScript : MonoBehaviour
{
    static Rigidbody rb;
    public static Vector3 diceVelocity;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        diceVelocity = rb.velocity;

        if (Input.GetKeyDown (KeyCode.Mouse0))
        {
            DiceNumberTextScript.diceNumber = 0;
            float dirX = Random.Range(0, 500);
            float dirY = Random.Range(0, 500);
            float dirZ = Random.Range(0, 500);
            transform.position = new Vector3 (0, 2, 0);
            transform.rotation = Quaternion.identity;
            rb.AddForce (transform.up *500);
            rb.AddTorque(dirX, dirY, dirZ);

        }
    }
}
