using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LeanBoth : MonoBehaviour
{
	//Input settings
    public KeyCode leanLeftKey;
	public KeyCode leanRightKey;

    //Leaning
    public Transform Normal;
	public Transform Lean_Right;
    public Transform Lean_Left;

	//Smoothing
    public float LeanSmoothing = 10;

	//private vars
	private int curAim = 0;

    // Update is called once per frame
    void Update()
    {
		AimInput();
        DetermineAim();
        DetermineLean();
    }
	//Determine aim from player
	private void AimInput()
	{
		curAim = 0;
		if(Input.GetKey(leanLeftKey)) curAim += 1;
		if(Input.GetKey(leanRightKey)) curAim -= 1;
	}

	//Move cam to position
    private void DetermineAim()
    {
        Vector3 target = Normal.position;
        if(curAim == -1)
            target = Lean_Right.position;
		else if(curAim == 1)
			target = Lean_Left.position;
		

		transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * LeanSmoothing);
    }

	//rotation cam
    private void DetermineLean()
    {
        Quaternion target = Normal.localRotation;
        if(curAim == -1)
            target = Lean_Right.localRotation;
		else if(curAim == 1)
			target = Lean_Left.localRotation;

        transform.localRotation = Quaternion.Lerp(transform.localRotation, target, Time.deltaTime * LeanSmoothing);
    }
}