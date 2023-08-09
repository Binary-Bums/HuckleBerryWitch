using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour {
    public KeyCode key = KeyCode.P;
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private Button resumeButton, quitButton;
    private PlayerInput playerInput;
    private PlayerInputManager playerInputManager;
    public int mainMenuSceneIndex = 0;

    private void Awake() {
        resumeButton.onClick.AddListener(Resume);
        quitButton.onClick.AddListener(Quit);
    }

    private void Start() {
        playerInput = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>();
        playerInputManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInputManager>();
    }

    private void Update() {
        if (Input.GetKeyDown(key))
        {
            if (pauseUI.activeSelf) Resume();

            else Pause();
        }
    }

    private void Resume() {
        Time.timeScale = 1; 
        pauseUI.SetActive(false);
        playerInput.enabled = true;
        playerInputManager.enabled = true;
    }

    private void Pause() {
        Time.timeScale = 0; 
        pauseUI.SetActive(true);
        playerInput.enabled = false;
        playerInputManager.enabled = false;
    }

    private void Quit() {
        Time.timeScale = 1;
        SceneManager.LoadScene(mainMenuSceneIndex);
    }
}