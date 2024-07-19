using UnityEngine;

public class SkeletonVisual : MonoBehaviour
{
    [SerializeField] private EnemyAI _enemyAI;

    private Animator _animator;
    private const string ISRUNNING = "isRun";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        //_animator.SetBool( ISRUNNING, _enemyAI.IsRunning());
       // _animator
    }
}
