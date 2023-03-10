using UnityEngine;
using System.Collections;

public class EnemyTank : Enemy
{
    private TankStates stateCurrent = TankStates.Idle;

    public enum TankStates
    {
        Idle = 0,
        Marching,
        Attacking,
        Dead
    }

    protected override void Start()
    {
        base.Start();
        StateIdleEnter();
    }

    public override void FSMProcess()
    {
        switch (stateCurrent)
        {
            case TankStates.Idle:
                if (isDead) { StateDeadEnter(); }
                else if (base.marchDelay <= 0f) { StateMarchingEnter(); }
                else { StateIdleRemain(); }
                break;

            case TankStates.Marching:
                if (isDead) { StateDeadEnter(); }
                break;
        }
    }

    void StateIdleEnter()
    {
        stateCurrent = TankStates.Idle;
        base.agent.destination = transform.position;
    }

    void StateIdleRemain()
    {
        base.marchDelay -= Time.deltaTime;
    }

    void StateMarchingEnter()
    {
        stateCurrent = TankStates.Marching;
        base.agent.destination = tree.transform.position;
    }

    void StateDeadEnter()
    {
        stateCurrent = TankStates.Dead;
        base.agent.destination = transform.position;
        base.SpawnCurrency();
        base.Explode(false);
    }

    public override void ChangeHealth(float amount)
    {
        base.ChangeHealth(amount);
    }
}