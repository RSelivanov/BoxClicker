using System.Collections;
using UnityEngine;

public class GunDamageComponent : BoxClickerElement
{
    //Stages
    private bool block;

    public float damage;
    private float coolDown;
    private float countDown;
    private float rayCoolDown;
    private float countDownRay;

    private BoxController boxController;
    private GameObject ray_01;
    private GameObject ray_02;
    private GameObject ray_03;

    void Start()
    {
        countDown = coolDown;
        countDownRay = 1;
        // boxController = GameObject.Find("Box").GetComponent<BoxController>();

        ray_01 = transform.GetChild(0).gameObject;
        ray_02 = transform.GetChild(1).gameObject;
        ray_03 = transform.GetChild(2).gameObject;

        StartCoroutine(TimerSecond());
    }

    public void SetBlock()
    {
        block = true;
    }
    public void UnSetBlock()
    {
        block = false;
    }

    public void SetDamage(float damage){ this.damage = damage; }
    public float GetDamage() { return this.damage; }

    public void SetCoolDown(float coolDown) { this.coolDown = coolDown; }
    public float GetCoolDown() { return this.coolDown; }


    IEnumerator TimerSecond()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);//milisecond
            GiveDamage();
        }
    }

    private void GiveDamage()
    {
        if (countDownRay > 0) countDownRay -= 0.1f;
        if (countDownRay <= 0)
        {
            ray_01.SetActive(false);
            ray_02.SetActive(false);
            ray_03.SetActive(false);
        }

        if (countDown > 0) countDown -= 0.1f;
        if (countDown <= 0)
        {
            if (block == false)
            {
                app.controller.boxController.Click(damage);
                countDown = coolDown;

                countDownRay = 1;
                //ray_01.SetActive(true);
                //ray_02.SetActive(true);
                //SoundManager.use.Play("Laser_01", 1);
                SoundManager.use.PlaySound("Laser_01", 1.0f);
                StartCoroutine(RayFlasher());
            }
        }
       
    }
    IEnumerator RayFlasher()
    {
        ray_01.SetActive(true);
        yield return new WaitForSeconds(0.1f);//milisecond
        ray_01.SetActive(false);
        ray_02.SetActive(true);
        yield return new WaitForSeconds(0.1f);//milisecond
        ray_02.SetActive(false);
        ray_03.SetActive(true);
        yield return new WaitForSeconds(0.1f);//milisecond
        ray_03.SetActive(false);
    }
}
