using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AllManager : SingletonMonoBehaviour<AllManager>
{

    [SerializeField, Range(0, 1), Tooltip("マスタ音量")]
    float volume = 1;
    [SerializeField, Range(0, 1), Tooltip("BGMの音量")]
    float bgmVolume = 1;
    [SerializeField, Range(0, 1), Tooltip("SEの音量")]
    float seVolume = 1;

    AudioClip[] bgm;
    AudioClip[] se;

    Dictionary<string, int> bgmIndex = new Dictionary<string, int>();
    Dictionary<string, int> seIndex = new Dictionary<string, int>();

    AudioSource bgmAudioSource;
    AudioSource seAudioSource;

    public float Volume
    {

        set
        {
            volume = Mathf.Clamp01(value);
            bgmAudioSource.volume = bgmVolume * volume;
            seAudioSource.volume = seVolume * volume;
        }
        get
        {
            return volume;
        }
    }

    public float BgmVolume
    {
        set
        {
            bgmVolume = Mathf.Clamp01(value);
            bgmAudioSource.volume = bgmVolume * volume;
        }
        get
        {
            return bgmVolume;
        }
    }

    public float SeVolume
    {
        set
        {
            seVolume = Mathf.Clamp01(value);
            seAudioSource.volume = seVolume * volume;
        }
        get
        {
            return seVolume;
        }
    }
    int resultScore;
    public int accessScore { get { return resultScore; }set { resultScore = value; } }
    difficulty mode=0;
    public difficulty modeSelect { get { return mode; } set { mode = value; } }
    public gameState nowState { get; set; }
    public enum difficulty
    {
        easy,
        medium,
        hard,
    }
    public enum gameState
    {
        loading,
        idel,
        playing,
    }

    // Start is called before the first frame update
    new void Awake()
    {
        if (this != Instance)
        {
            Destroy(gameObject);
            return;
        }
        nowState = gameState.loading;
        DontDestroyOnLoad(gameObject);
 
        bgmAudioSource = gameObject.AddComponent<AudioSource>();
        seAudioSource = gameObject.AddComponent<AudioSource>();

        bgm = Resources.LoadAll<AudioClip>("Audio/BGM");
        se = Resources.LoadAll<AudioClip>("Audio/SE");

        bgmVolume=PlayerPrefs.GetFloat("BgmVolumePref",0.5f);
        seVolume = PlayerPrefs.GetFloat("SeVolumePref", 0.5f);
        for (int i = 0; i < bgm.Length; i++)
        {
            bgmIndex.Add(bgm[i].name, i);
        }

        for (int i = 0; i < se.Length; i++)
        {
            seIndex.Add(se[i].name, i);
        }
    }

    public int GetBgmIndex(string name)
    {
        if (bgmIndex.ContainsKey(name))
        {
            return bgmIndex[name];
        }
        else
        {
            Debug.LogError("指定された名前のBGMファイルが存在しません。");
            return 0;
        }
       
    }

    public int GetSeIndex(string name)
    {
        if (seIndex.ContainsKey(name))
        {
            return seIndex[name];
        }
        else
        {
            Debug.LogError("指定された名前のSEファイルが存在しません。");
            return 0;
        }
    }

    //BGM再生
    public void PlayBgm(int index)
    {
        index = Mathf.Clamp(index, 0, bgm.Length);

        bgmAudioSource.clip = bgm[index];
        bgmAudioSource.loop = true;
        bgmAudioSource.volume = BgmVolume * Volume;
        bgmAudioSource.Play();
    }

    public void PlayBgmByName(string name)
    {
        PlayBgm(GetBgmIndex(name));
    }

    public void StopBgm()
    {
        bgmAudioSource.Stop();
        bgmAudioSource.clip = null;
    }

    //SE再生
    public void PlaySe(int index)
    {
        index = Mathf.Clamp(index, 0, se.Length);

        seAudioSource.PlayOneShot(se[index], SeVolume * Volume);
    }

    public void PlaySeByName(string name)
    {
        PlaySe(GetSeIndex(name));
    }

    public void StopSe()
    {
        seAudioSource.Stop();
        seAudioSource.clip = null;
    }



    public void ChangeTitleScene()
    {
        FadeManager.Instance.LoadScene("Title", 0.2f);
    }
    public void ChangeTutorialScene()
    {
        FadeManager.Instance.LoadScene("Tutorial", 0.2f);
    }
    public void ChangeGameScene()
    {
        FadeManager.Instance.LoadScene("GameScene", 0.4f);
    }
    public void ChangeResultScene()
    {
        FadeManager.Instance.LoadScene("Result", 1.5f);

    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
      UnityEngine.Application.Quit();
#endif
    }
}
