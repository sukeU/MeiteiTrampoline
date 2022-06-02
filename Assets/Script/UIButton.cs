using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIButton : MonoBehaviour
{
    [SerializeField] EventSystem eventSystem;
    Text text;

    // Start is called before the first frame update
    void Start()
    {

        eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        text = gameObject.transform.GetChild(0).GetComponent<Text>();
        // 色を指定
        text.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
     
    }

    // Update is called once per frame
    void Update()
    {
        if (AllManager.Instance.nowState == AllManager.gameState.idel)
        {
            if (eventSystem.currentSelectedGameObject.gameObject == this.gameObject)
            {
               
                text.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            }
            else
            {
                text.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            }

        }
    }

    public void Sound()
    {
        AllManager.Instance.PlaySeByName("ボタン");
    }
    public void returnSound()
    {
        AllManager.Instance.PlaySeByName("キャンセル2");
    }
}
