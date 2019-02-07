using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorType { Key, Enemy, Button}

public class Door : Interactable
{
    [Header("Door Variables")]
    public DoorType doorType;
    public bool open;
    public Inventory playerInventory;
    public SpriteRenderer doorSprite;
    public BoxCollider2D doorCollider;

   public void Open()
    {
        doorSprite.enabled = false;
        doorCollider.enabled = false;
        open = true;
    }

    public void Close()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (playerInRange && doorType ==DoorType.Key)
            {
                if(playerInventory.numberOfKeys >= 0)
                {
                    playerInventory.numberOfKeys -= 1;
                    Open();
                }
               
               
            }
        }
    }
}
