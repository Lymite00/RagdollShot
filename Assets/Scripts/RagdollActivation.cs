using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollActivation : MonoBehaviour
{
    public Rigidbody[] Rigidbodies;

    public BoxCollider collider;
    public Animator Animator;
    private void Awake()
    {
        Rigidbodies = GetComponentsInChildren<Rigidbody>();
        DisableRagdoll();
    }

    public void EnableRagdoll()
    {
        foreach (var rigidbody in Rigidbodies)
        {
            rigidbody.isKinematic = false;
        }

        Animator.enabled = false;
        collider.enabled = false;
    }
    public void DisableRagdoll()
    {
        foreach (var rigidbody in Rigidbodies)
        {
            rigidbody.isKinematic = true;
        }
        Animator.enabled = true;
        collider.enabled = true;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ragdoll"))
        {
            EnableRagdoll();
        }
    }
}
