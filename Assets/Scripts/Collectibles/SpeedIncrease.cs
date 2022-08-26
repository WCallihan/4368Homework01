using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedIncrease : CollectibleBase {

    [SerializeField] private float speedMultiplier = 0.5f;

    protected override void Collect(Player player) {
        TankController controller = player.GetComponent<TankController>();
        if(controller != null) {
            controller.MaxSpeed += speedMultiplier;
        }
    }

    protected override void Movement(Rigidbody rb) {
        Quaternion turnOffset = Quaternion.Euler(MovementSpeed, MovementSpeed, MovementSpeed);
        rb.MoveRotation(rb.rotation * turnOffset);
    }
}