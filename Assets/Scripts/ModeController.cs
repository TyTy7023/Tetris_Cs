using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Mode = Helper.Mode;
using System.Numerics;
using TMPro;

public class ModeController : MonoBehaviour
{
    static ModeController instance = null;
    public Button stageMode, infiniteMode, guider;
    private static Mode mode = Mode.none;
    public GameObject mess;

    void Start()
    {
        mess.SetActive(false);
    }

    private void Awake()
    { 
        if (instance == null) {
            Debug.Log("ModeController instance has been assigned");
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

    public void StartGame() {
        Debug.Log(mode.ToString());
        if (mode != Mode.none)
        {
            FindObjectOfType<AudioManager>().Play("Start");
            SceneManager.LoadScene("GameScene");
        }
        else  mess.SetActive(true);



    }
    public void Guider()
    {
        FindObjectOfType<AudioManager>().Play("Start");
        SceneManager.LoadScene("Guide");
    }

    public Mode GetMode() {
        return mode;
    }

    public void SetMode(Mode mode)
    {
        ModeController.mode = mode;
    }

    public void SetMode(int mode) {
        FindObjectOfType<AudioManager>().Play("MenuMove");
        if (mode == 0)
            ModeController.mode = Mode.stage;
        else if (mode == 1)
            ModeController.mode = Mode.infinite;
        switch (ModeController.mode) {
            case Mode.stage:
                stageMode.interactable = false;
                infiniteMode.interactable = true;
                break;
            case Mode.infinite:
                stageMode.interactable = true;
                infiniteMode.interactable = false;
                break;
        }
    }
}
