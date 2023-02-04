using UnityEngine;
using System.Collections;

public class EnemyTank : Enemy
{
    public Transform[] waypoints;
    private int waypointItterator = 0;
    Transform targetWaypoint;

    private TankStates stateCurrent = TankStates.Idle;
    public float marchDelay = 0f;

    public float attackRange = 2f;

    public GameObject smallAttack;
    public GameObject largeAttack;

    private int attackCooldown = 0;
    private bool attackLocked = false;

    private ParticleSystem ps;
    private SpriteRenderer sr;

    public enum TankStates
    {
        Idle = 0,
        Marching,
        Attacking,
        Dead
    }

    protected override void Start()
    {
        targetWaypoint = waypoints[waypointItterator % waypoints.Length];
        base.Start();
        ps = GetComponentInChildren<ParticleSystem>();
        StateIdleEnter();
    }

    public override void FSMProcess()
    {
        base.playerDistance = Vector3.Distance(transform.position, player.position);
        attackCooldown -= 1;
        if (attackCooldown < 0)
        {
            attackCooldown = 0;
        }

        if (stateCurrent != TankStates.Attacking)
        {
            if (base.agent.destination.x < transform.position.x)
            {
                sr.flipX = false;
            }
            else
            {
                sr.flipX = true;
            }
        }

        switch (stateCurrent)
        {
            case TankStates.Idle:
                if (isDead) { StateIdleExit(); StateDeadEnter(); }
                else if (playerDistance <= attackRange) { StateIdleExit(); StateMarchingEnter(); }
                else { StateIdleRemain(); }
                break;

            case TankStates.Marching:
                if (isDead) { StateMarchingExit(); StateDeadEnter(); }
                else if (playerDistance <= attackRange) { StateMarchingExit(); StateAttackingEnter(); }
                else { StateMarchingRemain(); }
                break;

            case TankStates.Attacking:
                if (isDead) { StateAttackingExit(); StateDeadEnter(); }
                else if (playerDistance >= attackRange) { StateAttackingExit(); StateMarchingEnter(); }
                else { StateAttackingRemain(); }
                break;

            case TankStates.Dead:
                StateDeadRemain();
                break;
        }

    }

    void StateIdleEnter()
    {
        stateCurrent = TankStates.Idle;
        
    }

    void StateIdleRemain()
    {
        if (Vector3.Distance(targetWaypoint.position, transform.position) <= 1f)
        {
            waypointItterator += 1;
        }
        targetWaypoint = waypoints[waypointItterator % waypoints.Length];
        base.agent.destination = transform.position;
    }

    void StateIdleExit()
    {

    }

    void StateMarchingEnter()
    {
        stateCurrent = TankStates.Marching;
        if (Vector3.Distance(targetWaypoint.position, transform.position) <= 1f)
        {
            waypointItterator += 1;
        }
        targetWaypoint = waypoints[waypointItterator % waypoints.Length];
        base.agent.destination = targetWaypoint.position;
    }

    void StateMarchingRemain()
    {
        base.agent.destination = player.position;
    }

    void StateMarchingExit()
    {

    }

    void StateAttackingEnter()
    {
        stateCurrent = TankStates.Attacking;
        if (attackCooldown == 0)
        {
            StartCoroutine(SmallAttack());
        }
    }

    void StateAttackingRemain()
    {
        if (attackCooldown == 0)
        {
            StartCoroutine(SmallAttack());
        }
    }

    void StateAttackingExit()
    {

    }

    void StateDeadEnter()
    {
        stateCurrent = TankStates.Dead;
        base.agent.destination = transform.position;
        Destroy(gameObject);
    }

    void StateDeadRemain()
    {

    }

    IEnumerator SmallAttack()
    {
        Debug.Log("Small Attack");
        attackLocked = true;
        attackCooldown = 19;
        base.animator.SetBool("attackingWeak", true);

        yield return new WaitForSeconds(.6f);
        if (sr.flipX == false)
        {
            Instantiate(smallAttack, leftAttackSpawn.position, new Quaternion(0, 0, 0, 0));
        }
        else
        {
            Instantiate(smallAttack, leftAttackSpawn.position, new Quaternion(0, 0, 0, 0));
        }

        yield return new WaitForSeconds(.3f);

        attackLocked = false;
        base.animator.SetBool("attackingWeak", false);
        yield return null;
    }

    public override void ChangeHealth(float amount)
    {
        base.ChangeHealth(amount);
        if (amount < 0)
        {
            ps.Play();
        }
    }
}
