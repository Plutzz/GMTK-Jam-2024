using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BlockSelector : MonoBehaviour
{
    [SerializeField] private List<GameObject> blocks;
    private void Start()
    {
        
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            int randomBlockIndex = Random.Range(0, blocks.Count);
            Instantiate(blocks[randomBlockIndex]);
            Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
    }
}
