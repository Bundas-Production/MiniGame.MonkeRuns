using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    [Space]
    [SerializeField]
    GameObject comic;
    [SerializeField]
    Image comicImage;
    [SerializeField]
    Image comicEmpty;
    [SerializeField]
    Image comicOne;
    [SerializeField]
    Image comicTwo;
    Coroutine comicRoutine;

    [Space]

    [SerializeField]
    Image condition;
    [SerializeField]
    Image winCondition;
    [SerializeField]
    Image looseCondition;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        playerController.enabled = false;
        monster.enabled = false;
        comicRoutine = StartCoroutine(PlayComic());
    }

    private void Update()
    {
        if (comicRoutine != null)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StopCoroutine(comicRoutine);
                comic.SetActive(false);
            }
        }
    }

    public void StartGame()
    {
        playerController.enabled = true;
        monster.enabled = true;
    }

    public void FinishGame(bool isWin)
    {
        Instance.playerController.enabled = false;
        Instance.monster.enabled = false;
        Instance.playButton.SetActive(false);
        Instance.replayButton.SetActive(true);
        Instance.canvas.SetActive(true);
        StartCoroutine(FinishImage(isWin));
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator PlayComic()
    {
        comic.SetActive(true);
        comicImage.color = new Color(comicImage.color.r, comicImage.color.g, comicImage.color.b, 1);
        comicEmpty.color = new Color(comicEmpty.color.r, comicEmpty.color.g, comicEmpty.color.b, 0);
        comicOne.color = new Color(comicOne.color.r, comicOne.color.g, comicOne.color.b, 0);
        comicTwo.color = new Color(comicTwo.color.r, comicTwo.color.g, comicTwo.color.b, 0);

        while (comicEmpty.color.a < 1)
        {
            comicEmpty.color += new Color(0, 0, 0, Time.deltaTime);
            yield return null;
        }

        comicImage.color = new Color(comicImage.color.r, comicImage.color.g, comicImage.color.b, 0);

        while (comicOne.color.a < 1)
        {
            comicOne.color += new Color(0, 0, 0, Time.deltaTime);
            yield return null;
        }

        yield return new WaitForSeconds(3);

        while (comicTwo.color.a < 1)
        {
            comicTwo.color += new Color(0, 0, 0, Time.deltaTime);
            yield return null;
        }

        yield return new WaitForSeconds(2);


        while (comicEmpty.color.a > 0)
        {
            comicEmpty.color -= new Color(0, 0, 0, Time.deltaTime);
            comicOne.color -= new Color(0, 0, 0, Time.deltaTime);
            comicTwo.color -= new Color(0, 0, 0, Time.deltaTime);
            yield return null;
        }
        comic.SetActive(false);
    }

    IEnumerator FinishImage(bool isWin)
    {
        winCondition.gameObject.SetActive(isWin);
        looseCondition.gameObject.SetActive(!isWin);


        while (condition.color.a < 1)
        {
            condition.color += new Color(0, 0, 0, Time.deltaTime);
            winCondition.color += new Color(0, 0, 0, Time.deltaTime);
            looseCondition.color += new Color(0, 0, 0, Time.deltaTime);
            yield return null;
        }
    }
}
