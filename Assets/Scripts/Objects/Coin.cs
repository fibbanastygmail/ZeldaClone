using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Collectables
{
    public Inventory playerInventory;

    // Use this for initialization
    void Start()
    {
        collectableSignal.Raise();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.isTrigger)
        {
            playerInventory.coins++;
            collectableSignal.Raise();
            Destroy(gameObject);
        }
    }
}
