using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
    Rigidbody2D rb;
   

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        CheckDistance(transform.position, target.position, rb, true);
    }

    public override void CheckDistance(Vector3 currentPos, Vector2 targetPos, Rigidbody2D rb, bool isPatroller, Animator anim = null, string animationState = null)
    {
        base.CheckDistance(transform.position, target.position, rb, true);
    }
}
