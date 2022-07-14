using System;
using UnityEngine;
using UnityEngine.UI;

public class chest : MonoBehaviour
{
    public bool isInRange;
    private Text interactUI;
    public Animator animator;
    public AudioClip soundOpenChest;
    public int coinsInChest;

    private void Awake()
    {
        interactUI = GameObject.FindGameObjectWithTag("interractUI").GetComponent<Text>();
    }
    private void Update()
    {
        if (isInRange && (Input.GetKeyDown(KeyCode.E)))
        {
            openChest();
        }
    }

    public void openChest()
    {
        interactUI.enabled = false;
        animator.SetTrigger("OpenChest");
        AudioManager.instance.PlayClipAt(soundOpenChest, transform.position);
        Inventory.instance.AddCoins(coinsInChest);
        GetComponent<BoxCollider2D>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            isInRange = true;
            interactUI.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") )
        {
            isInRange = false;
            interactUI.enabled = false;
        }
    }

    
}
