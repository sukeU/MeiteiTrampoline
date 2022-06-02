using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultVomitingScript : MonoBehaviour
{
    [SerializeField] VomitingCubeScript cube;
    Transform cubes;
    Vector3 MousePos;
    // Start is called before the first frame update
    void Start()
    {
        cubes = GameObject.Find("cloneCubes").transform;
    }

    // Update is called once per frame
    void Update()
    {
        MousePos = new Vector3(gameObject.transform.GetChild(0).transform.position.x, gameObject.transform.GetChild(0).transform.position.y, gameObject.transform.GetChild(0).transform.position.z);
        VomitingCubeScript v = InstBullet(MousePos, transform.rotation);
        v.color = Random.Range(0, 6);
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
