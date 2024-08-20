using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleableObject : MonoBehaviour, IResetable
{
    public Vector3 enterWindowSize;
    public Vector3 enterScale;
    public Vector3 initScale;
    [SerializeField] protected Vector3 minScale = new Vector3(0.1f, 0.1f, 1f);

    protected virtual void Start()
    {
        initScale = transform.localScale;
        if(GameManager.Instance.activeWindow != null)
        {
            enterWindowSize = new Vector3(GameManager.Instance.activeWindow.rend.size.x, GameManager.Instance.activeWindow.rend.size.y);
            enterScale = transform.localScale;
        }
    }

    protected virtual void OnDisable()
    {
        transform.localScale = initScale;
    }

    protected virtual void Update()
    {
        if (GameManager.Instance.activeWindow != null)
        {

            transform.localScale = new Vector2((GameManager.Instance.activeWindow.rend.size.x - Mathf.Abs((enterWindowSize.x - GameManager.Instance.activeWindow.rend.size.x) / GameManager.Instance.activeWindow.scaleFactor)) / enterWindowSize.x * enterScale.x, (GameManager.Instance.activeWindow.rend.size.y - Mathf.Abs((enterWindowSize.y - GameManager.Instance.activeWindow.rend.size.y) / GameManager.Instance.activeWindow.scaleFactor)) / enterWindowSize.y * enterScale.y);
        }
        if (transform.localScale.x < minScale.x)
        {
            transform.localScale = new Vector3(minScale.x, transform.localScale.y, transform.localScale.z);
        }
        if (transform.localScale.y < minScale.y)
        {
            transform.localScale = new Vector3(transform.localScale.x, minScale.y, transform.localScale.z);
        }
       
    }
    public virtual void ResetObject()
    {
        gameObject.SetActive(false);
        enterScale = initScale;
        enterWindowSize = GameManager.Instance.activeWindow.rend.size;
        transform.localScale = initScale;
        gameObject.SetActive(true);
    }


}
