using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDeadState : ZombieStates
{
    int movementZHash = Animator.StringToHash("MovementZ");
    int isDeadHash = Animator.StringToHash("IsDead");

    public ZombieDeadState(ZombieComponent zombie, StateMachine stateMachine) : base(zombie, stateMachine)
    {

    }
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        ownerZombie.zombieNavMeshAgent.isStopped = true;
        ownerZombie.zombieNavMeshAgent.ResetPath();

        ownerZombie.zombieAnimator.SetFloat(movementZHash, 0);
        ownerZombie.zombieAnimator.SetBool(isDeadHash, true);
        Debug.Log("Zombie dead");
    }


    public override void Exit()
    {
        base.Exit();
        //ownerZombie.zombieNavMeshAgent.isStopped = false;
        // ownerZombie.zombieAnimator.SetBool(isDeadHash, false);

    }
}
