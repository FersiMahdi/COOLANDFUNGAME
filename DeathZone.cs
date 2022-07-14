using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private Transform playerSpawn;

    private GameObject[] respawns;
    public AudioClip fallSFX;
    private void Awake()
    {
        respawns = GameObject.FindGameObjectsWithTag("Respawn");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
           // col.transform.position = playerSpawn.position;
            Transform t = respawns[0].transform;
            foreach (var r in respawns)
            {
                if (r.transform.position.x< col.transform.position.x && r.transform.position.x > t.position.x)
                {
                    t = r.transform;
                }
            }
            AudioManager.instance.PlayClipAt(fallSFX, t.position);
            col.transform.position = t.position;
            col.GetComponent<SpriteRenderer>().flipX = false;
            PlayerHealth playerHealth = col.transform.GetComponent<PlayerHealth>();
            playerHealth.takeDamage(20);
        }
    }
}
