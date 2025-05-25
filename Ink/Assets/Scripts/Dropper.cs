using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    public GameObject dropperEffect;
    public AudioClip pickSound;

    SceneFlowManager sceneFlowManager;
    private void Start()
    {

        sceneFlowManager = FindObjectOfType<SceneFlowManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            sceneFlowManager.currentDropperCount++;
            Instantiate(dropperEffect, transform.position, transform.rotation);
            AudioSource.PlayClipAtPoint(pickSound, transform.position);

            Destroy(gameObject);

        }
    }

}
