using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce;
    [SerializeField] private float speed;
    [SerializeField] private LayerMask layerMask;
    private bool isGround = true;
    private float horizontal;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {
        if (isGround)
        {
            Jump();
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        isGround = checkGround();
        Move();
        
    }

    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.W)|| Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce);
        }
    }

    private void Move()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if(Mathf.Abs(horizontal) > 0.1f)
        {
            rb.velocity = new Vector2(horizontal * speed * Time.fixedDeltaTime, rb.velocity.y);
            transform.rotation = Quaternion.Euler(horizontal>0?Vector3.zero:Vector3.up*180);
        }
        else if(isGround)
        {
            rb.velocity = Vector3.zero;
        }
    }
    private bool checkGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position,Vector2.down,1.1f,layerMask);
        return hit.collider != null;
    }

}
