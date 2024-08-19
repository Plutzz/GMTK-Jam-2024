using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockScaleToRendSize : MonoBehaviour
{
    [SerializeField] private SpriteRenderer rend;
    [SerializeField] private Vector2 offset;
    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(rend.size.x + offset.x, rend.size.y + offset.y, 1f);
    }
}
