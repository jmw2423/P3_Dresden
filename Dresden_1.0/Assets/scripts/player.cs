using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Vector3 move;
    private RaycastHit2D hit;
    // Start is called before the first frame update
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        move = new Vector3(x, y, 0);

        /*if(move.x > 0)
        {
            transform.localScale = new Vector3(0.16f, 0.16f, 1);

        }
        else if(move.x < 0)
        {
            transform.localScale = new Vector3(-0.16f, 0.16f, 1);

        }*/
        //y axis
        hit = Physics2D.BoxCast(transform.position, boxCollider.size/10, 0, new Vector2(0, move.y), Mathf.Abs(move.y * Time.deltaTime), LayerMask.GetMask("Blocking", "Actor"));
        if(hit.collider == null)
        {
            transform.Translate(0, move.y * Time.deltaTime, 0);

        }
        //x axis
        hit = Physics2D.BoxCast(transform.position, boxCollider.size/10, 0, new Vector2(move.x, 0), Mathf.Abs(move.x * Time.deltaTime), LayerMask.GetMask("Blocking", "Actor"));
        if (hit.collider == null)
        {
            transform.Translate(move.x * Time.deltaTime, 0, 0);

        }

    }
}
