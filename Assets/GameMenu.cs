using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // Required for UI components
using UnityEngine.SceneManagement;  // For exiting the game

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;  // Keeps track of whether the game is paused
    private GameObject pauseMenuUI;
    private Button resumeButton;
    private Button quitButton;

    void Start()
    {
        // Create Canvas for UI
        GameObject canvasObj = new GameObject("PauseCanvas");
        Canvas canvas = canvasObj.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        CanvasScaler canvasScaler = canvasObj.AddComponent<CanvasScaler>();
        canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        canvasObj.AddComponent<GraphicRaycaster>();

        // Create Panel
        GameObject panelObj = new GameObject("PausePanel");
        panelObj.transform.SetParent(canvasObj.transform);
        RectTransform panelRect = panelObj.AddComponent<RectTransform>();
        panelRect.sizeDelta = new Vector2(400, 300);
        panelObj.AddComponent<Image>().color = new Color(0, 0, 0, 0.7f);  // Semi-transparent black

        // Create Instruction Text
        GameObject instructionsObj = CreateText("Instructions", panelObj.transform, new Vector2(0, 100), 
            "Press ESC to Pause/Unpause. Use buttons below.");
        
        // Create Resume Button
        GameObject resumeBtnObj = CreateButton("ResumeButton", panelObj.transform, new Vector2(0, 50), "Resume");
        resumeButton = resumeBtnObj.GetComponent<Button>();
        resumeButton.onClick.AddListener(Resume);

        // Create Quit Button
        GameObject quitBtnObj = CreateButton("QuitButton", panelObj.transform, new Vector2(0, -50), "Quit");
        quitButton = quitBtnObj.GetComponent<Button>();
        quitButton.onClick.AddListener(QuitGame);

        // Adjust Panel Position
        panelRect.localPosition = Vector3.zero;
        pauseMenuUI = panelObj;
        pauseMenuUI.SetActive(false);  // Hide it by default
    }

    void Update()
    {
        // When the "Escape" key is pressed, toggle the pause menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    // Method to create buttons
    GameObject CreateButton(string name, Transform parent, Vector2 position, string buttonText)
    {
        // Create Button Object
        GameObject buttonObj = new GameObject(name);
        buttonObj.transform.SetParent(parent);
        RectTransform rectTransform = buttonObj.AddComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(160, 40);
        rectTransform.localPosition = position;

        // Add Button Component
        Button button = buttonObj.AddComponent<Button>();
        button.targetGraphic = buttonObj.AddComponent<Image>();
        button.GetComponent<Image>().color = new Color(1, 1, 1, 0.7f);  // White-ish button

        // Add Text to Button
        GameObject textObj = new GameObject("Text");
        textObj.transform.SetParent(buttonObj.transform);
        Text text = textObj.AddComponent<Text>();
        text.text = buttonText;
        text.alignment = TextAnchor.MiddleCenter;
        text.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        text.color = Color.black;
        text.fontSize = 24;

        // Adjust Text Position
        RectTransform textRect = textObj.GetComponent<RectTransform>();
        textRect.sizeDelta = new Vector2(160, 40);
        textRect.localPosition = Vector3.zero;

        return buttonObj;
    }

    // Method to create instructions text
    GameObject CreateText(string name, Transform parent, Vector2 position, string textContent)
    {
        GameObject textObj = new GameObject(name);
        textObj.transform.SetParent(parent);
        RectTransform rectTransform = textObj.AddComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(300, 60);
        rectTransform.localPosition = position;

        Text text = textObj.AddComponent<Text>();
        text.text = textContent;
        text.alignment = TextAnchor.MiddleCenter;
        text.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        text.color = Color.white;
        text.fontSize = 20;

        return textObj;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);  // Hide the pause menu UI
        Time.timeScale = 1f;  // Resume the game
        isPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);  // Show the pause menu UI
        Time.timeScale = 0f;  // Pause the game
        isPaused = true;
    }

    public void QuitGame()
    {
        Application.Quit();  // Quit the application
    }
}
