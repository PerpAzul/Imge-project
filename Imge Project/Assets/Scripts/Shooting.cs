using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    //Camera and Bullet variables
    [SerializeField] private Camera fpsCam;
    [SerializeField] private float range;
    public int maxAmmo = 10;
    public float currentAmmo;
    public float reloadTime = 1f;
    public bool isReloading = false;
    
    //Particle System
    [SerializeField] private ParticleSystem flash;
    
    //Courutine
    private Coroutine reloadCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnEnable()
    {
        isReloading = false;
    }

    public void Shoot()
    {
        if (isReloading)
        {
            return;
        }
        
        if (currentAmmo > 0)
        {
            currentAmmo--;
            flash.Play();
            RaycastHit hit;
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {
                
            }
        }
    }
    
    IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isReloading = false;
    }
    
    public void doShoot(InputAction.CallbackContext obj)
    {
        if (obj.performed)
        {
            Shoot();
        }
    }
    
    public void doReload(InputAction.CallbackContext obj)
    {
        if (reloadCoroutine != null){
            StopCoroutine(reloadCoroutine);
        }

        reloadCoroutine = StartCoroutine(Reload());
    }
    
}
