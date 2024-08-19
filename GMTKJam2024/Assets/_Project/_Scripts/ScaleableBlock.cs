using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleableBlock : ScaleableObject
{
    [SerializeField] protected GameObject colliderObject;
    protected SpriteRenderer rend;

    private void Awake()
    {
        rend = GetComponent<SpriteRenderer>();
        initScale = new Vector3(rend.size.x, rend.size.y, 1f);
    }

    protected override void Start()
    {
        colliderObject.transform.localScale = initScale;

        if (GameManager.Instance.activeWindow != null)
        {
            enterWindowSize = new Vector3(GameManager.Instance.activeWindow.rend.size.x - GameManager.Instance.activeWindow.borderSize, GameManager.Instance.activeWindow.rend.size.y - GameManager.Instance.activeWindow.borderSize);
            enterScale = new Vector3(rend.size.x, rend.size.y, 1f);
        }
    }

    protected override void OnDisable()
    {
        rend.size = initScale;
        colliderObject.transform.localScale = initScale;
    }

    protected override void Update()
    {
        if (rend.size.x < minScale.x)
        {
            Debug.Log("minSize");
            rend.size = new Vector2(minScale.x, rend.size.y);
            colliderObject.transform.localScale = new Vector3(rend.size.x, rend.size.y, 1f);
        }
        if (rend.size.y < minScale.y)
        {
            rend.size = new Vector2(rend.size.x, minScale.y);
            colliderObject.transform.localScale = new Vector3(rend.size.x, rend.size.y, 1f);
        }
        if (GameManager.Instance.activeWindow != null)
        {
            rend.size = new Vector2((GameManager.Instance.activeWindow.rend.size.x - GameManager.Instance.activeWindow.borderSize) / enterWindowSize.x * enterScale.x, (GameManager.Instance.activeWindow.rend.size.y - GameManager.Instance.activeWindow.borderSize) / enterWindowSize.y * enterScale.y);
            colliderObject.transform.localScale = new Vector3((GameManager.Instance.activeWindow.rend.size.x - GameManager.Instance.activeWindow.borderSize) / enterWindowSize.x * enterScale.x, (GameManager.Instance.activeWindow.rend.size.y - GameManager.Instance.activeWindow.borderSize) / enterWindowSize.y * enterScale.y, 1f);
        }
    }

    public override void ResetObject()
    {
        gameObject.SetActive(false);
        enterScale = initScale;
        enterWindowSize = GameManager.Instance.activeWindow.rend.size;
        rend.size = initScale;
        colliderObject.transform.localScale = initScale;
        gameObject.SetActive(true);
    }
}
