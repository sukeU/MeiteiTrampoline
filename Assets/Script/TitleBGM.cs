using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBGM : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AllManager.Instance.PlayBgmByName("Title");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void stop()
    {
        AllManager.Instance.StopBgm();
    } 
}
