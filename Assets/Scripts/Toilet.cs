using TMPro;
using UnityEngine;

public class Toilet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameController.Instance.FinishGame(true);
        }
    }
}
