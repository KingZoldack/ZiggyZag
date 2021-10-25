using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeSprites : MonoBehaviour
{
    [SerializeField] Sprite[] randomSpritesSprites;

    SpriteRenderer spriteRenderer;

    private void Awake()
    {
       spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        StartCoroutine(ChangeSpriteRoutine());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator ChangeSpriteRoutine()
    {
        while (true)
        {
            foreach (var sprite in randomSpritesSprites)
            {
                spriteRenderer.sprite = sprite;

                yield return new WaitForSeconds(1f);
            }
        }
    }
}
