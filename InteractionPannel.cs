using System;
using UnityEngine.UI;
using UnityEngine;

public class InteractionPannel : MonoBehaviour
{
    public bool PlayerHere = false;
    public GameObject uiInterract;
    public GameObject uiPannel;
    public bool isActive = false;

    private void Awake()
    {
        uiInterract = GameObject.FindGameObjectWithTag("interractUI");

    }

    private void Update()
    {
        if (PlayerHere)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                isActive = !isActive;
                uiPannel.SetActive(isActive);
                uiInterract.GetComponent<Text>().enabled = !isActive;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            uiInterract.GetComponent<Text>().enabled =true;

            PlayerHere = true;
        }
    }
    
   

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            uiInterract.GetComponent<Text>().enabled = false;

            PlayerHere = false;
        }
    }
}
