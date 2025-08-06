using UnityEngine;

public class Controls : MonoBehaviour
{
    public Rigidbody2D leftBoard, rightBoard;
    public float moveSpeed = 5f;

    void Update()
    {
        HandleMovement();
        HandleSound();
    }

    private void HandleMovement()
    {
        
        leftBoard.linearVelocity = Input.GetKey(KeyCode.W) ? new Vector2(0, moveSpeed) :
                            Input.GetKey(KeyCode.S) ? new Vector2(0, -moveSpeed) :
                            Vector2.zero;

        
        rightBoard.linearVelocity = Input.GetKey(KeyCode.UpArrow) ? new Vector2(0, moveSpeed) :
                              Input.GetKey(KeyCode.DownArrow) ? new Vector2(0, -moveSpeed) :
                              Vector2.zero;
    }

    private void HandleSound()
    {
        //-------------------------One time sound-------------------------------
        if (Input.GetKeyDown(KeyCode.W)) AudioManager.Instance.Play("ControlPress");
        if (Input.GetKeyDown(KeyCode.S)) AudioManager.Instance.Play("ControlPress");
        if (Input.GetKeyDown(KeyCode.UpArrow)) AudioManager.Instance.Play("ControlPress");
        if (Input.GetKeyDown(KeyCode.DownArrow)) AudioManager.Instance.Play("ControlPress");

        //-------------------------Looping sound-------------------------------
        bool isMoving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) ||
                       Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow);

        if (isMoving) AudioManager.Instance.PlayIfNotPlaying("ControlHold");
        else AudioManager.Instance.Stop("ControlHold");
    }
}