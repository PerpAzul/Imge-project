using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;


public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    private float rotation;

    public float xSensitivity = 30f;
    public float ySensitivity = 30f;
    
    private bool _canUsePowers = true;
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    public void Look(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        //calculate camera rotation for looking up and down
        rotation -= mouseY * ySensitivity;
        rotation = Mathf.Clamp(rotation, -80f, 80f);

        //apply this to camera transform
        cam.transform.localRotation = Quaternion.Euler(rotation, 0, 0);

        //rotate player to look left and right
        transform.Rotate(Vector3.up * mouseX * xSensitivity);
    }
    
    public void GravityPush()
    {
        if (_canUsePowers)
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit,
                    15f))
            {
                var hitGameObject = hit.collider.gameObject;
                if (hitGameObject.CompareTag("Enemy"))
                {
                    Debug.Log("Push Hit");
                    var rigidbody = hitGameObject.GetComponent<Rigidbody>();
                    var distance = Vector3.Distance(transform.position, rigidbody.transform.position);
                    Debug.Log(distance);
                    switch (distance)
                    {
                        case <= 5f:
                            rigidbody.AddForce((rigidbody.transform.position - transform.position).normalized * 7500f,
                                ForceMode.Force);
                            break;
                        case > 5f and <= 10f:
                            rigidbody.AddForce((rigidbody.transform.position - transform.position).normalized * 3500f,
                                ForceMode.Force);
                            break;
                        case > 10f and < 15f:
                            rigidbody.AddForce((rigidbody.transform.position - transform.position).normalized * 1500f,
                                ForceMode.Force);
                            break;
                    }

                    //Cooldown
                    StartCoroutine(StartCountdown(5));
                }
            }
            else
            {
                StartCoroutine(StartCountdown(1));
            }
        }
        else
        {
            return;
        }

        Debug.Log("No Hit");
    }
    
    private IEnumerator StartCountdown(int time)
    {
        _canUsePowers = false;
        yield return new WaitForSeconds(time);
        _canUsePowers = true;
        Debug.Log("End of StartCountdown");
    }
}