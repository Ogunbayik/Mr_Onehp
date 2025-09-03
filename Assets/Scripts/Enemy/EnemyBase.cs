using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    protected PlayerMovement player;

    [Header("Enemy Settings")]
    [SerializeField] protected float movementSpeed;
    [SerializeField] protected float attackRange;
    private void Awake()
    {
        player = GameObject.FindObjectOfType<PlayerMovement>();
    }
    private void Update()
    {
        HandleMovement();
    }
    public virtual void HandleMovement()
    {
        Debug.Log("Enemy is movement to player");
        //transform.position = Vector3.MoveTowards(transform.position, player.transform.position, movementSpeed * Time.deltaTime);
    }
    public virtual void HandleAttack()
    {
        Debug.Log("Enemy is attacking to player");
    }

}
