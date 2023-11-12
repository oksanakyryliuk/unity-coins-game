using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed = 3;
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private float _jumpForce = 3;
    [SerializeField] private LayerMask _layerMask;
    private Rigidbody2D _rigidbody2D;
    private bool _paused;
    public bool IsOnGround => IsGrounded();

    public float CurrentSpeed => _rigidbody2D.velocity.x;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(_paused)
        {
            _rigidbody2D.velocity = Vector2.zero;
            return;    
        }
        
        float input = Input.GetAxis("Horizontal");
        _rigidbody2D.velocity = new Vector2(input * _speed, _rigidbody2D.velocity.y);

        if(Input.GetButton("Jump") && IsGrounded())
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpForce);
    }
    
    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.CircleCast(_groundChecker.position, 0.1f, Vector2.down, 0.1f, _layerMask);
        return hit.collider != null;
    }

    private void OnBecameInvisible()
    {
        var position = transform.position;
        transform.position = new Vector2(-position.x, position.y);
        _rigidbody2D.velocity = -_rigidbody2D.velocity;
    }

    public void Pause() =>
        _paused = true;

    public void Resume() =>
        _paused = false;
}