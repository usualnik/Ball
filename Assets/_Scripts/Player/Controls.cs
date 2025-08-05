using UnityEngine;

public class Controls : MonoBehaviour
{
    public Rigidbody2D leftBoard;
    public Rigidbody2D rightBoard;
    public float moveSpeed = 5f;

    void Update()
    {    

        if (Input.GetKey(KeyCode.W))
        {
            leftBoard.linearVelocity = new Vector2(0, moveSpeed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            leftBoard.linearVelocity = new Vector2(0, -moveSpeed);
        }
        else
        {
            leftBoard.linearVelocity = new Vector2(0, 0);
        }


        if (Input.GetKey(KeyCode.UpArrow))
        {
            rightBoard.linearVelocity = new Vector2(0, moveSpeed);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            rightBoard.linearVelocity = new Vector2(0, -moveSpeed);
        }
        else
        {
            rightBoard.linearVelocity = new Vector2(0, 0);
        }
    }
}
