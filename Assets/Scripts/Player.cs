using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 500;

    private float horizontal, vertical;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        if(Mathf.Abs(horizontal) > 0.1f)
        {
            rb.velocity = new Vector2 (horizontal * speed * Time.fixedDeltaTime, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0,rb.velocity.y);
        }
        if (Mathf.Abs(vertical) > 0.1f)
        {
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed * Time.fixedDeltaTime);
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
    }
}
