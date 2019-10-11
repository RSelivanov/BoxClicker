using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class DestroyComponent : MonoBehaviour
{
    [SerializeField] protected float DestroySeconds = 5f;
    [SerializeField] protected bool isVanishing;
    [SerializeField] protected Color color = new Color(1, 1, 1, 1);
    [SerializeField] protected float transparentSpeed = 1f; // Задает скорость изменения цвета в единицах в секунду.

    void Start()
    {
        StartCoroutine(DestroyObject());
    }

    void Update()
    {
        if(isVanishing) ChangeTransparent();
    }

    protected abstract void ChangeTransparent();

    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(DestroySeconds);
        Destroy(transform.gameObject);
    }

}
