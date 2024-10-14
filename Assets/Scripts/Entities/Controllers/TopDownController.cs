using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TopDownController : MonoBehaviour
{
    // Action ���
    // event / Action


    public event Action<Vector2> OnMoveEvent; // Action�� ������ void�� ��ȯ�ؾ� �Ѵ� or Func
    public event Action<Vector2> OnLookEvent;

    // OnAttackEvent�� ������ �� ���� ��������(AttackSO)�� ��� ��
    public event Action<AttackSO> OnAttackEvent;

    protected bool isAttacking { get; set; }

    private float timeSinceLastAttack = float.MaxValue;

    protected CharacterStatHandler stats { get; private set; }

    protected virtual void Awake()
    {
        stats = GetComponent<CharacterStatHandler>();
    }


    private void Update()
    {
        HandleAttackDelay();
    }

    private void HandleAttackDelay()
    {
        if (timeSinceLastAttack <= stats.CurrentStat.attackSO.delay)
        {
            timeSinceLastAttack += Time.deltaTime;
        }

        if (isAttacking && timeSinceLastAttack > stats.CurrentStat.attackSO.delay)
        {
            timeSinceLastAttack = 0;// ���� ������ ������ attackSO����
            CallAttackEvent(stats.CurrentStat.attackSO);
        }
    }


    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction); // ?. ������ ���� ������ �����Ѵ�
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }

    public void CallAttackEvent(AttackSO attackSO)
    {
        // TopDownShooting���� ����� OnShoot �޼ҵ尡 �����Ǿ� ����.
        OnAttackEvent?.Invoke(attackSO);
    }
}                
