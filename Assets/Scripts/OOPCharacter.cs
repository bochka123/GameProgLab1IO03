using System;
using UnityEngine;

public class OOPCharacter : MonoBehaviour
{
    public Rigidbody2D Rb { get; private set; }

    private void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    public void Move(float moveHorizontal)
    {

        Vector2 movement = new Vector2(moveHorizontal, Rb.velocity.y);
        Rb.velocity = movement;
    }

    public void Jump(float jumpForce)
    {
        Rb.velocity = new Vector2(Rb.velocity.x, jumpForce);
    }
}
