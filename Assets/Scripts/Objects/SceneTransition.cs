using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [Header("New scene variables")]
    public string sceneToLoad;
    public Vector2 playerPosition;
    public VectorValue playerStorage;
    [Header("Transition variables")]
    public Vector2 cameraNewmax;
    public Vector2 cameraNewMin;
    public VectorValue cameraMin;
    public VectorValue cameraMax;
    public GameObject fadeInPanel;
    public GameObject fadeOutPanel;
    
    public float fadeWait;


    private void Awake()
    {
        if(fadeInPanel!= null)
        {
            GameObject fadePanel = Instantiate(fadeInPanel);
            Destroy(fadePanel, 1f);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !collision.isTrigger)
        {
            playerStorage.initialValue = playerPosition;
            StartCoroutine(FadeCo());
        }
    }

    public IEnumerator FadeCo()
    {
        if(fadeOutPanel != null)
        {
             Instantiate(fadeOutPanel);

        }
        // yield return new WaitForSeconds(fadeWait);
        ResetCameraBounds();
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneToLoad);
        while(!asyncOperation.isDone)
        {
            yield return null;
        }


    }

    public void ResetCameraBounds()
    {
        cameraMax.initialValue = cameraNewmax;
        cameraMin.initialValue = cameraNewMin;
    }
   
}
