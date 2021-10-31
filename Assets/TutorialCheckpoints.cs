using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCheckpoints : MonoBehaviour
{
    //TutorialManager TutorialManager;

    protected static bool _atCheck1;
    protected static bool _atCheck2;
    protected static bool _atCheck3;
    protected static bool _atCheck4;
    protected static bool _atEnd;

    private void Awake()
    {
        //TutorialManager = FindObjectOfType<TutorialManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
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

        if (other.tag == Tags.GET_CHECK2_TAG)
        {
            _atCheck2 = true;
        }

        if (other.tag == Tags.GET_CHECK3_TAG)
        {
            _atCheck3 = true;
        }

        if (other.tag == Tags.GET_CHECK4_TAG)
        {
            _atCheck4 = true;
        }

        if (other.tag == Tags.GET_END_GOAL_TAG)
        {
            _atEnd = true;
        }
    }

    public bool AtCheck()
    {
        return _atCheck1;
    }
}
