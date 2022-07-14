using UnityEngine;

public class EnnemyPatrol : MonoBehaviour
{
    public float speed;

    public Transform[] waypoints;
    public int damageOnColision = 20;
    private Transform target;
    
    private int destPoint = 0;
    public SpriteRenderer spriteRenderer;
    void Start()
    {
        target = waypoints[0];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        if(Vector3.Distance(transform.position,target.position)<0.3f)
        {
            destPoint = ((destPoint + 1) % waypoints.Length);
            target = waypoints[destPoint];
            spriteRenderer.flipX = !spriteRenderer.flipX;

        }
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Player"))
        {
            PlayerHealth playerHealth = col.transform.GetComponent<PlayerHealth>();
            playerHealth.takeDamage(damageOnColision);
        }
    }
}
