using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Health))]
public class PlayerWinAndLose : MonoBehaviour
{
    private Health health;

    private void resetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnHealthChange(int newHealth)
    {
        if (newHealth == 0)
        {
            resetLevel();
        }
    }

    private void OnDragonballCollect()
    {
        if (GlobalManager.GetBallsCollected() == 7)
        {
            //TODO: Call Shenron on win!
            resetLevel();
        }
    }

    private void OnEnable()
    {
        health = GetComponent<Health>();
        health.OnHealthChanged += OnHealthChange;
        GlobalManager.OnBallChange += OnDragonballCollect;
    }

    private void OnDisable()
    {
        health.OnHealthChanged -= OnHealthChange;
        GlobalManager.OnBallChange -= OnDragonballCollect;
    }
}
