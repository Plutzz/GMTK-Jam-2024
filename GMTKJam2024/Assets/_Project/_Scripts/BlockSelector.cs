using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using UnityEngine;

public class BlockSelector : MonoBehaviour
{
    [SerializeField] private float yOffset = 3f;
    [SerializeField] private List<GameObject> blocks;
    private void Start()
    {
        
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            int randomBlockIndex = Random.Range(0, blocks.Count);
            float maxY = 0f;
            foreach(Transform child in transform)
            {
                if(child.transform.position.y > maxY)
                {
                    maxY = child.transform.position.y;
                }
            }
            GameObject block = Instantiate(blocks[randomBlockIndex], transform);
            block.transform.position = new Vector3(block.transform.position.x, maxY + yOffset, block.transform.position.z);
            Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
    }
}
