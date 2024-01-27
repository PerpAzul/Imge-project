using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;


public class PlayerLook : MonoBehaviour
{
    public static float sensitivityScale = 1;
    public Camera cam;
    private float rotation;

    public float xSensitivity = 30f;// * sensitivityScale;
    public float ySensitivity = 30f;// * sensitivityScale;
    
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Debug.Log("Sensitivity: " + sensitivityScale);
    }
    
    public void Look(Vector2 input)
    {
        float mouseX = input.x * Time.deltaTime;
        float mouseY = input.y * Time.deltaTime;

        //calculate camera rotation for looking up and down
        rotation -= mouseY * ySensitivity * sensitivityScale;
        rotation = Mathf.Clamp(rotation, -80f, 80f);

        //apply this to camera transform
        cam.transform.localRotation = Quaternion.Euler(rotation, 0, 0);

        //rotate player to look left and right
        transform.Rotate(Vector3.up * (mouseX * xSensitivity * sensitivityScale));
    }
}