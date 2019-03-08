using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class HealthBar : MonoBehaviour
{

    private Health health;
    public GameObject healthBarPrefab;
    private RectTransform frontBar;

    private void OnHealthChange(int newHealth)
    {
        frontBar.localScale = new Vector3((float)health.health/health.maxHealth, 1, 1);
        frontBar.localPosition = new Vector3(-0.5f * (1-(float)health.health / health.maxHealth), 0, 0);
    }

    private void OnEnable()
    {
        health = GetComponent<Health>();
        health.OnHealthChanged += OnHealthChange;
        GameObject obj = Instantiate(healthBarPrefab, this.transform);
        frontBar = obj.transform.Find("HealthFront").GetComponent<RectTransform>();
    }

    private void OnDisable()
    {
        health.OnHealthChanged -= OnHealthChange;
    }
}
