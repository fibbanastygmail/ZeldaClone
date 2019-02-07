using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RoomMove : MonoBehaviour
{
    
    public Vector2 cameraChange;
    public Vector3 playerChange;
    CameraMovement cam;
    public Text placeText;
    public bool needText;
    public string placeName;
   

   

    private void Start()
    {
        cam = Camera.main.GetComponent<CameraMovement>();
       
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            
            cam.minPos += cameraChange;
            cam.maxPos += cameraChange;
           collision.transform.position += playerChange;

            if(needText)
            {
                StartCoroutine(PlaceNameCo());
            }

            
        }


    }

    IEnumerator PlaceNameCo()
    {
        placeText.gameObject.SetActive(true);
        placeText.text = placeName;
        yield return new WaitForSeconds(4f);
        placeText.gameObject.SetActive(false);
    }

  
}
