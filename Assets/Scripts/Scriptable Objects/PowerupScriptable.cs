using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Powerup", menuName = "Items/Powerup", order = 2)]

public class PowerupScriptable : ConsumableScriptable
{
    public override void UseItem(PlayerController playerController)
    {
        if (playerController.movementComponent.speedBoost) return;
        playerController.movementComponent.speedBoost = true;
        playerController.movementComponent.PlayParticles();

        base.UseItem(playerController);
    }
}