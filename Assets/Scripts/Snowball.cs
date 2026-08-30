using System.Collections;
using UnityEngine;

public class Snowball : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Player")
        {
            GameController.Instance.FinishGame();
        }
    }
}
