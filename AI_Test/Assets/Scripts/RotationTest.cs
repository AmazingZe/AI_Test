using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTest : MonoBehaviour
{
    public float timeToPlay;

    private float totalTime = 0;
    private Vector3 RotateValue = new Vector3(0, 60, 0);
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        totalTime += Time.deltaTime;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(RotateValue), totalTime / (timeToPlay == 0 ? 1 : timeToPlay));
    }
}
