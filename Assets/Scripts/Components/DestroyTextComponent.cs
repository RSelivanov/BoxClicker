using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DestroyTextComponent : DestroyComponent
{
    protected override void ChangeTransparent()
    {
        color.a -= transparentSpeed * Time.deltaTime;
        color.a = Mathf.Clamp(color.a, 0, 1);

        if (transform.GetComponent<TextMeshPro>() != null)
        {
            transform.GetComponent<TextMeshPro>().color = color;
        }
        if (transform.childCount > 0)
        {
            foreach (Transform obj in transform)
            {
                obj.GetComponent<TextMeshPro>().color = color;
            }
        }
    }
}
