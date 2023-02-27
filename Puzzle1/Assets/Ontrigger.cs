using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ontrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject test;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player"){
            Debug.Log("touched");
            test.SetActive(true);
            StartCoroutine(VictoryDelay());
        }
    }
    
    IEnumerator VictoryDelay(){
        yield return new WaitForSeconds(3);
        test.SetActive(false);
    }
}
