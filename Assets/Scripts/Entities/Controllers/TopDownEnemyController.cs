using UnityEngine;

public class TopDownEnemyController : TopDownController
{
    GameManager gameManager;
    protected Transform ClosestTarget { get; set; }

    protected override void Awake()
    {
        base.Awake();
    }

    protected virtual void Start()
    {
        gameManager = GameManager.Instance;
        ClosestTarget = GameManager.Instance.Player;
    }

    protected virtual void FixedUpdate()
    {

    }

    protected float DistanceToTarget()
    {
        return Vector3.Distance(transform.position, ClosestTarget.position);
    }

    protected Vector2 DirectionToTarget()
    {
        return (ClosestTarget.position - transform.position).normalized;
    }
}
