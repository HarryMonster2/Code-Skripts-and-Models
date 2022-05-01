using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSwitch : MonoBehaviour
{
    public New_Weapon_Recoil_Script recoil;

    public Transform barrel;
    public float range = 0f;
    
    public float delay = 0f;
    bool fired;

    bool isAuto;
    public KeyCode switchFireMode;

    void Update()
    {
        if(Input.GetButton("Fire1") && !fired && isAuto)
        {
            fired = true;
            StartCoroutine("FireAuto");
        }

        if(Input.GetButtonDown("Fire1") && !fired && !isAuto)
        {
            fired = true;
            StartCoroutine("FireSemi");
        }

        if(Input.GetKeyDown(switchFireMode))
        {
            if(!isAuto)
            {
                isAuto = true;
            }

            else
            {
                isAuto = false;
            }
        }
    }

    IEnumerator FireAuto()
    {
        RaycastHit hit;
        Ray ray = new Ray(barrel.position, transform.forward);

        if(Physics.Raycast(ray, out hit, range))
        {
            if(hit.collider.tag == "Enemy")
            {
                Enemy enemy = hit.collider.GetComponent<Enemy>();
                enemy.health -= 1;
            }
        }

        if(Input.GetKey(KeyCode.Mouse0) && isAuto)
        {
            recoil.Fire();
        }

        Debug.DrawRay(barrel.position, transform.forward * range, Color.yellow);
        yield return new WaitForSeconds(delay);
        fired = false; 
    }

    IEnumerator FireSemi()
    {
        RaycastHit hit;
        Ray ray = new Ray(barrel.position, transform.forward);

        if(Physics.Raycast(ray, out hit, range))
        {
            if(hit.collider.tag == "Enemy")
            {
                Enemy enemy = hit.collider.GetComponent<Enemy>();
                enemy.health -= 1;
            }
        }

        if(Input.GetKeyDown(KeyCode.Mouse0) && !isAuto)
        {
            recoil.Fire();
        }

        Debug.DrawRay(barrel.position, transform.forward * range, Color.red);
        yield return null;
        fired = false; 
    }
}
