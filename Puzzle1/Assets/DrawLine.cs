using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public GameObject finger0;
    public GameObject finger1;
    public GameObject finger2;
    public GameObject finger3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LineRenderer

        LineRenderer.SetPosition(0, finger0.transform.GetChild(1).position);
        LineRenderer. (1, new Vector3(finger0.transform.GetChild(1).position.x, finger0.transform.GetChild(1).position.y, -1));
        Debug.DrawRay(finger0.transform.GetChild(1).position,finger0.transform.GetChild(1).position, Color.black);
        
    }
}
