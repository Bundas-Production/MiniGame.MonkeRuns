using System.Collections;
using UnityEngine;

public class Snowball : MonoBehaviour
{
    [SerializeField]
    public AudioSource hitAudio;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            hitAudio.Play();
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Player")
        {
            hitAudio.Play();
            GameController.Instance.FinishGame();
        }
    }
}
