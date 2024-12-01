using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Mode = Helper.Mode;
using System.Numerics;

public class ModeController : MonoBehaviour
{
    static ModeController instance = null;
    public Button stageMode, infiniteMode, guider;
    private static Mode mode = Mode.stage;
    
    private void Awake()
    {
        if (instance == null) {
            Debug.Log("ModeController instance has been assigned");
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

    public void StartGame() {
        FindObjectOfType<AudioManager>().Play("Start");
        SceneManager.LoadScene("GameScene");
    }
    public void Guider()
    {
        FindObjectOfType<AudioManager>().Play("Start");
        SceneManager.LoadScene("Guide");
    }

    public Mode GetMode() {
        return mode;
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
