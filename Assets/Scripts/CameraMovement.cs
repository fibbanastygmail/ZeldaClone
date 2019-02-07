using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Header("Position Variables")]
    public Transform target;
    public float smoothing = .1f;
    public Vector2 minPos, maxPos;

    [Header("Position reset")]
    public VectorValue camMin;
    public VectorValue camMax;

   
    
    // Use this for initialization
    void Start()
    {
        transform.position = new Vector3(target.position.x,target.position.y,transform.position.z);
        maxPos = camMax.initialValue;
        minPos = camMin.initialValue;
    }

    // Update is called once per frame
    void LateUpdate()
    {
       
        if (transform.position != target.position)
        {
           
            Vector3 targetPos = new Vector3(target.position.x, target.position.y, transform.position.z);
            targetPos.x = Mathf.Clamp(targetPos.x, minPos.x, maxPos.x);
            targetPos.y = Mathf.Clamp(targetPos.y, minPos.y, maxPos.y);

            transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
        }
    }
}
