using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public bool onorof = false;
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (onorof){
            for (int i = 0; i < 20; i++)
            {
                Instantiate(prefab,transform.position, Quaternion.identity);
            }
        }
    } 
}
