using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpawnObjects : MonoBehaviour
{
    public bool On = false;
    public GameObject prefab;
    public Button yourButton;

    // Start is called before the first frame update
    void Start()
    {
        //Button btn = yourButton.GetComponent<Button>();
		//btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
    } 
    public void TaskOnClick(){
        Instantiate(prefab,new Vector3(1,8), Quaternion.identity);
    }
}
