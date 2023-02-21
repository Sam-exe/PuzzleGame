using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider : MonoBehaviour
{
    public LineRenderer lr;
    public BoxCollider2D bx1;
     //values for internal use
     private Quaternion _lookRotation;
     private Vector3 _direction;
     
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < lr.positionCount; i++)
        {
            
            Transform test = transform.GetChild(i);
            //Debug.Log(lr.GetPosition(I).x);
            test.position = lr.GetPosition(i);
            Vector3 vectorToTarget = lr.GetPosition(i+1) -  test.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        test.rotation = Quaternion.Slerp(test.rotation, q, Time.deltaTime * 100);

        }
        

    }
}
