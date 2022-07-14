using UnityEngine;

public class HealPowerUp : MonoBehaviour
{
  public AudioClip HealSound;
  private void OnTriggerEnter2D(Collider2D col)
  {
    if (col.CompareTag("Player"))
    {
      AudioManager.instance.PlayClipAt(HealSound, transform.position);
      col.GetComponent<PlayerHealth>().heal(20);
      Destroy(gameObject);
    }
  }
}
