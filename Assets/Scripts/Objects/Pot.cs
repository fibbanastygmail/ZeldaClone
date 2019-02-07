using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Smash()
    {

        StartCoroutine(SmashCo());
    }
  

    IEnumerator SmashCo()
    {
        anim.SetBool("Smash", true);
        yield return new WaitForSeconds(.5f);
        gameObject.SetActive(false);
      //  anim.SetBool("Smash", false);
    }
}
