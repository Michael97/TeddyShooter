using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeadMenu : MonoBehaviour
{

    public PlayerController PlayerController;

    public GameObject DeadGameObject;

    public string LevelLoad;

    void Start()
    {
        DeadGameObject.GetComponent<Button>().onClick.AddListener(delegate { OnRestartLevelClick(); });
        DeadGameObject.SetActive(false);
    }

	// Update is called once per frame
   	void FixedUpdate ()
    {
        if (PlayerController.GetIsDead())
        {
            DeadGameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void OnRestartLevelClick()
    {
        SceneManager.LoadScene(LevelLoad);
    }

}
