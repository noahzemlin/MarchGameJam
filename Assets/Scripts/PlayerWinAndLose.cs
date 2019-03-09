using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Health))]
public class PlayerWinAndLose : MonoBehaviour
{
    private Health health;
    public GameObject shenron;

    private void resetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnHealthChange(int newHealth)
    {
        if (newHealth == 0)
        {
            GlobalManager.Clear();
            resetLevel();
        }
    }

    IEnumerator WaitForShenron()
    {
        GlobalManager.paused = true;
        Instantiate(shenron, this.gameObject.transform.position + Vector3.up * 40f, Quaternion.identity);
        yield return new WaitForSeconds(10);
        GlobalManager.Clear();
        GlobalManager.paused = false;
        resetLevel();
    }

     private void OnDragonballCollect()
    {
        if (GlobalManager.GetBallsCollected() == 7)
        {
            StartCoroutine(WaitForShenron());
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
