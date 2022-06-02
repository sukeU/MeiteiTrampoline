using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nauseaBarScript : MonoBehaviour
{
    public Image mask;
    float originalSize;
    float valve;
    // Start is called before the first frame update
    void Start()
    {
        originalSize = mask.rectTransform.rect.height;
    }

    private void Update()
    {
        valve = (float)nauseaANDscoreScript.Instance.getNauseaPoint / (float)nauseaANDscoreScript.Instance.checkMaxNauseaPoint;
        
        setBar();
    }

    public void setBar()
    {
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, originalSize * valve);
    }
}
