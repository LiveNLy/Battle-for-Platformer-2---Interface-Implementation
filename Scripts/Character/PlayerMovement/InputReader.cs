using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Running = nameof(Running);
    private const string Jumping = nameof(Jumping);

    private float _direction = 0f;

    public event Action<string> JumpAnimating;
    public event Action Jumped;
    public event Action<string, bool> RunAnimating;
    public event Action<float> Runned;

    private void Update()
    {
        Move();
        Jump();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            JumpAnimating?.Invoke(Jumping);
            Jumped?.Invoke();
        }
    }

    private void Move()
    {
        _direction = Input.GetAxis(Horizontal);

        RunAnimating?.Invoke(Running, IsCharacterMoving());
        Runned?.Invoke(_direction);
    }

    private bool IsCharacterMoving() => Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D);
}