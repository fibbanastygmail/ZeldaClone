using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{

    public float thrust;
  //  Rigidbody2D player;
    public float knockTime;
    public float damage;
   

    // Use this for initialization
    void Start()
    {
      //  player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Breakable") && gameObject.CompareTag("Player"))
        {
            collision.GetComponent<Pot>().Smash();

        }

        if (collision.CompareTag("Enemy") || collision.CompareTag("Player"))
        {
            Rigidbody2D hit = collision.GetComponent<Rigidbody2D>();
           
            if(hit != null)
            {
                Vector2 difference = (hit.transform.position - transform.position);
                difference = difference.normalized * thrust;
                hit.AddForce(difference, ForceMode2D.Impulse);

                if (collision.CompareTag("Enemy") && collision.isTrigger)
                {
                    hit.GetComponent<Enemy>().currentState = enemyState.Stagger;
                    collision.GetComponent<Enemy>().Knock(hit, knockTime, damage);
                }

                if(collision.CompareTag("Player"))
                {
                    if(collision.GetComponent<PlayerMovement>().currentState != PlayerState.Stagger)
                    {
                        hit.GetComponent<PlayerMovement>().currentState = PlayerState.Stagger;
                        collision.GetComponent<PlayerMovement>().Knock(knockTime, damage);
                    }
                    
                }
               
                
               
               
                

            }
        }


    }

    
}
