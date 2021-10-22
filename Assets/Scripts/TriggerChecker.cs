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
        _platformRenderer.material = _galaxyMat;

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Invoke("FallDown", 0.2f);
        }
    }

    void FallDown()
    {
        _platformRenderer.material = _crackedGalaxyMat;
        GetComponentInParent<Rigidbody>().useGravity = true;
        GetComponentInParent<Rigidbody>().isKinematic = false;
        Destroy(transform.parent.gameObject, 1.5f);
    }
}
