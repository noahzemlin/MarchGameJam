using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionDisplay : MonoBehaviour
{

    public Image[] images;
    public Sprite emptyBall;
    public Sprite[] balls;
    
    void OnEnable()
    {
        GlobalManager.OnBallChange += OnBallChange;
    }
    
    
    void OnDisable()
    {
        GlobalManager.OnBallChange -= OnBallChange;
    }

    void OnBallChange()
    {
        bool[] starStatus = GlobalManager.GetBallsStatus();

        for (int ball = 1; ball <= 7; ball++)
        {
            if (starStatus[ball - 1])
            {
                images[ball - 1].sprite = balls[ball - 1];
            }
            else
            {
                images[ball - 1].sprite = emptyBall;
            }
        }
    }
}
