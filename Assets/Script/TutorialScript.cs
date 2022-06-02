using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
public class TutorialScript : MonoBehaviour
{
    [SerializeField] EventSystem eventSystem;
    GameObject[] pageObj = new GameObject[5];
    int page;
    GameObject nextButton,returnButton,homeButton;

    // Start is called before the first frame update
    void Start()
    {
        page = 0;
        pageObj[0] = gameObject.transform.GetChild(2).gameObject;
        pageObj[1] = gameObject.transform.GetChild(3).gameObject;
        pageObj[2] = gameObject.transform.GetChild(4).gameObject;
        pageObj[3] = gameObject.transform.GetChild(5).gameObject;
        pageObj[4] = gameObject.transform.GetChild(6).gameObject;
        nextButton = gameObject.transform.Find("NextButton").gameObject;
        returnButton = gameObject.transform.Find("ReturnButton").gameObject;
        homeButton = gameObject.transform.Find("TitleButton").gameObject;
        Debug.Log(pageObj);
        pageObj[0].SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        if (page == 0)
        {
            try
            {
                if (eventSystem.currentSelectedGameObject.gameObject == returnButton)
                {
                    EventSystem.current.SetSelectedGameObject(homeButton);
                }
            }
            catch (NullReferenceException)
            {

            }
            returnButton.SetActive(false);
        }
        else
        {
            returnButton.SetActive(true);
        }
        if (page == 4)
        {
            try
            {
                if (eventSystem.currentSelectedGameObject.gameObject == nextButton)
                {
                    EventSystem.current.SetSelectedGameObject(homeButton);
                }
            }
            catch (NullReferenceException)
            {

            }
            nextButton.SetActive(false);
        }
        else
        {
            nextButton.SetActive(true);
        }
    }
    public void increasePage()
    {
        page += 1;
        pageObj[page].SetActive(true);
        pageObj[page-1].SetActive(false);
        Debug.Log(page);
    }
    public void decreasePage()
    {
        if (page > 0)
        {
            page -= 1;
            pageObj[page].SetActive(true);
            pageObj[page + 1].SetActive(false);
        }
        Debug.Log(page);
    }
    public void Sound()
    {
        AllManager.Instance.PlaySeByName("ボタン");
    }
    public void HomeSound()
    {
        AllManager.Instance.PlaySeByName("ホーム");
    }
}
