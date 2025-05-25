using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    SceneFlowManager sceneFlowManager;
    public GameObject warningText;
    private void Start()
    {
        sceneFlowManager = FindObjectOfType<SceneFlowManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (sceneFlowManager.AllItemsCollected())
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                StartCoroutine(DisplayWarning());
            }

        }   
    }

    IEnumerator DisplayWarning()
    {
        warningText.SetActive(true);
        yield return new WaitForSeconds(2f);
        warningText.SetActive(false);
    }

}
