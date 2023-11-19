using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting2 : MonoBehaviour
{
    //Camera and Bullet variables
    [SerializeField] private Camera fpsCam;
    [SerializeField] private float range;
    public int maxAmmo = 10;
    public float currentAmmo2;
    public float reloadTime = 1f;
    public bool isReloading = false;
    
    //Particle System
    [SerializeField] private ParticleSystem flash;
    
    //Courutine
    private Coroutine reloadCoroutine;
    
    // Start is called before the first frame update
    void Start()
    {
        currentAmmo2 = maxAmmo;
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
        
        if (currentAmmo2 > 0)
        {
            currentAmmo2--;
            flash.Play();
            RaycastHit hit;
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {
                
            }
        }
    }
    
    IEnumerator Reload2()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        currentAmmo2 = maxAmmo;
        isReloading = false;
    }
    
    public void doShoot2(InputAction.CallbackContext obj)
    {
        if (obj.performed)
        {
            Shoot();
        }
    }
    
    public void doReload2(InputAction.CallbackContext obj)
    {
        if (reloadCoroutine != null){
            StopCoroutine(reloadCoroutine);
        }

        reloadCoroutine = StartCoroutine(Reload2());
    }
}
