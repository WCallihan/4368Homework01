using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincibility : PowerupBase {

    protected override void PowerUp(Player player) {
        player.MakeInvincible();
    }

    protected override void PowerDown(Player player) {
        player.MakeNotInvincible();
    }
}