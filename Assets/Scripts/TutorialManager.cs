using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] GameObject _startText;
    [SerializeField] Animator _anim;
    [SerializeField] PlayableDirector playableDirector;

    private void Update()
    {
        DeactivateText();
        if (Time.time >= 5f)
        {
            playableDirector.Pause();
        }

    }

    public void DeactivateText()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _anim.SetBool(Tags.GET_START_GAME_TAG, true);
            //_startText.gameObject.SetActive(false);
        }
    }
}
