using UnityEngine;

public class PlayerView : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private PlayerMove _playerMove;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _playerMove = GetComponent<PlayerMove>();
    }

    private void Update()
    {
        if(_playerMove.CurrentSpeed > 0)
            _spriteRenderer.flipX = false;
        else if(_playerMove.CurrentSpeed < 0)
            _spriteRenderer.flipX = true;
        
        _animator.SetFloat("Speed", Mathf.Abs(_playerMove.CurrentSpeed));
        _animator.SetBool("Jumping", !_playerMove.IsOnGround);
    }
}