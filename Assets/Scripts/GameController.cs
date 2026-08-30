using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    [SerializeField]
    PlayerController playerController;
    [SerializeField]
    Monster monster;
    [SerializeField]
    GameObject canvas;
    [SerializeField]
    GameObject playButton;
    [SerializeField]
    GameObject replayButton;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        playerController.enabled = false;
        monster.enabled = false;
    }

    public void StartGame()
    {
        playerController.enabled = true;
        monster.enabled = true;
    }

    public void FinishGame()
    {
        Instance.playerController.enabled = false;
        Instance.monster.enabled = false;
        Instance.playButton.SetActive(false);
        Instance.replayButton.SetActive(true);
        Instance.canvas.SetActive(true);
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
