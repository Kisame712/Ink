using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spike : MonoBehaviour
{
    public AudioClip deathSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            StartCoroutine(PlayDeathSound());
        }
    }

    IEnumerator PlayDeathSound()
    {
        AudioSource.PlayClipAtPoint(deathSound, transform.position);
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
