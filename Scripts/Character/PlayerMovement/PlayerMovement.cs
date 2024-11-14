using UnityEngine;

[RequireComponent(typeof(Fliper), typeof(Rigidbody2D), typeof(InputReader))]
public class PlayerMovement : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Running = nameof(Running);
    private const string Jumping = nameof(Jumping);

    [SerializeField] private float _moveSpeed;
    [SerializeField] private bool _canJump;
    [SerializeField] private float _jumpPower;

    private Fliper _fliper;
    private Rigidbody2D _rigidbody;
    private InputReader _inputReader;
    private bool _flipped = true;
    private bool _isJump;

    private void Awake()
    {
        _fliper = GetComponent<Fliper>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _inputReader = GetComponent<InputReader>();
    }

    private void OnEnable()
    {
        _inputReader.Jumped += JumpAction;
        _inputReader.Runned += Moving;
    }

    private void FixedUpdate()
    {
        if (_isJump && _canJump)
        {
            _rigidbody.velocity = _jumpPower * Vector2.up;
            _canJump = false;
            _isJump = false;
        }
    }

    private void OnDisable()
    {
        _inputReader.Jumped -= JumpAction;
        _inputReader.Runned -= Moving;
    }

    private void JumpAction()
    {
        if (_canJump)
            _isJump = true;
    }

    private void Moving(float direction)
    {
        float distance = direction * _moveSpeed * Time.deltaTime;

        transform.Translate(distance * Vector2.right);

        if (direction > 0 && !_flipped || direction < 0 && _flipped)
        {
            _fliper.Flip();
            _flipped = !_flipped;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ground platform))
            _canJump = true;
    }
}