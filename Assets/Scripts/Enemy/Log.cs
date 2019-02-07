using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : Enemy
{
    
   
    public Transform homePosition;
    Rigidbody2D myRigidbody;
    Animator anim;


    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        myRigidbody = GetComponent<Rigidbody2D>();
        currentState = enemyState.Idle;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckDistance(transform.position, target.position, myRigidbody,false, anim, "WakeUp" );
    }

    public override void CheckDistance(Vector3 currentPos, Vector2 targetPos, Rigidbody2D rb, bool isPatroller, Animator anim, string animationState )
    {
        base.CheckDistance(transform.position, target.position, myRigidbody, false, anim, "WakeUp");
    }

   public override void ChangeState(enemyState newState)
    {
        base.ChangeState(newState);
    }

   public override void ChangeAnim(Vector2 direction)
    {
        if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if(direction.x > 0 )
            {
                SetAnimFloat(Vector2.right);
            }
            else if(direction.x < 0)
            {
                SetAnimFloat(Vector2.left);
            }
        }
        else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            if (direction.y > 0)
            {
                SetAnimFloat(Vector2.up);
            }
            else if (direction.y < 0)
            {
                SetAnimFloat(Vector2.down);
            }
        }
    }

    void SetAnimFloat(Vector2 setVector)
    {
        anim.SetFloat("MoveX", setVector.x);
        anim.SetFloat("MoveY", setVector.y);
    }
}
