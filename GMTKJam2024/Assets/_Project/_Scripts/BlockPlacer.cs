using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BlockPlacer : MonoBehaviour
{

    [SerializeField] private float maxSize;
    [SerializeField] private float minSize;
    [SerializeField] private float changeFactor;

    // False if block is shrinking true if growing

    [SerializeField] private bool growShrink;
    
    private Rigidbody2D blockBody;
    private Collider2D blockCollider;

    private void Start()
    {
        blockBody = gameObject.GetComponent<Rigidbody2D>();
        blockBody.gravityScale = 0;
        blockCollider = gameObject.GetComponent<Collider2D>();
        blockCollider.enabled = false;
    }
    private void Update()
    {
        gameObject.transform.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x ,gameObject.transform.position.y);

        if (growShrink) { gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x + changeFactor * Time.deltaTime, gameObject.transform.localScale.y + changeFactor * Time.deltaTime); }

        else { gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x - (changeFactor * Time.deltaTime), gameObject.transform.localScale.y - (changeFactor * Time.deltaTime)); }

        if (maxSize < gameObject.transform.localScale.x) { growShrink = false;  }
        if (minSize > gameObject.transform.localScale.x) { growShrink = true; }

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            blockBody.gravityScale = 1;
            blockCollider.enabled = true;
            Destroy(this);
        }
    }
}
