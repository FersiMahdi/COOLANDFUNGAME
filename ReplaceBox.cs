using UnityEngine;

public class ReplaceBox : MonoBehaviour
{
    public GameObject g;
    public GameObject debbox;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Box"))
        {
            GameObject box2 = GameObject.Instantiate(g);
            box2.transform.position = debbox.transform.position;
            box2.name = "Box";
            Destroy(g);
            g = box2;
        }
    }
}
