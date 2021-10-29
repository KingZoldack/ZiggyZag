using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChecker : MonoBehaviour
{
    [SerializeField] Material _galaxyMat;
    [SerializeField] Material _crackedGalaxyMat;
    [SerializeField] MeshRenderer _platformRenderer;

    private void Awake()
    {
        _platformRenderer.material = _galaxyMat; //Sets platform material.
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == Tags.GET_PLAYER_TAG)
        {
            Invoke(nameof(FallDown), 0.2f);
        }
    }

    void FallDown()
    {
        _platformRenderer.material = _crackedGalaxyMat; //Changes platform material after player passes over it.
        GetComponentInParent<Rigidbody>().useGravity = true;
        GetComponentInParent<Rigidbody>().isKinematic = false;
        Destroy(transform.parent.gameObject, 1.5f);
    }
}
