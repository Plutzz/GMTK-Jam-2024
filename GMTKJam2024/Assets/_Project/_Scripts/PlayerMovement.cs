using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed = 10f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameManager.Instance.player = gameObject;
    }

    void Update()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");
        Vector2 InputVector = new Vector2(xInput, yInput);

        rb.velocity = InputVector.normalized * speed;
    }
}
