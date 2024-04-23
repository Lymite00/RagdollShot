using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    [SerializeField] private Rigidbody _rb;

    public MeshRenderer meshObject;
    public SphereCollider collider;

    [SerializeField] private GameObject explosionSound;
    [SerializeField] private GameObject explosiveParticle;

    [SerializeField] private float forceAmount;
    private void Start()
    {
        meshObject = gameObject.GetComponentInChildren<MeshRenderer>();
        collider = gameObject.GetComponent<SphereCollider>();

        StartCoroutine(Explosion());
    }

    public void Init(float velocity) {
        _rb.velocity = transform.forward * velocity;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ragdoll"))
        {
            RagdollActivation ragdollActivation = other.gameObject.GetComponent<RagdollActivation>();
            if (ragdollActivation!=null)
            {
                ragdollActivation.EnableRagdoll();
                StartCoroutine(Explosion());
                StartCoroutine(SlowTime());
            }
        }
        else if (other.gameObject.CompareTag("Wall"))
        {
            RagdollActivation ragdollActivation = other.gameObject.GetComponent<RagdollActivation>();
            if (ragdollActivation!=null)
            {
                ragdollActivation.EnableRagdoll();
                StartCoroutine(Explosion());
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ragdoll"))
        {
            RagdollActivation ragdollActivation = other.gameObject.GetComponent<RagdollActivation>();
            if (ragdollActivation!=null)
            {
                ragdollActivation.EnableRagdoll();
                StartCoroutine(Explosion());
                StartCoroutine(SlowTime());
            }
        }
        else if (other.gameObject.CompareTag("Wall"))
        {
            RagdollActivation ragdollActivation = other.gameObject.GetComponent<RagdollActivation>();
            if (ragdollActivation!=null)
            {
                ragdollActivation.EnableRagdoll();
                StartCoroutine(Explosion());
            }
        }
    }


    private IEnumerator SlowTime()
    {
        Time.timeScale = 0.25f;
        yield return new WaitForSeconds(1f);
        Time.timeScale = 1f;
    }
    private IEnumerator Explosion()
    {
        yield return new WaitForSeconds(5f);
        meshObject.enabled = false;
        collider.enabled = false;

        Collider[] colliders = Physics.OverlapSphere(transform.position, collider.radius*5f);
        foreach (Collider hitCollider in colliders)
        {
            Rigidbody hitRigidbody = hitCollider.GetComponent<Rigidbody>();
            if (hitRigidbody != null && hitRigidbody != _rb)
            {
                Vector3 direction = hitRigidbody.transform.position - transform.position;
                hitRigidbody.AddForce(direction.normalized * forceAmount, ForceMode.Impulse);
            }
        }

        explosionSound.gameObject.SetActive(true);
        Instantiate(explosiveParticle, transform.position, Quaternion.Euler(-90f, 0f, 0f));
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
