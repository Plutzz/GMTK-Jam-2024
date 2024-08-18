using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleableObject : MonoBehaviour
{
    public Vector3 enterWindowSize;
    public Vector3 enterScale;
    public Vector3 initScale;
    [SerializeField] private Vector3 minScale = new Vector3(0.1f, 0.1f, 1f);

    private void Start()
    {
        initScale = transform.localScale;
    }

    private void OnDisable()
    {
        transform.localScale = initScale;
    }

    private void Update()
    {
        if(transform.localScale.x < minScale.x)
        {
            transform.localScale = new Vector3(minScale.x, transform.localScale.y, transform.localScale.z);
        }
        if (transform.localScale.y < minScale.y)
        {
            transform.localScale = new Vector3(transform.localScale.x, minScale.y, transform.localScale.z);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("EnterS");
        if (collision.transform.parent == GameManager.Instance.activeWindow.transform)
        {
            Debug.Log("EnterS");
            enterWindowSize = new Vector3(GameManager.Instance.activeWindow.rend.size.x - GameManager.Instance.activeWindow.borderSize, GameManager.Instance.activeWindow.rend.size.y - GameManager.Instance.activeWindow.borderSize);
            enterScale = transform.localScale;        
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log(collision.transform.parent);
        Debug.Log(GameManager.Instance.activeWindow.gameObject);
        if (collision.transform.parent == GameManager.Instance.activeWindow.transform)
        {
            Debug.Log("StayS");
            //collision.transform.localScale = new Vector2(enterSize.y / col.size.y, enterSize.x / col.size.x);
            transform.localScale = new Vector2((GameManager.Instance.activeWindow.rend.size.x - GameManager.Instance.activeWindow.borderSize) / enterWindowSize.x * enterScale.x, (GameManager.Instance.activeWindow.rend.size.y - GameManager.Instance.activeWindow.borderSize) / enterWindowSize.y * enterScale.y);        
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("EnterS");
        if (collision.transform.parent == GameManager.Instance.activeWindow.transform)
        {
            Debug.Log("EnterS");
            enterWindowSize = new Vector3(GameManager.Instance.activeWindow.rend.size.x - GameManager.Instance.activeWindow.borderSize, GameManager.Instance.activeWindow.rend.size.y - GameManager.Instance.activeWindow.borderSize);
            enterScale = transform.localScale;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(collision.transform.parent);
        Debug.Log(GameManager.Instance.activeWindow.gameObject);
        if (collision.transform.parent == GameManager.Instance.activeWindow.transform)
        {
            Debug.Log("StayS");
            //collision.transform.localScale = new Vector2(enterSize.y / col.size.y, enterSize.x / col.size.x);
            transform.localScale = new Vector2((GameManager.Instance.activeWindow.rend.size.x - GameManager.Instance.activeWindow.borderSize) / enterWindowSize.x * enterScale.x, (GameManager.Instance.activeWindow.rend.size.y - GameManager.Instance.activeWindow.borderSize) / enterWindowSize.y * enterScale.y);
        }
    }


}
