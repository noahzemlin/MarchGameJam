using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public int maxHealth;
    public int health;
    public float invulnTime = 0.3f;
    public float lastHit = 0;

    public delegate void HealthChanged(int newHealth);
    public event HealthChanged OnHealthChanged;

    private void Start()
    {
        health = maxHealth;
    }

    public void Damage(int damage)
    {
        if (Time.time - lastHit > invulnTime)
        {
            health -= damage;
            OnHealthChanged(health);
            lastHit = Time.time;
        }
    }
}
