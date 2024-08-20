using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleableBlock : ScaleableObject, IResetable
{
    [SerializeField] protected GameObject colliderObject;
    protected SpriteRenderer rend;
    [SerializeField] private bool inverseScale;

    private void Awake()
    {
        rend = GetComponent<SpriteRenderer>();
        //initScale = new Vector3(rend.size.x, rend.size.y, 1f);
        if (inverseScale)
        {
            initScale = new Vector3(1 / rend.size.x, 1 / rend.size.y, 1f);
        }
        else
        {
            initScale = new Vector3(rend.size.x, rend.size.y, 1f);
        }
    }

    protected override void Start()
    {
        colliderObject.transform.localScale = initScale;

        if (GameManager.Instance.activeWindow != null)
        {
            enterWindowSize = new Vector3(GameManager.Instance.activeWindow.rend.size.x, GameManager.Instance.activeWindow.rend.size.y);
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
        if (GameManager.Instance.activeWindow != null)
        {
            //Vector2 rendVector = new Vector2((GameManager.Instance.activeWindow.rend.size.x + GameManager.Instance.activeWindow.borderSize) / enterWindowSize.x * enterScale.x, (GameManager.Instance.activeWindow.rend.size.y + GameManager.Instance.activeWindow.borderSize) / enterWindowSize.y * enterScale.y);
            //Vector3 scaleVector = new Vector3((GameManager.Instance.activeWindow.rend.size.x + GameManager.Instance.activeWindow.borderSize) / enterWindowSize.x * enterScale.x, (GameManager.Instance.activeWindow.rend.size.y + GameManager.Instance.activeWindow.borderSize) / enterWindowSize.y * enterScale.y, 1f);
            Vector2 rendVector = new Vector2((GameManager.Instance.activeWindow.rend.size.x - Mathf.Abs((enterWindowSize.x - GameManager.Instance.activeWindow.rend.size.x) / GameManager.Instance.activeWindow.scaleFactor)) / enterWindowSize.x * enterScale.x, (GameManager.Instance.activeWindow.rend.size.y - Mathf.Abs((enterWindowSize.y - GameManager.Instance.activeWindow.rend.size.y) / GameManager.Instance.activeWindow.scaleFactor)) / enterWindowSize.y * enterScale.y);
            Vector3 scaleVector = new Vector3((GameManager.Instance.activeWindow.rend.size.x - Mathf.Abs((enterWindowSize.x - GameManager.Instance.activeWindow.rend.size.x) / GameManager.Instance.activeWindow.scaleFactor)) / enterWindowSize.x * enterScale.x, (GameManager.Instance.activeWindow.rend.size.y - Mathf.Abs((enterWindowSize.y - GameManager.Instance.activeWindow.rend.size.y) / GameManager.Instance.activeWindow.scaleFactor)) / enterWindowSize.y * enterScale.y, 1f);

            rend.size = rendVector;
            colliderObject.transform.localScale = scaleVector;

            if (inverseScale)
            {
                rend.size = new Vector2(1f / rendVector.x, 1f / rendVector.y);
                colliderObject.transform.localScale = new Vector3(1 / rendVector.x, 1 / rendVector.y, 1f);
            }
        }
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
        

        
    }

    public override void ResetObject()
    {
        gameObject.SetActive(false);
        enterScale = initScale;
        enterWindowSize = GameManager.Instance.activeWindow.rend.size;
        rend.size = initScale;
        colliderObject.transform.localScale = initScale;
        //if (!inverseScale)
        //{
        //    rend.size = initScale;
        //    colliderObject.transform.localScale = initScale;
        //}
        //else
        //{
        //    rend.size = new Vector2( 1 / initScale.x, 1 / initScale.y);
        //    colliderObject.transform.localScale = new Vector3(1 / initScale.x, 1 / initScale.y, 1f);
        //}
        gameObject.SetActive(true);
    }
}
