using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum enemyState { Idle, Walk, Attack, Stagger}

public class Enemy : MonoBehaviour
{
    float health;
    public FloatValue maxHealth;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;
    public enemyState currentState;
    public float chaseRadius;
    public float attackRadius;
    public Transform target;
    [Header("For Patrollers only")]
    public Transform[] patrolPoints;
    public int currentPoint;
    public Transform currentGoal;
    float roundingDistance = .1f;



    private void Awake()
    {
        health = maxHealth.initialValue;
      
    }

    IEnumerator KnockCo(Rigidbody2D myRigidbody, float knockTime)
    {
        if (myRigidbody != null )
        {

            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = enemyState.Idle;
            myRigidbody.velocity = Vector2.zero;

        }
    }

    public void Knock(Rigidbody2D myRigidbody, float knockTime, float damage)
    {
        StartCoroutine(KnockCo(myRigidbody, knockTime));
        TakeDamage(damage);
    }

    void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public virtual void CheckDistance(Vector3 currentPos, Vector2 targetPos, Rigidbody2D myRigidBody, bool isPatroller, Animator anim = null, string currentAnimationState = null )
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius
            && Vector3.Distance(target.position, transform.position) >= attackRadius)
        {
            if (currentState == enemyState.Idle || currentState == enemyState.Walk && currentState != enemyState.Stagger)
            {
                Vector3 tmp = Vector3.MoveTowards(currentPos, targetPos, moveSpeed * Time.deltaTime);
                ChangeAnim(tmp - currentPos);
                myRigidBody.MovePosition(tmp);

                ChangeState(enemyState.Walk);
                if(currentAnimationState != null)
                anim.SetBool(currentAnimationState, true);
            }


        }
        else if (Vector3.Distance(target.position, currentPos) > chaseRadius)
        {
           
            if(currentAnimationState != null)
            anim.SetBool(currentAnimationState, false);

            if (isPatroller)
            {
                
                if (Vector3.Distance(currentPos, patrolPoints[currentPoint].position) > roundingDistance)
                {
                    Vector3 tmp = Vector3.MoveTowards(currentPos, patrolPoints[currentPoint].position, moveSpeed * Time.deltaTime);
                    myRigidBody.MovePosition(tmp);
                }
                else
                {
                   
                    ChangeGoal();
                }
                

            }
        }
    }

   public virtual void ChangeState(enemyState newState)
    {
        if (currentState != newState)
        {
            currentState = newState;
        }
    }

    public virtual void ChangeAnim(Vector2 direction)
    {

    }

    public void ChangeGoal()
    {
        if(currentPoint == patrolPoints.Length - 1)
        {
            currentPoint = 0;
            currentGoal = patrolPoints[0];
        }
        else
        {
            currentPoint++;
            currentGoal = patrolPoints[currentPoint];
        }
    }
}
