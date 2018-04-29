using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationAnimation : MonoBehaviour {

    [SerializeField]
    private float rotationPerSecond;
	
	void Update () {
        transform.rotation *= Quaternion.Euler(0, 0, rotationPerSecond * Time.deltaTime);
	}
}
