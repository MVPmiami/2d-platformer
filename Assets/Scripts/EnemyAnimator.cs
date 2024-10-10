using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    private const string EnemyRun = "EnemyRun";
    private const string EnemyAttack = "EnemyAttack";

    [SerializeField] private Animator _animator;

    private int _runHash;
    private int _attackHash;

    private void Start()
    {
        _runHash = Animator.StringToHash(nameof(EnemyRun));
        _attackHash = Animator.StringToHash(nameof(EnemyAttack));
    }

    public void Run()
    {
        _animator.SetBool(_runHash, true);
    }

    public void Idle()
    {
        _animator.SetBool(_runHash, false);
    }

    public void Attack()
    {
        _animator.SetBool(_attackHash, true);
    }

    public void StopAttack()
    {
        _animator.SetBool(_attackHash, false);
    }
}
