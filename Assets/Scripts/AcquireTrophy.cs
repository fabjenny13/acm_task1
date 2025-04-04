using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class AcquireTrophy : MonoBehaviour
{ 
    [SerializeField]
    Transform hand_transform;
    public TextMeshProUGUI trophyacquireText;
    public bool isCollected = false;
    private bool canCollect = false;

    private void Start()
    {
        trophyacquireText.gameObject.SetActive(false);
    }
    private void Update()
    {

        if(transform.parent == null)
        {
            GetComponent<BoxCollider>().isTrigger = true;
        }

        if (Input.GetKeyDown(KeyCode.E) && canCollect)
        {
            transform.position = hand_transform.position;
            this.transform.parent = hand_transform.parent;
            isCollected = true;
            CloseTip();
            GetComponent<BoxCollider>().isTrigger = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //check if player is looking at trophy

        /**
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0,0,0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject == gameObject)
            {
                OpenTip();
            }
        }
        **/

        OpenTip();
    }

    private void OnTriggerExit(Collider other)
    {
        CloseTip();
    }

    void OpenTip()
    {
        canCollect = true;
        trophyacquireText.gameObject.SetActive(true);
    }

    void CloseTip()
    {
        canCollect = false;
        trophyacquireText.gameObject.SetActive(false);
    }



}

