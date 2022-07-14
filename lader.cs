using UnityEngine;
using UnityEngine.UI;

public class lader : MonoBehaviour
{
    public bool isInRange;
    private PlayerMovement playerMovement;
    public BoxCollider2D plateforme;
    public Text UIDescendre;
    private void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent < PlayerMovement>();
        UIDescendre = GameObject.FindGameObjectWithTag("UILader").GetComponent<Text>();
    }

    private void Update()
    {
        if (!playerMovement.isClimbing)
        {
            UIDescendre.enabled = false;
        }
        
        if (isInRange && playerMovement.isClimbing && Input.GetButtonDown("Jump"))
        {
            playerMovement.isClimbing = false;
            plateforme.isTrigger = false;
            return;
        }
        if (( Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)) && isInRange)
        {
            playerMovement.isClimbing = true;
            plateforme.isTrigger = true;
            UIDescendre.enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isInRange = false;
        playerMovement.isClimbing = false;
        plateforme.isTrigger = false;
    }
}
