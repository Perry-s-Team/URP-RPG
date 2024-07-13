using UnityEngine;
using UnityEngine.AI;
using RPG.Utils;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private State startingState;
    [SerializeField] private float roamingDistanceMax = 7f;
    [SerializeField] private float roamingDistanceMin = 3f;
    [SerializeField] private float roamingTimerMax = 2f;

    private NavMeshAgent _navMeshAgent;
    private State _state;
    private float _roamingTime;
    private Vector3 _roamingPosition;
    private Vector3 _startingPosition;

    private enum State
    {
        Idle,
        Roaming
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
        _state = startingState;
    }

    private void Update()
    {
        switch (_state)
        {
            default:
            case State.Idle:
                break;
            case State.Roaming:
                _roamingTime -= Time.deltaTime;
                if (_roamingTime < 0)
                {
                    Roaming();
                    _roamingTime = roamingTimerMax;
                }
                break;
        }
    }

    private void Roaming()
    {
        _roamingPosition = GetRoamingPosition();
        _navMeshAgent.SetDestination(_roamingPosition);
    }
    private Vector3 GetRoamingPosition()
    {
        return _startingPosition + Utils.GetRandomDir() * UnityEngine.Random.Range(roamingDistanceMin, roamingDistanceMax);
    }
}
