using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    [Range(30, 200)]
    [SerializeField] private float sensitivity;

    [SerializeField] private Transform playerBody;

    private float xRotation = 0f;

	private void Start()
	{
        Cursor.lockState = CursorLockMode.Locked;
	}

	// Update is called once per frame
	void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}