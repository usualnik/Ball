using UnityEngine;

public class Controls : MonoBehaviour
{
    public static Controls Instance { get; private set; }

    public enum MobileInputButtonType
    {
        LeftUp,
        LeftDown,
        RightUp,
        RightDown
    }

    public Rigidbody2D leftBoard, rightBoard;
    public float moveSpeed = 5f;

    // Состояния кнопок (для мобильного ввода)
    private bool _isLeftUpPressed, _isLeftDownPressed;
    private bool _isRightUpPressed, _isRightDownPressed;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Update()
    {
        if (!GameManager.Instance.IsMobilePlatform)
        {
            HandleKeyboardMovement();
            HandleKeyboardSound();
        }
        else
        {
            HandleMobileMovement();
            HandleMobileSound();
        }
    }

    //--- Управление с клавиатуры ---
    private void HandleKeyboardMovement()
    {
        // Левая платформа
        leftBoard.linearVelocity = Input.GetKey(KeyCode.W) ? new Vector2(0, moveSpeed) :
                                 Input.GetKey(KeyCode.S) ? new Vector2(0, -moveSpeed) :
                                 Vector2.zero;

        // Правая платформа
        rightBoard.linearVelocity = Input.GetKey(KeyCode.UpArrow) ? new Vector2(0, moveSpeed) :
                                   Input.GetKey(KeyCode.DownArrow) ? new Vector2(0, -moveSpeed) :
                                   Vector2.zero;
    }

    private void HandleKeyboardSound()
    {
        // Одноразовые звуки при нажатии
        if (Input.GetKeyDown(KeyCode.W)) AudioManager.Instance.Play("ControlPress");
        if (Input.GetKeyDown(KeyCode.S)) AudioManager.Instance.Play("ControlPress");
        if (Input.GetKeyDown(KeyCode.UpArrow)) AudioManager.Instance.Play("ControlPress");
        if (Input.GetKeyDown(KeyCode.DownArrow)) AudioManager.Instance.Play("ControlPress");

        // Звук удержания
        bool isMoving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) ||
                       Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow);

        if (isMoving) AudioManager.Instance.PlayIfNotPlaying("ControlHold");
        else AudioManager.Instance.Stop("ControlHold");
    }

    //--- Управление на мобильных устройствах ---
    private void HandleMobileMovement()
    {
        // Левая платформа
        if (_isLeftUpPressed) leftBoard.linearVelocity = new Vector2(0, moveSpeed);
        else if (_isLeftDownPressed) leftBoard.linearVelocity = new Vector2(0, -moveSpeed);
        else leftBoard.linearVelocity = Vector2.zero;

        // Правая платформа
        if (_isRightUpPressed) rightBoard.linearVelocity = new Vector2(0, moveSpeed);
        else if (_isRightDownPressed) rightBoard.linearVelocity = new Vector2(0, -moveSpeed);
        else rightBoard.linearVelocity = Vector2.zero;
    }

    private void HandleMobileSound()
    {
        bool isMoving = _isLeftUpPressed || _isLeftDownPressed ||
                        _isRightUpPressed || _isRightDownPressed;

        if (isMoving) AudioManager.Instance.PlayIfNotPlaying("ControlHold");
        else AudioManager.Instance.Stop("ControlHold");
    }

    // Вызывается при нажатии/отпускании мобильных кнопок
    public void SetMobileInput(MobileInputButtonType buttonType, bool isPressed)
    {
        switch (buttonType)
        {
            case MobileInputButtonType.LeftUp:
                _isLeftUpPressed = isPressed;
                if (isPressed) AudioManager.Instance.Play("ControlPress");
                break;

            case MobileInputButtonType.LeftDown:
                _isLeftDownPressed = isPressed;
                if (isPressed) AudioManager.Instance.Play("ControlPress");
                break;

            case MobileInputButtonType.RightUp:
                _isRightUpPressed = isPressed;
                if (isPressed) AudioManager.Instance.Play("ControlPress");
                break;

            case MobileInputButtonType.RightDown:
                _isRightDownPressed = isPressed;
                if (isPressed) AudioManager.Instance.Play("ControlPress");
                break;
        }
    }
}