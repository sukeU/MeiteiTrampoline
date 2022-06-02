using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectableCubeScript : MonoBehaviour
{
    [SerializeField] EventSystem eventSystem;
    GameObject selectedObj;
    GameObject left,right;
    GameObject Lcube, Rcube;
    // Start is called before the first frame update
    void Start()
    {
        AllManager.Instance.PlayBgmByName("Result");
        left  = GameObject.Find("RetryButton").transform.gameObject;
        right = GameObject.Find("TitleButton").transform.gameObject;
        Lcube = GameObject.Find("LeftCube").transform.gameObject;
        Rcube = GameObject.Find("RightCube").transform.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            selectedObj = eventSystem.currentSelectedGameObject.gameObject;
            if (selectedObj == left)
            {
              
                Lcube.SetActive(true);
                Rcube.SetActive(false);
            }
            else if (selectedObj == right)
            {
             
                Lcube.SetActive(false);
                Rcube.SetActive(true);

            }
        }catch(NullReferenceException)
        {
            Lcube.SetActive(false);
            Rcube.SetActive(false);
        }
      
    }
    public void Sound()
    {
        AllManager.Instance.PlaySeByName("ƒ{ƒ^ƒ“");
    }
}
