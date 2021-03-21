using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlPanelController : MonoBehaviour
{
    public RectTransform rectTransform;

    public Vector2 offScreenPos;
    public Vector2 onScreenPos;
    [Range(0.1f, 10.0f)]
    public float speed = 5.0f;
    private float timer = 0.0f;
    public bool isOnScreen = false;
    public CameraController playerCam;

    public Pausable pausable;

    // Start is called before the first frame update
    void Start()
    {
        pausable = FindObjectOfType<Pausable>();
        playerCam = FindObjectOfType<CameraController>();
        rectTransform = GetComponent<RectTransform>();
        rectTransform.anchoredPosition = offScreenPos;
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isOnScreen = !isOnScreen;
            timer = 0.0f;
            if (isOnScreen)
            {
                Cursor.lockState = CursorLockMode.None;
                playerCam.enabled = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                playerCam.enabled = true;
            }
        }
        if (isOnScreen)
        {
            MoveControlPanelDown();
        }
        else
        {
            MoveControlPanelUp();
        }
    }

    private void MoveControlPanelDown()
    {
        rectTransform.anchoredPosition = Vector2.Lerp(offScreenPos, onScreenPos, timer);
        if(timer < 1.0f)
        {
            timer += Time.deltaTime * speed;
        }
    }
    private void MoveControlPanelUp()
    {
        rectTransform.anchoredPosition = Vector2.Lerp(onScreenPos, offScreenPos, timer);
        if (timer < 1.0f)
        {
            timer += Time.deltaTime * speed;
        }

        if (pausable.isGamePaused)
        {
            pausable.TogglePause();
        }
    }
}
