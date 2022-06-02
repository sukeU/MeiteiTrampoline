using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyScript : MonoBehaviour
{
    Rigidbody rb;
    private float addPow;
    private bool touchTranpo=false;
    public bool getTouch { get { return touchTranpo; }}
    public bool setTouch { set { touchTranpo=value;spaceCount = 0;flyCount = flyCount*3 / 4; }}
    private bool landingBool;
    public State nowState { get; private set; }
    private int spaceCount;
    private int spaceCountLimit;
    private float flyCount;
    private float flyTimer;
    private bool load=false;
    private Vector3 force;  // óÕÇê›íË
    private Vector3 bound;
    private float downTime;
    private float FdownTime;
    private float afterDownTime;
    private bool isSound=false;
    // Start is called before the first frame update
    void Start()
    {
        rb = transform.parent.gameObject.GetComponent<Rigidbody>();
        addPow = 0.15f;
        nowState = State.start;
        spaceCount = 0;
        spaceCountLimit = 8;
        force = new Vector3(0.0f, 4.0f, 0.0f);    // óÕÇê›íË
        bound = new Vector3(0.0f, 0.0f, 0.0f);
    }

    public enum State
    {
        start,
        Idel,
        down,
        tmp,
    }
    void movement()
    {
      
        if (Input.GetKey(KeyCode.W)|| (Input.GetKey(KeyCode.UpArrow)))
        {
            Vector3 force = new Vector3(0.0f, 0.0f, addPow);    // óÕÇê›íË
            rb.AddForce(force, ForceMode.Impulse);  // óÕÇâ¡Ç¶ÇÈ
        }
        if (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.LeftArrow)))
        {
            Vector3 force = new Vector3(-addPow, 0.0f, 0.0f);    // óÕÇê›íË
            rb.AddForce(force, ForceMode.Impulse);  // óÕÇâ¡Ç¶ÇÈ
        }
        if (Input.GetKey(KeyCode.S) || (Input.GetKey(KeyCode.DownArrow)))
        {
            Vector3 force = new Vector3(0.0f, 0.0f, -addPow);    // óÕÇê›íË
            rb.AddForce(force, ForceMode.Impulse);  // óÕÇâ¡Ç¶ÇÈ
        }
        if (Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.RightArrow)))
        {
            Vector3 force = new Vector3(addPow, 0.0f, 0.0f);    // óÕÇê›íË
            rb.AddForce(force, ForceMode.Impulse);  // óÕÇâ¡Ç¶ÇÈ
        }
       
        if (touchTranpo) {
            
                

            
            bound.y = flyCount;
            downTime += Time.deltaTime;
            rb.AddForce(bound, ForceMode.Impulse);
            
                if (Input.GetKey(KeyCode.Space))
            {
                if (spaceCount < spaceCountLimit)
                {
                    if (!isSound)
                    {
                        AllManager.Instance.PlaySeByName("åyÇ≠ÉWÉÉÉìÉv");
                        isSound = true;
                    }
                    rb.AddForce(force, ForceMode.Impulse);  // óÕÇâ¡Ç¶ÇÈ
                    spaceCount++;
                }
            }
            if (downTime > 5.0f)
            {
                nowState = State.down;
            }
        }
        else
        {
            isSound = false;
            downTime = 0.0f;
        }
    }

    void increaseFlyCount()
    {
        if (!touchTranpo)
        {
            flyTimer += Time.deltaTime;
            if (flyTimer > 1.0f)
            {
                flyTimer = 0.0f;
                flyCount++;
               
            }  
        }
        else
        {
            if (flyCount < 0.5)
            {
                flyCount = 0;
            }
            flyTimer = 0.0f;
        }
    }

    private void ResetGame()
    {
        if (Input.GetKey(KeyCode.O))
        {
            nauseaANDscoreScript.Instance.ChangeNauseaPoint(1);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
       // Debug.Log(nowState);
        if (nauseaANDscoreScript.Instance.checkNauseaLimit())
        {

            nowState = State.down;
        }
      
        switch(nowState)
        {
            case State.start: if (touchTranpo) {  nowState = State.Idel; AllManager.Instance.PlayBgmByName("MainBgm"); } break; 
            case State.Idel:movement(); increaseFlyCount();  ResetGame();break;
            case State.down:nauseaANDscoreScript.Instance.handOver();
                afterDownTime += Time.deltaTime;
                if (afterDownTime > 1.0f)
                {
                    if (!load)
                    {
                        load = true;

                        AllManager.Instance.ChangeResultScene();
                        AllManager.Instance.StopBgm();
                        AllManager.Instance.StopSe();
                    }
                } break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ground")
        {
            AllManager.Instance.PlaySeByName("ínñ ");
            nowState = State.down;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "frame")
        {
            FdownTime += Time.deltaTime;
            if (FdownTime > 5.0f)
            {
                nowState = State.down;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "frame")
        {
            FdownTime += 0.0f;
        }
    }

}
