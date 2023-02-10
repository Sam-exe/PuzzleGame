//Attach this script to an empty GameObject
//Create some UI Text by going to Create>UI>Text.
//Drag this GameObject into the Text field to the Inspector window of your GameObject.

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class TouchPhaseExample : MonoBehaviour
{
    public Vector2 startPos;
    public Vector2 direction;
    public Vector2 direction2;

    public Vector2 worldPosition;
    public Text m_Text2;
    public Text m_Text;
    string message;
    public GameObject Prefab;
    public GameObject Prefab1;
    public GameObject Prefab2;
    public GameObject Prefab3;
    public List<GameObject> prprp = new List<GameObject>();
    public List<Transform> parentlist = new List<Transform>();
    public List<GameObject> finger0 = new List<GameObject>();
    public List<int> finger1 = new List<int>();
    public List<GameObject> finger2 = new List<GameObject>();
    public List<GameObject> finger3 = new List<GameObject>();
    public GameObject parent;
    public GameObject parent1;
    public GameObject parent2;
    public GameObject parent3;


    public List<int> test2 = new List<int>();
    public List<GameObject> test3 = new List<GameObject>();


    public GameObject test;
    

    
    void Update()
    {
        //Update the Text on the screen depending on current TouchPhase, and the current direction vector
        m_Text.text = "Touch : " + startPos + "in direction" + direction;
        Debug.Log(finger0.Count);
        foreach(Touch touch in Input.touches)
        {
            worldPosition = Camera.main.ScreenToWorldPoint(touch.position);
            int numChildren = parentlist[touch.fingerId].transform.childCount;             // get child count
            GameObject test = Instantiate(prprp[touch.fingerId], new Vector3(worldPosition.x, worldPosition.y, -1), Quaternion.identity, parentlist[touch.fingerId]);
            Destroy(parentlist[touch.fingerId].transform.GetChild(numChildren - 1).gameObject);
            // }
        }

        
        
        // Track a single touch as a direction control.
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            transform.position = new Vector2(direction.x / Screen.height, direction.y / Screen.width);
            //Touch test = Input.tou
            // Handle finger movements based on TouchPhase
            switch (touch.phase)
            {
                //When a touch has first been detected, change the message and record the starting position
                case TouchPhase.Began:
                    // Record initial touch position.
                    startPos = touch.position;
                    message = "Begun ";
                    break;

                //Determine if the touch is a moving touch
                case TouchPhase.Moved:
                    direction2 = touch.position;
                    // Determine direction by comparing the current touch position with the initial one
                    direction = touch.position - startPos;
                    message = "Moving ";
                    break;

                case TouchPhase.Ended:
                    // Report that the touch has ended when it ends
                    message = "Ending ";
                    break;
            }
        }
    }
}
        