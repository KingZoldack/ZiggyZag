using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCheckpoints : MonoBehaviour
{
    //TutorialManager TutorialManager;

    protected static bool _atCheck1;

    private void Awake()
    {
        //TutorialManager = FindObjectOfType<TutorialManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"This should be false: {_atCheck1}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.GET_CHECK1_TAG)
        {
            _atCheck1 = true;
        }
    }

    public bool AtCheck()
    {
        return _atCheck1;
    }
}
