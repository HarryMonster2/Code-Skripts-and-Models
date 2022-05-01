using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aming : MonoBehaviour
{
//Aiming
    public Vector3 normalLocalPosition;
    public Vector3 normalLocalRotation;
    public Vector3 aimingLocalPosition;
    public Vector3 LeaningLocalRotation;
    public float aimSmoothing = 10;

//store current eulers
	private Vector3 curEulers = Vector3.zero;

// Update is called once per frame
    void Update()
    {
        DetermineAim();
        DetermineLean();
    }

    private void DetermineAim()
    {
        Vector3 target = normalLocalPosition;
        if (Input.GetMouseButton(1)) 
            target = aimingLocalPosition;

        Vector3 desiredPosition = Vector3.Lerp(transform.localPosition, target, Time.deltaTime * aimSmoothing);

        transform.localPosition = desiredPosition;
    }
//rotation cam
    private void DetermineLean()
    {
        Vector3 target = normalLocalRotation;
        if(Input.GetMouseButton(1))
            target = LeaningLocalRotation;
        curEulers = Vector3.Lerp(curEulers, target, Time.deltaTime * aimSmoothing);

        transform.localRotation = Quaternion.Euler(curEulers);
    }
}
