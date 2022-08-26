using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerupBase : MonoBehaviour {

    [SerializeField] private float powerupDuration;
    [SerializeField] private ParticleSystem collectParticles;
    [SerializeField] private AudioClip collectSound;
    private Player player;
    private MeshRenderer mesh;
    private Collider powerupCollider;
    private bool poweredUp;
    private float powerupTimer;

    protected abstract void PowerUp(Player player);
    protected abstract void PowerDown(Player player);

    private void Awake() {
        mesh = GetComponent<MeshRenderer>();
        powerupCollider = GetComponent<Collider>();
        poweredUp = false;
    }

    private void Update() {
        powerupTimer -= Time.deltaTime;
        if(powerupTimer <= 0 && poweredUp) {
            PowerDown(player);
            poweredUp = false;
        }
    }

    private void OnTriggerEnter(Collider other) {
        player = other.gameObject.GetComponent<Player>();
        if(player != null) {
            PowerUp(player);
            powerupTimer = powerupDuration;
            poweredUp = true;
            Feedback();
        }
    }

    private void Feedback() {
        //turn off visuals
        mesh.enabled = false;
        powerupCollider.enabled = false;
        //particles
        if(collectParticles != null) {
            collectParticles = Instantiate(collectParticles, transform.position, Quaternion.identity);
        }
        //audio
        if(collectSound != null) {
            AudioHelper.PlayClip2D(collectSound, 1);
        }
    }

    protected void DestroyPowerup() {
        gameObject.SetActive(false);
    }
}