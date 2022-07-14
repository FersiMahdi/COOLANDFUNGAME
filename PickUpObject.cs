using UnityEngine;

public class PickUpObject : MonoBehaviour
{
   public AudioClip sound;
   private void OnTriggerEnter2D(Collider2D col)
   {
      if (col.CompareTag("Player"))
      {
         AudioManager.instance.PlayClipAt(sound, transform.position);
         Inventory.instance.AddCoins(1);
         CurrentSceneManager.instance.coinsPickedUpInThisScene++;
         Destroy(gameObject);
         
      }
   }
}
