using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpashScreen : MonoBehaviour
{

    public Image SpashImage;
    public string LevelLoad;

    IEnumerator Start()
    {
        //Limit fps
        Application.targetFrameRate = 60;

        SpashImage.canvasRenderer.SetAlpha(0.0f);

        FadeIn();
        yield return new WaitForSeconds(2.5f);
        FadeOut();
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(LevelLoad);
        
    }

    void FadeIn()
    {
        SpashImage.CrossFadeAlpha(1.0f, 1.5f, false);
    }

    void FadeOut()
    {
        SpashImage.CrossFadeAlpha(0.0f, 2.5f, false);
    }
}
