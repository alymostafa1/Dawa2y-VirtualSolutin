using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circular_motion : MonoBehaviour
{
    public GameObject skeleton; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        skeleton.transform.Rotate(0, 5 , 0);
    }
}
