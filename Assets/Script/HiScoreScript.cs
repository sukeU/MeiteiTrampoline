using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiScoreScript : MonoBehaviour
{
    Text HiScoreText;
    int HiScore;

    // Start is called before the first frame update
    void Start()
    {
        HiScoreText = gameObject.GetComponent<Text>();
        HiScore = PlayerPrefs.GetInt("HiScore",0);
        if (HiScore< AllManager.Instance.accessScore)
        {
            HiScore = AllManager.Instance.accessScore;
            PlayerPrefs.SetInt("HiScore", HiScore);
        }
        HiScoreText.text = "HiScore : " + HiScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
