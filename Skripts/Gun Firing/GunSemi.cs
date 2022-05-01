using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSemi : MonoBehaviour
{
    public New_Weapon_Recoil_Script recoil;

    public Transform barrel;
    public float range = 0f;
    
    bool fired;

    void Update()
    {
        if(Input.GetButtonDown("Fire1") && !fired)
        {
            fired = true;
            StartCoroutine("FireSemi");
        }
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

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            recoil.Fire();
        }

        Debug.DrawRay(barrel.position, transform.forward * range, Color.red);
        yield return null;
        fired = false; 
    }
}
