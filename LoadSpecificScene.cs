using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSpecificScene : MonoBehaviour
{
    public String sceneName;
    private Animator fadeSystem;
    public AudioClip successSFX;
   
    private void Awake()
    {
        fadeSystem = GameObject.FindGameObjectWithTag("fadeSystem").GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            AudioManager.instance.PlayClipAt(successSFX, col.transform.position);
            StartCoroutine(loadNextScene());
        }
    }

    public IEnumerator loadNextScene()
    {
        LoadAndSaveData.instance.SaveData();
        PlayerMovement.instance.enabled = false;
        PlayerMovement.instance.rb.velocity = new Vector2(0, 0);
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(this.sceneName);
        PlayerMovement.instance.enabled = true;
    }
}
