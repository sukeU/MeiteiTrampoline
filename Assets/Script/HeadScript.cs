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
            AllManager.Instance.PlaySeByName("�t���[��");
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
                AllManager.Instance.PlaySeByName("���Ԃ��Ԃ�1");
                isSound = true;
            }
            
        }
        
        
    }
    VomitingCubeScript InstBullet(Vector3 pos, Quaternion rotation)
    {
        //�A�N�e�B�u�łȂ��I�u�W�F�N�g��bullets�̒�����T��
        foreach (Transform t in cubes)
        {
            if (!t.gameObject.activeSelf)
            {
                //��A�N�e�B�u�ȃI�u�W�F�N�g�̈ʒu�Ɖ�]��ݒ�
                t.SetPositionAndRotation(pos, rotation);
                //�A�N�e�B�u�ɂ���
                t.gameObject.SetActive(true);
                return t.GetComponent<VomitingCubeScript>();
            }
        }
        //��A�N�e�B�u�ȃI�u�W�F�N�g���Ȃ��ꍇ�V�K����

        //��������bullets�̎q�I�u�W�F�N�g�ɂ���
        return Instantiate(cube, pos, rotation, cubes);
    }
}
