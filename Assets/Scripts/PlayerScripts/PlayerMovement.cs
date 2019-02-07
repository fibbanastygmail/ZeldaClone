using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState { Walk, Interact, Attack, Stagger,Idle }

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public PlayerState currentState;
    Rigidbody2D myRigidbody;
    Animator animator;
    Vector3 change;
    public FloatValue currentHealth;
    public Signal playerHealthSignal;
    public VectorValue startingPosition;
    public Inventory playerInventory;
    public SpriteRenderer receivedItemSprite;

    // Use this for initialization
    void Start()
    {
        currentState = PlayerState.Walk;
        myRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetFloat("MoveY", -1);
        transform.position = startingPosition.initialValue;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentState == PlayerState.Interact)
        {
            return;
        }
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("Fire1") && currentState != PlayerState.Attack
            && currentState != PlayerState.Stagger)
        {
            StartCoroutine(AttackCo());
        }
        else if (currentState == PlayerState.Walk || currentState == PlayerState.Idle)
        {
            UpdateAnimationAndMove();
        }

    }

    void MovePlayer()
    {

        myRigidbody.MovePosition(transform.position + change * speed * Time.deltaTime);
    }

    void UpdateAnimationAndMove()
    {


        if (change != Vector3.zero)
        {
            change.Normalize();
            MovePlayer();
            animator.SetFloat("MoveX", change.x);
            animator.SetFloat("MoveY", change.y);
            animator.SetBool("Moving", true);

        }
        else animator.SetBool("Moving", false);

    }

    void PlayerAttack()
    {

    }

    IEnumerator AttackCo()
    {
        animator.SetBool("Attacking", true);
        currentState = PlayerState.Attack;
        yield return null;



        yield return new WaitForSeconds(.33f);

        animator.SetBool("Attacking", false);
        if(currentState != PlayerState.Interact)
        {
            currentState = PlayerState.Walk;
        }
       
    }

    IEnumerator KnockCo(float knockTime)
    {
        if (myRigidbody != null)
        {

            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = PlayerState.Idle;
            myRigidbody.velocity = Vector2.zero;
        }
    }

    public void RaiseItem()
    {
        if(playerInventory.currentItem != null)
        {
            if (currentState != PlayerState.Interact)
            {
                animator.SetBool("PickingUp", true);
                currentState = PlayerState.Interact;
                receivedItemSprite.sprite = playerInventory.currentItem.itemSprite;
            }
            else
            {
                animator.SetBool("PickingUp", false);
                currentState = PlayerState.Idle;
                receivedItemSprite.sprite = null;
                playerInventory.currentItem = null;
            }
        }
       
       

    }

    public void Knock(float knockTime, float damage)
    {
        currentHealth.runtimeValue -= damage;
        playerHealthSignal.Raise();
        if (currentHealth.runtimeValue > 0)
        {
            
            StartCoroutine(KnockCo(knockTime)); 
        }
        else
        {
            gameObject.SetActive(false);
        }
       
    }

}
