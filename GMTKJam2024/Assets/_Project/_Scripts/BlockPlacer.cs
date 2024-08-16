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

    private void Update()
    {
        gameObject.transform.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x ,gameObject.transform.position.y);

        if (growShrink) { gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x + changeFactor * Time.deltaTime, gameObject.transform.localScale.y + changeFactor * Time.deltaTime); }

        else { gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x - (changeFactor * Time.deltaTime), gameObject.transform.localScale.y - (changeFactor * Time.deltaTime)); }

        if (maxSize < gameObject.transform.localScale.x) { growShrink = false;  }
        if (minSize > gameObject.transform.localScale.x) { growShrink = true; }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            //Turn On gravity disable this script?
        }
    }
}
