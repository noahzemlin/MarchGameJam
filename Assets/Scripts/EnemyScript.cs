using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class EnemyScript : MonoBehaviour
{

    public float maxSpeed = 4f;
    public float acceleration = 30f;
    public float detectionRange = 20f;
    public int damage = 10;

    private Rigidbody2D body;
    private Health health;

    void OnHealthChange(int newHealth)
    {
        if (newHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        body = this.GetComponent<Rigidbody2D>();
        health = this.GetComponent<Health>();
        health.OnHealthChanged += OnHealthChange;
    }

    void FixedUpdate()
    {
        Vector2 toPlayer = (PlayerMovement.player.transform.position - this.transform.position);
        if (toPlayer.magnitude < detectionRange)
        {
            float horiz = toPlayer.normalized.x;

            body.AddForce(Vector2.right * horiz * acceleration);

            if (Mathf.Abs(body.velocity.x) > maxSpeed)
            {
                body.velocity = new Vector2(Mathf.Sign(body.velocity.x) * maxSpeed, body.velocity.y);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health health = collision.GetComponent<Health>();
        if (health && collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            health.Damage(damage);
        }
    }
}
