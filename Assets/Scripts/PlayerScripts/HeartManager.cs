using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HeartManager : MonoBehaviour
{
    public Image[] hearts;
    public Sprite fullHeart, halfFullHeart, emptyHeart;
    public FloatValue heartContainers;
    public FloatValue playerCurrentHealth;

    // Use this for initialization
    void Start()
    {
        InitHearts();
    }

    public void InitHearts()
    {
        for (int i = 0; i < heartContainers.initialValue; i++)
        {
            hearts[i].gameObject.SetActive(true);
            hearts[i].sprite = fullHeart;
        }
    }

    public void UpdateHearts()
    {
        float tmpHealth = playerCurrentHealth.runtimeValue / 2;

        for (int i = 0; i < heartContainers.initialValue; i++)
        {
            if(i <= tmpHealth - 1)
            {
                //full heart
                hearts[i].sprite = fullHeart;
            }
            else if( i >= tmpHealth)
            {
                // emptyHeart
                hearts[i].sprite = emptyHeart;
            }
            else
            {
                hearts[i].sprite = halfFullHeart;
            }

        }
    }
    
}
