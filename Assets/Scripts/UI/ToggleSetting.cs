using UnityEngine;
using UnityEngine.InputSystem;
public class ToggleSetting : MonoBehaviour
{
    public GameObject settingCanvas;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleSettings();
        }
    }

    public void ToggleSettings()
    {
        if (!settingCanvas.activeSelf)
        {
            GameObject.FindWithTag("Player").GetComponent<PlayerInput>().enabled = false;
            settingCanvas.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            GameObject.FindWithTag("Player").GetComponent<PlayerInput>().enabled = true;
            settingCanvas.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}