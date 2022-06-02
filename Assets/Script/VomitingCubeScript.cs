using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VomitingCubeScript : MonoBehaviour
{
    private float setActiveTime;
    private float falseTime=2f;
    public float color { set; get; }
    [SerializeField] Material[] materials=new Material[6];
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        changeColor();
        countTime();
    }
    void countTime()
    {
        setActiveTime += Time.deltaTime;
        if (setActiveTime > falseTime)
        {
            setActiveTime = 0.0f;
            gameObject.SetActive(false);
        }
    }
    void changeColor()
    {
        switch (color) {
            case 0: GetComponent<Renderer>().material.color = materials[0].color;break;
            case 1: GetComponent<Renderer>().material.color = materials[1].color; break;
            case 2: GetComponent<Renderer>().material.color = materials[2].color; break;
            case 3: GetComponent<Renderer>().material.color = materials[3].color; break;
            case 4: GetComponent<Renderer>().material.color = materials[4].color; break;
            case 5: GetComponent<Renderer>().material.color = materials[5].color; break;
            case 6: GetComponent<Renderer>().material.color = materials[6].color; break;
        }
       
        
    }
}
