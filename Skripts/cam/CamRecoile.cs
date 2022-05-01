using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRecoile : MonoBehaviour
{
    public KeyCode RecoilKey;
    public Transform Camera;
    public Transform Normal;
	public Transform Recoil;
    public float LeanSmoothing = 10;
    private int curAim = 0;

    // Update is called once per frame
    void Update()
    {
        AimInput();
        DetermineAim();
    }

    private void AimInput()
	{
		curAim = 0;
		if(Input.GetKey(RecoilKey)) curAim += 1;
	}

    //Move cam to position
    private void DetermineAim()
    {
        Vector3 target = Normal.position;
        if(curAim == -1)
            target = Recoil.position;
		
		transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * LeanSmoothing);
    }

    //rotation cam
    private void DetermineLean()
    {
        Quaternion target = Normal.localRotation;
        if(curAim == -1)
            target = Recoil.localRotation;

        transform.localRotation = Quaternion.Lerp(transform.localRotation, target, Time.deltaTime * LeanSmoothing);
    }
}
