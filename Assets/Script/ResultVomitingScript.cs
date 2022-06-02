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
