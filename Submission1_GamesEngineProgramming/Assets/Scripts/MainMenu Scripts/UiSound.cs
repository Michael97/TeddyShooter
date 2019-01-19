using UnityEngine;

public class UiSound : MonoBehaviour
{

    public AudioSource HoverSound;
    public AudioSource ClickSound;

    public void OnHover()
    {
        HoverSound.Play();
    }

    public void OnClick()
    {
        ClickSound.Play();
    }
}
