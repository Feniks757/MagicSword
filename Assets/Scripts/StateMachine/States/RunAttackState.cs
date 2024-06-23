using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class RunAttackState : State
{
    [SerializeField] private float _speed;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        FlipToPlayer();
        _animator.SetTrigger("Attack");
    }

    private void Update()
    {
        Run();
    }

    private void Run()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }

    private void FlipToPlayer()
    {
        Vector2 directionToPlayer = Player.transform.position - transform.position;
        directionToPlayer.Normalize();

        if (directionToPlayer.x > 0)
        {
            _spriteRenderer.flipX = false;
        }
        else if (directionToPlayer.x < 0)
        {
            _spriteRenderer.flipX = true;
        }
    }
}
