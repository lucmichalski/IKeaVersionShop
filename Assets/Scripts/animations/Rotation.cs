using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
   // public float speed1 = 30f;
    public float speed1 = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      transform.Rotate(0, speed1 * Time.deltaTime, 0);
     // transform.Rotate(speed1 * Time.deltaTime, 0, 0);
     
    }
    
    public void AdjustXRotate(float newSpeed){
      speed1 = newSpeed;
}
}
