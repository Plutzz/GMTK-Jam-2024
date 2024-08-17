using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotation : MonoBehaviour
{
    public Vector3 mousePosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePosition - transform.position;
        transform.eulerAngles = new Vector3(0,0, Mathf.Atan2(direction.y, direction.x)) * Mathf.Rad2Deg;
        Debug.DrawRay(transform.position, direction, Color.red);
    }
}
