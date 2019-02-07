using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : Interactable
{
   
    
    public string dialog;
    public Image dialogBox;
    public Text dialogText;
   


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if (dialogBox.gameObject.activeInHierarchy)
            {
                dialogBox.gameObject.SetActive(false);
            }
            else
            {
                dialogBox.gameObject.SetActive(true);
                dialogText.text = dialog;
            }
        }
    }

    public override void OnTriggerExit2D(Collider2D collision)
    {
        base.OnTriggerExit2D(collision);
        dialogBox.gameObject.SetActive(false);
    }


}
