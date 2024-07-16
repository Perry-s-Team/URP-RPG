using UnityEngine;
using UnityEngine.AI;
using RPG.Utils;

public class EnemyAI : MonoBehaviour
{
    //[Header("EnemyProperty")]
    

    [Header("EnemyNavigation")]
    [SerializeField] private State startingState;
    [SerializeField] private float roamingDistanceMax = 7f;
    [SerializeField] private float roamingDistanceMin = 3f;
    [SerializeField] private float roamingTimerMax = 2f;

    [Header("EnemyChasing")]
    [SerializeField] private bool _isChasingEnemy = false;
    [SerializeField] private float _chasingDisnance = 4f;
    [SerializeField] private float _chasingSpeedMultiplayer = 2f;

    private NavMeshAgent _navMeshAgent;
    private State _currentrState;
    private float _roamingTimer;
    private Vector3 _roamingPosition;
    private Vector3 _startingPosition;
    private float _roamingSpeed;
    private float _chasingSpeed;

    public bool IsRunning()
    {
        if (_navMeshAgent.velocity == Vector3.zero)
            return false;
        else
            return true;
    }


    private enum State
    {
        Idle,
        Roaming,
        Chasing,
        Attacking,
        Death
    }

    private void Start()
    {
        _startingPosition = transform.position;
    }

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.updateRotation = false;
        _navMeshAgent.updateUpAxis = false;
        _currentrState = startingState;
        _roamingSpeed = _navMeshAgent.speed;
        _chasingSpeed = _navMeshAgent.speed * _chasingSpeedMultiplayer;
    }
    private void Update()
    {

    }
    private void StateHandler()
    {
        switch (_currentrState)
        {
            default:
            case State.Idle:
                break;
            case State.Roaming:
                _roamingTimer -= Time.deltaTime;
                if (_roamingTimer < 0)
                {
                    Roaming();
                    _roamingTimer = roamingTimerMax;
                }
                CheckCurrentState();
                break;
            case State.Chasing:
                ChasingTarget();
                CheckCurrentState();
                break;
            case State.Attacking:
                break;
            case State.Death:
                break;
        }
    }

    private void Roaming()
    {
        _roamingPosition = GetRoamingPosition();
        _navMeshAgent.SetDestination(_roamingPosition);
        ChangeFacingDuration(_startingPosition, _roamingPosition);
    }

    private void ChasingTarget()
    {
        _navMeshAgent.SetDestination(Movement.Instance.transform.position);
    }

    private void CheckCurrentState()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, Movement.Instance.transform.position);
        State newState = State.Roaming;

        if (_isChasingEnemy)
        {
            if (distanceToPlayer <= _chasingDisnance)
            {
                newState = State.Chasing;
            }
        }

        if (newState != _currentrState)
        {
            if (newState == State.Chasing)
            {
                _navMeshAgent.ResetPath();
                _navMeshAgent.speed = _chasingSpeed;
            }
            else if (newState == State.Roaming) {
            _roamingTimer = 0f;
            _navMeshAgent.speed = _roamingSpeed; 
            }

            _currentrState = newState;
        }

    }

    private Vector3 GetRoamingPosition()
    {
        return _startingPosition + Utils.GetRandomDir() * UnityEngine.Random.Range(roamingDistanceMin, roamingDistanceMax);
    }

    private void ChangeFacingDuration(Vector3 soursePosition, Vector3 targetPosition)
    {
        if (soursePosition.x > targetPosition.x)
            transform.rotation = Quaternion.Euler(0, -180, 0);
        else
            transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
