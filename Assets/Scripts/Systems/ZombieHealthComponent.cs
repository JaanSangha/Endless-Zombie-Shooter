using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealthComponent : HealthComponent
{ 
    StateMachine zombieStateMachine;
    public MechanicsManager mechManager;

    // Start is called before the first frame update
    private void Awake()
    {
        zombieStateMachine = GetComponent<StateMachine>();
        mechManager = FindObjectOfType<MechanicsManager>();
    }

    public override void Destroy()
    {
        zombieStateMachine.ChangeState((ZombieStateType.IsDead));
    }

    private void Update()
    {
        if (CurrentHealth < 1)
        {
            mechManager.KilledZombie();
            zombieStateMachine.ChangeState((ZombieStateType.IsDead));
            Destroy(GetComponent<ZombieHealthComponent>());
        }
    }
}
