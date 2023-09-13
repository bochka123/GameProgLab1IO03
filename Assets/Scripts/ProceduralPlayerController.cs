using UnityEngine;

public class ProceduralPlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private float moveSpeed;
    private Rigidbody2D _rb;
    private Animator _animator;
    private readonly string[] _animationNames;
    private string _correctAnimation;

    public ProceduralPlayerController()
    {
        _animationNames = new[]
        {
            "IdleForward",
            "IdleRight",
            "IdleLeft",
            "RunRight",
            "RunLeft"
        };
    }
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        _rb.velocity = new Vector2(horizontalInput * moveSpeed, _rb.velocity.y);
        if (horizontalInput > 0 && _rb.velocity.y == 0)
        {
            _correctAnimation = _animationNames[3];
        }
        else if (horizontalInput < 0 && _rb.velocity.y == 0)
        {
            _correctAnimation = _animationNames[4];
        }
        else if (horizontalInput > 0 && _rb.velocity.y != 0)
        {
            _correctAnimation = _animationNames[1];
        }
        else if (horizontalInput < 0 && _rb.velocity.y != 0)
        {
            _correctAnimation = _animationNames[2];
        }
        else
        {
            _correctAnimation = _animationNames[0];
        }
        _animator.Play(_correctAnimation);
    }
}
