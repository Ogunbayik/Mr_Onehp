using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyBase : MonoBehaviour
{
    public EnemyState currentState;
    public EnemyAnimationController animationController;

    public EnemyPatrolState patrolState = new EnemyPatrolState();
    public EnemyLookState lookState = new EnemyLookState();
    public EnemyChaseState chaseState = new EnemyChaseState();
    public EnemyAttackState attackState = new EnemyAttackState();

    [HideInInspector]
    public NavMeshAgent enemyAgent;
    public EnemySO enemySO;

    public PlayerMovement player;
    protected enum EnemyType
    {
        Melee,
        Range
    }
    [Header("Enemy Settings")]
    [SerializeField] protected EnemyType enemyType;

    [HideInInspector]
    public Vector3 movementPosition;
    [HideInInspector]
    public Vector3 startPosition;
    private void Awake()
    {
        player = GameObject.FindObjectOfType<PlayerMovement>();
        animationController = GetComponentInChildren<EnemyAnimationController>();
        enemyAgent = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
        startPosition = transform.position;
        currentState = patrolState;
        currentState.EnterState(this);
    }
    private void Update()
    {
        currentState.UpdateState(this);
    }
    public void SwitchState(EnemyState newState)
    {
        if (currentState == newState)
            return;

        currentState.ExitState(this);
        currentState = newState;
        currentState.EnterState(this);
    }
    public virtual void HandleMovement(Vector3 movePos)
    {
        movementPosition = movePos;
        enemyAgent.SetDestination(movementPosition);
    }
    public virtual void HandleAttack()
    {
        Debug.Log("Enemy is attacking to player");
    }
}
