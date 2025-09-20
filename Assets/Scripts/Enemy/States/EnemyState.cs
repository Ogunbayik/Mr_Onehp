
public abstract class EnemyState 
{
    public abstract void EnterState(EnemyBase enemy);
    public abstract void ExitState(EnemyBase enemy);
    public abstract void UpdateState(EnemyBase enemy);
}
