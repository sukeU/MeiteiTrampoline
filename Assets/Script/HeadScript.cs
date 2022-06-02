using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadScript : MonoBehaviour
{
    Rigidbody rb;
    float scalarLimit;
    [SerializeField] VomitingCubeScript cube;
    Transform cubes;
    Vector3 MousePos;
    bool isSound=false;
    private void Start()
    {
        cubes = new GameObject("cloneCubes").transform;
        rb = transform.parent.gameObject.GetComponent<Rigidbody>();
        scalarLimit = 5;
    }
    private void OnTriggerEnter(Collider other)
    {
        TranpoScript script = other.GetComponent<TranpoScript>();
        if (script != null)
        {
           // Debug.Log(rb.velocity.magnitude);
            if (rb.velocity.magnitude < scalarLimit/2)
            {
                nauseaANDscoreScript.Instance.ChangeNauseaPoint(2);
            }
            else if (scalarLimit/2<=rb.velocity.magnitude&& rb.velocity.magnitude<scalarLimit)
            {
                nauseaANDscoreScript.Instance.ChangeNauseaPoint(5);
            }
            else
            {
                nauseaANDscoreScript.Instance.ChangeNauseaPoint(15);
            }

        }
        else if( other.gameObject.tag == "frame")
        {
            AllManager.Instance.PlaySeByName("フレーム");
            if (rb.velocity.magnitude < scalarLimit / 2)
            {
                nauseaANDscoreScript.Instance.ChangeNauseaPoint(5);
            }
            else if (scalarLimit / 2 <= rb.velocity.magnitude && rb.velocity.magnitude < scalarLimit)
            {
                nauseaANDscoreScript.Instance.ChangeNauseaPoint(15);
          
            }
            else
            {
                nauseaANDscoreScript.Instance.ChangeNauseaPoint(35);
                
            }
        }
    }
    private void Update()
    {
        CheckDownState();
    }
    void CheckDownState()
    {
        if (nauseaANDscoreScript.Instance.getNauseaPoint == nauseaANDscoreScript.Instance.checkMaxNauseaPoint)
        {
            MousePos = new Vector3(gameObject.transform.GetChild(0).transform.position.x, gameObject.transform.GetChild(0).transform.position.y, gameObject.transform.GetChild(0).transform.position.z);
            VomitingCubeScript v=InstBullet(MousePos, transform.rotation);
            v.color = Random.Range(0, 6);
            if (!isSound)
            {
                AllManager.Instance.PlaySeByName("水ぶくぶく1");
                isSound = true;
            }
            
        }
        
        
    }
    VomitingCubeScript InstBullet(Vector3 pos, Quaternion rotation)
    {
        //アクティブでないオブジェクトをbulletsの中から探索
        foreach (Transform t in cubes)
        {
            if (!t.gameObject.activeSelf)
            {
                //非アクティブなオブジェクトの位置と回転を設定
                t.SetPositionAndRotation(pos, rotation);
                //アクティブにする
                t.gameObject.SetActive(true);
                return t.GetComponent<VomitingCubeScript>();
            }
        }
        //非アクティブなオブジェクトがない場合新規生成

        //生成時にbulletsの子オブジェクトにする
        return Instantiate(cube, pos, rotation, cubes);
    }
}
