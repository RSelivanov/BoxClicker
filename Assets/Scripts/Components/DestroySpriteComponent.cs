using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySpriteComponent : DestroyComponent
{
    protected override void ChangeTransparent()
    {
        color.a -= transparentSpeed * Time.deltaTime;
        color.a = Mathf.Clamp(color.a, 0, 1);

        if(transform.GetComponent<SpriteRenderer>() != null)
        {
            transform.GetComponent<SpriteRenderer>().color = color;
        }
        if (transform.childCount > 0)
        {
            foreach (Transform obj in transform)
            {
                obj.GetComponent<SpriteRenderer>().color = color;
            }
        }
    }
}
