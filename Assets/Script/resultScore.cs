using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resultScore : MonoBehaviour
{
    Text scoreText;
    int score;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = gameObject.GetComponent<Text>();
        score =AllManager.Instance.accessScore;
        scoreText.text = "Score   : " + score;
    }

    
}
