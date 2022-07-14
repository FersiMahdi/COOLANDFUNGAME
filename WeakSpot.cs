using UnityEngine;


public class WeakSpot : MonoBehaviour
{
    public GameObject ObjectToDestroy;
    public float jumpForce;
    public AudioClip DeathSFX;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            AudioManager.instance.PlayClipAt(DeathSFX, transform.position);
            // Destroy(transform.parent.parent.gameObject);
           col.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f,jumpForce));

           Destroy(ObjectToDestroy);
           
        }
    }
}
