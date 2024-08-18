using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesktopWindow : MonoBehaviour
{
    private SpriteRenderer rend;
    [SerializeField] Vector2 initWindowSize;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        rend.size = initWindowSize;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
