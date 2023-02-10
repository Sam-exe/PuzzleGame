using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfDestruct : MonoBehaviour
{
    public GameObject me;
    public float timeToDestroy = 2;
    public bool doDistroy = true;
    // Start is called before the first frame update
    void Start()
    {
        if (doDistroy){
            //Destroy(me, timeToDestroy);
        }
        
    }
}
