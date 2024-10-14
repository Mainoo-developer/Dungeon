using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownContactEnemyController : TopDownEnemyController
{
    [SerializeField] [Range(0f, 100f)] private float followRange;
    [SerializeField] private string targetTag = "Player";
    private bool isCollidingWithTarget;

    [SerializeField] private SpriteRenderer characterRenderer;

    protected override void Start()
    {
        base.Start();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        Vector2 direction = Vector2.zero;
        if (DistanceToTarget() < followRange)
        {
            direction = DirectionToTarget();
        }

        CallMoveEvent(direction);
        Rotate(direction);
    }

    private void Rotate(Vector2 direction)
    {
        // TopDownAimRotation에서 했었죠? 
        // Atan2는 가로와 세로의 비율을 바탕으로 -파이~파이(-180도~180도에 대응, * Rad2Deg가 그 기능)하는 값을 나타내주는 함수였다는 것 기억하시죠?
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        characterRenderer.flipX = Mathf.Abs(rotZ) > 90f;
    }
}