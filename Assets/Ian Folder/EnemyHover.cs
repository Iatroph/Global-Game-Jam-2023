using UnityEngine;
using System.Collections;

public class EnemyHover : Enemy
{
    private HoverStates stateCurrent = HoverStates.Idle;

    public enum HoverStates
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
            case HoverStates.Idle:
                if (isDead) { StateDeadEnter(); }
                else if (base.marchDelay <= 0f) { StateMarchingEnter(); }
                else { StateIdleRemain(); }
                break;

            case HoverStates.Marching:
                if (isDead) { StateDeadEnter(); }
                break;
        }
    }

    void StateIdleEnter()
    {
        stateCurrent = HoverStates.Idle;
        base.agent.destination = transform.position;
    }

    void StateIdleRemain()
    {
        base.marchDelay -= Time.deltaTime;
    }

    void StateMarchingEnter()
    {
        stateCurrent = HoverStates.Marching;
        base.agent.destination = tree.transform.position;
    }

    void StateDeadEnter()
    {
        stateCurrent = HoverStates.Dead;
        base.agent.destination = transform.position;
        base.SpawnCurrency();
        base.Explode(false);
    }

    public override void ChangeHealth(float amount)
    {
        base.ChangeHealth(amount);
    }
}