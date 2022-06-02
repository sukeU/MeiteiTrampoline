using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Awake�O��ManagerScene�������Ń��[�h����N���X
/// </summary>
public class ManagerSceneAutoLoader
{

    //�Q�[���J�n��(�V�[���ǂݍ��ݑO)�Ɏ��s�����
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void LoadManagerScene()
    {
        string managerSceneName = "GameManagerScene";

        //ManagerScene���L���łȂ���(�܂��ǂݍ���ł��Ȃ���)�����ǉ����[�h����悤��
        if (!SceneManager.GetSceneByName(managerSceneName).IsValid())
        {
            SceneManager.LoadScene(managerSceneName, LoadSceneMode.Additive);
        }
    }
}
