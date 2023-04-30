using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    public bool blocked = false;
    [SerializeField]
    SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer.enabled= false;
    }
    public void playerBlock()
    {
        StartCoroutine(blocking());
    }

    public IEnumerator blocking()
    {
        blocked= true;
        spriteRenderer.enabled = true;
        yield return new WaitForSeconds(1.3f);
        blocked= false;
        spriteRenderer.enabled = false;
    }
}
