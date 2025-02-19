using UnityEngine;

public class BlockController : MonoBehaviour
{
    private GameObject child;
    private SpriteRenderer sr;
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        child = transform.GetChild(0).gameObject;
        sr = child.GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<SpotController>() != null)
        {
            Debug.Log("block enter");
            sr.color = Color.green;
            rb.mass = 50;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<SpotController>() != null)
        {
            Debug.Log("block quit");
            sr.color = Color.red;
            rb.mass = 1;
        }
    }
}
