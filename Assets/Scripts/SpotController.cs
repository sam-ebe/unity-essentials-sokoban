using UnityEngine;

public class SpotController : MonoBehaviour
{
    public float rotateSpeed = 2.0f;
    public int blockCount = 0; // Track the number of blocks on the spot

    private GameObject child;
    private SpriteRenderer sr;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        child = transform.GetChild(0).gameObject;
        sr =  child.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.Rotate(0,0,rotateSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<BlockController>() != null) {
            Debug.Log("enter spot");
            rotateSpeed = 0.5f;
            sr.color = Color.green;
            blockCount++;

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<BlockController>() != null)
        {
            blockCount--;
            Debug.Log("exit spot");
            if (blockCount <= 0)
            {
                blockCount = 0; // Ensure it doesn't go negative
                rotateSpeed = 2f;
                sr.color = Color.red;
            }
        }
    }
}
