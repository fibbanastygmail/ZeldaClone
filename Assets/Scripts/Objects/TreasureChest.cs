using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureChest : Interactable
{
    public Item content;
    public bool isOpen;
    public Signal raiseItem;
    public GameObject dialogBox;
    public Text dialogText;
    public Inventory playerInventory;
    public BooleanValue storedOpen;
   
    Animator anim;



    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        isOpen = storedOpen.runTimeValue;

        if (isOpen)
            anim.SetBool("IsOpen", true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if (!isOpen)
            {
                OpenChest();
            }
            else 
            {
                DeactivateFunctions();
            }
        }
    }

    public void OpenChest()
    {
        anim.SetBool("IsOpen", true);
        playerInventory.currentItem = content;
        dialogBox.SetActive(true);
        dialogText.text = content.itemDescription;
       
        raiseItem.Raise();
        
        context.Raise();
        playerInventory.AddItem(content);
        isOpen = true;
        storedOpen.runTimeValue = isOpen;
       
    }

    public void DeactivateFunctions()
    {
        
        
            dialogBox.SetActive(false);
           // playerInventory.currentItem.itemSprite = null;
            raiseItem.Raise();
          

    }

    public override void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger && !isOpen)
        {
            playerInRange = false;

            context.Raise();
        }
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger && !isOpen)
        {
            playerInRange = true;
            context.Raise();
        }
    }


}
