using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TopDownController : MonoBehaviour
{
    // Action 등록
    // event / Action


    public event Action<Vector2> OnMoveEvent; // Action은 무조건 void만 반환해야 한다 or Func
    public event Action<Vector2> OnLookEvent;

    // OnAttackEvent는 눌렸을 때 공격 기준정보(AttackSO)를 들고 옴
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
            timeSinceLastAttack = 0;// 현재 장착된 무기의 attackSO전달
            CallAttackEvent(stats.CurrentStat.attackSO);
        }
    }


    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction); // ?. 없으면 말고 있으면 실행한다
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }

    public void CallAttackEvent(AttackSO attackSO)
    {
        // TopDownShooting에서 등록한 OnShoot 메소드가 구독되어 있음.
        OnAttackEvent?.Invoke(attackSO);
    }
}                
