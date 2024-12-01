using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class guideController : MonoBehaviour
{
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Nhấn Space để test
        {
            GoBack();
        }
    }

    public void GoBack()
    {
        Debug.Log("GoBack called");
        SceneManager.LoadScene("ModeScene");
    }
}
