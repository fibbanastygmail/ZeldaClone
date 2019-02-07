using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : Collectables
{
    public FloatValue playerHealth;
    public FloatValue heartContainers;
    public float amountToIncrease;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && collision.isTrigger)
        {
            playerHealth.runtimeValue += amountToIncrease;
            if(playerHealth.runtimeValue > heartContainers.runtimeValue * 2)
            {
                playerHealth.runtimeValue = heartContainers.runtimeValue * 2;
            }
            collectableSignal.Raise();
            Destroy(gameObject);
        }
    }
}
