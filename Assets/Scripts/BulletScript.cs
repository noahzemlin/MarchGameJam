using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public Vector2 vel;
    public GameObject parent;
    public int damage;
    public float lifeTime = 0.5f;

    private Rigidbody2D body;
    private float timeCreated;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        timeCreated = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        body.velocity = vel;

        if (Time.time - timeCreated > lifeTime)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health health = collision.GetComponent<Health>();
        if (health && collision.gameObject != parent)
        {
            health.Damage(damage);
            Destroy(this.gameObject);
        }
    }
}
