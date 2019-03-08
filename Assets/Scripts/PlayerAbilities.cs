using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerAbilities : MonoBehaviour
{
 
    private Rigidbody2D body;
    private PlayerMovement playerMovement;

    private bool wActiavted = false;

    private void Start()
    {
        body = this.GetComponent<Rigidbody2D>();
        playerMovement = this.GetComponent<PlayerMovement>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && playerMovement.onGround)
        {
            wActiavted = true;
        }
    }

    private void FixedUpdate()
    {
        if (wActiavted)
        {
            body.AddForce(Vector2.up * playerMovement.jumpAcceleration * 2f);
            wActiavted = false;
        }
    }
}
