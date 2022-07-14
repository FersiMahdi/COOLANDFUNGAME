
using UnityEngine;
using System.Collections;
public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public SpriteRenderer spriteRenderer;
    public bool isInvincible = false;
    public float invincibilityTimeAfterHit = 3f;
    private Animator fadeSystem;
    public static PlayerHealth instance;
    public AudioClip hitSound;
    public AudioClip deathSound;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("an instance of CurrentSceneManager already exists");
            return;
        }

        instance = this;
        
        fadeSystem = GameObject.FindGameObjectWithTag("fadeSystem").GetComponent<Animator>();
    }

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            takeDamage(100);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            heal(20);
        }
    }

    public void takeDamage(int damage)
    {
        if (!isInvincible)
        {
            AudioManager.instance.PlayClipAt(hitSound, transform.position);
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);

            if (currentHealth > 0)
            { 
                isInvincible = true;
                StartCoroutine(InvicibilityFlash());
                StartCoroutine(InvicibilityTime());
            }
            else
            {
                Die();
                return;
            }
        }
    }

    public void heal(int quantity)
    {
            if ( (currentHealth + quantity ) > maxHealth)
            {
                currentHealth = maxHealth;
            }
            else
            {
                currentHealth += quantity;
            }
            healthBar.SetHealth(currentHealth);
    }

    public void Die()
    {
        PlayerPrefs.SetInt("playerHealth",PlayerHealth.instance.maxHealth);
        StartCoroutine(WaitUntilDeath());
    }

    public void Respawn()
    {
        PlayerMovement.instance.enabled = true;
        PlayerMovement.instance.animator.SetTrigger("Respawn");
        PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Dynamic;
        PlayerMovement.instance.spriteRenderer.enabled = true;
        PlayerMovement.instance.playerColider.enabled = true;
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
    }

    public IEnumerator InvicibilityFlash()
    {
        while (isInvincible)
        {
            spriteRenderer.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(0.2f);
        }
    }

    public IEnumerator WaitUntilDeath()
    {
        AudioManager.instance.StopMusic();
        AudioManager.instance.PlayClipAt(deathSound, PlayerMovement.instance.transform.position);
        PlayerMovement.instance.rb.velocity = Vector2.zero;
        PlayerMovement.instance.animator.SetTrigger("Died");
        PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Kinematic;
        PlayerMovement.instance.enabled = false;
        
        yield return new WaitForSeconds(0.3f);
        GameOverManager.instance.OnPlayerDeath();
    }

    public IEnumerator InvicibilityTime()
    {
        yield return new WaitForSeconds(invincibilityTimeAfterHit);
        isInvincible = false;
    }
}
