using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1 : MonoBehaviour
{
    [SeriallizeField]int mover = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player();
    }
    void player()
    {
        float xValue = Input.GetAxis("Horizonal") * Time.deltaTime * mover;
        float zValue = Input.GetAxis("Vertical") * Time.deltaTime * mover;
        transform.Translate(xValue,0,zValue);
    }
}
