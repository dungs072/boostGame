using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillate : MonoBehaviour
{
    Vector3 startPosition ;
    [SerializeField] Vector3 movementVector;
    [SerializeField][Range(0,1)] float movementFactor;
    [SerializeField] float period = 2f;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        Debug.Log(startPosition);
    }

    // Update is called once per frame
    void Update()
    {
        if(period<Mathf.Epsilon){
            return;
        }
        float cycles = Time.time/period;
        const float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(cycles * tau);
        movementFactor = (rawSinWave +1f) / 2f;
        Vector3 offset = movementVector*movementFactor;
        transform.position = offset + startPosition;   
    }
}
