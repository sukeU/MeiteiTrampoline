using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyLowerScript : MonoBehaviour
{
    GameObject Body;
    BodyScript bodyScript;
    GameObject baseObj;
    private float dis;
    private float landingTimer;
    RaycastHit hit;
    Ray r;
    private bool landingBool;
    int layerMask = 1 << 8;
    // Start is called before the first frame update
    void Start()
    {
        baseObj = GameObject.Find("baseCube");
        Body = GameObject.Find("BodyTrigger");
        bodyScript = Body.GetComponent<BodyScript>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
       if(bodyScript.nowState == BodyScript.State.Idel)
        {
            landingUpdate(); checkDistance(); DrawRay();
        }
        
    }
    void DrawRay()
    {
        r = new Ray(gameObject.transform.position, -gameObject.transform.up);
        if (Physics.Raycast(r, out hit, 2.3f, layerMask))
        {
            if (hit.collider.gameObject.name == "ScoreBox")
            {
                nauseaANDscoreScript.Instance.addScore(5);
            }
            if (hit.collider.gameObject.name == "Tranporin" && landingBool)
            {
                landingBool = false;
                nauseaANDscoreScript.Instance.addScore(Mathf.Clamp(100 - 10 * (int)dis, 0, 100));
            }
        }
        Debug.DrawRay(r.origin, r.direction * 2.2f, Color.green, 2.2f, false);

    }


    void landingUpdate()
    {
        if (!bodyScript.getTouch)
        {
            landingTimer += Time.deltaTime;
            if (landingTimer > 1.5f)
            {
              
                landingBool = true;
                landingTimer = 0.0f;
            }
        }
        else
        {

            landingTimer = 0.0f;
            landingBool = false;
            checkDistance();
        }
    }
    private void checkDistance()
    {
        dis = (transform.position - baseObj.transform.position).sqrMagnitude;
        //  Debug.Log(dis);
    }
}
