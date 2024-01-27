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
    
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    public void Look(Vector2 input)
    {
        float mouseX = input.x * Time.deltaTime;
        float mouseY = input.y * Time.deltaTime;

        //calculate camera rotation for looking up and down
        rotation -= mouseY * ySensitivity ;
        rotation = Mathf.Clamp(rotation, -80f, 80f);

        //apply this to camera transform
        cam.transform.localRotation = Quaternion.Euler(rotation, 0, 0);

        //rotate player to look left and right
        transform.Rotate(Vector3.up * (mouseX * xSensitivity));
    }
}