using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour {

    [SerializeField] private int damageAmount = 1;
    [SerializeField] private ParticleSystem impactParticles;
    [SerializeField] private AudioClip impactSound;
    private Rigidbody rb;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        Move();
    }

    public void Move() {
        
    }

    private void OnCollisionEnter(Collision collision) {
        Player player = collision.gameObject.GetComponent<Player>();
        if(player != null) {
            PlayerImpact(player);
            ImpactFeedback();
        }
    }

    protected virtual void PlayerImpact(Player player) {
        player.DecreaseHealth(damageAmount);
    }

    private void ImpactFeedback() {
        //particles
        if(impactParticles != null) {
            impactParticles = Instantiate(impactParticles, transform.position, Quaternion.identity);
        }
        //audio
        if(impactSound != null) {
            AudioHelper.PlayClip2D(impactSound, 1);
        }
    }
}