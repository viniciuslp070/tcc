using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform interactionPoint;
    [SerializeField] private float interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask interactableMask;

    private readonly Collider[] colliders = new Collider[3];
    [SerializeField] private int numFound;

    private void Update()
    {
        numFound = Physics.OverlapSphereNonAlloc(interactionPoint.position, interactionPointRadius, colliders, interactableMask);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactionPoint.position, interactionPointRadius);
    }
    
}
