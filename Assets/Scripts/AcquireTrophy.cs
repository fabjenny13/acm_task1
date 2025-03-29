using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class AcquireTrophy : MonoBehaviour
{ 
    [SerializeField]
    Transform hand_transform;
    TextMeshPro trophyacquireText;
    public bool isCollected = false;
    private void Start()
    {
        
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            transform.position = hand_transform.position;
            this.transform.parent = hand_transform.parent;
            Debug.Log("Trophy acquired!!!");
            isCollected = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Press E to Collect!");
        //trophyacquireText.enabled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        //trophyacquireText.enabled = false;
    }
}

