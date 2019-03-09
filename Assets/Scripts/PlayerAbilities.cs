using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerAbilities : MonoBehaviour
{

    public GameObject bulletPrefab;
    public float bulletSpeed = 30f;
 
    private Rigidbody2D body;
    private PlayerMovement playerMovement;

    private int lastDirection = 1;
    

    private bool wActiavted = false;

    private void Start()
    {
        body = this.GetComponent<Rigidbody2D>();
        playerMovement = this.GetComponent<PlayerMovement>();
    }


    private void Update()
    {
        if (GlobalManager.paused)
            return;
        if (Input.GetKeyDown(KeyCode.W) && playerMovement.onGround)
        {
            wActiavted = true;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            int direction = lastDirection;
            if (Mathf.Abs(body.velocity.x) > 0.5)
            {
                direction = (int)Mathf.Sign(body.velocity.x);
                lastDirection = direction;
            }
            Vector3 bulletPos = new Vector3(body.position.x + direction, body.position.y,1);
            BulletScript bullet = Instantiate(bulletPrefab, bulletPos, Quaternion.identity).GetComponent<BulletScript>();
            bullet.vel = new Vector2(direction * bulletSpeed, 0);
            bullet.parent = this.gameObject;
            bullet.damage = 10;
        }
    }

    private void FixedUpdate()
    {
        if (GlobalManager.paused)
            return;
        if (wActiavted)
        {
            body.AddForce(Vector2.up * playerMovement.jumpAcceleration * 2f);
            wActiavted = false;
        }
    }
}
