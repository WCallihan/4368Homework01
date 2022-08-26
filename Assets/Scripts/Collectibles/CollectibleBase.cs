using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CollectibleBase : MonoBehaviour {

    [SerializeField] private float movementSpeed = 1;
    protected float MovementSpeed => movementSpeed;
    [SerializeField] private ParticleSystem collectParticles;
    [SerializeField] private AudioClip collectSound;
    private Rigidbody rb;

    protected abstract void Collect(Player player);

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        Movement(rb);
    }

    private void OnTriggerEnter(Collider other) {
        Player player = other.gameObject.GetComponent<Player>();
        if(player != null) {
            Collect(player);
            Feedback();
            gameObject.SetActive(false);
        }
    }

    protected virtual void Movement(Rigidbody rb) {
        Quaternion turnOffset = Quaternion.Euler(0, movementSpeed, 0);
        rb.MoveRotation(rb.rotation * turnOffset);
    }
    
    private void Feedback() {
        //particles
        if(collectParticles != null) {
            collectParticles = Instantiate(collectParticles, transform.position, Quaternion.identity);
        }
        //audio
        if(collectSound != null) {
            AudioHelper.PlayClip2D(collectSound, 1);
        }
    }
}