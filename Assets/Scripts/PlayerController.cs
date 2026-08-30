using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidbody;
    [SerializeField] float maxSpeed = 0.1f;
    [SerializeField] float speed = 0.01f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            //this.transform.position += Vector3.left * Time.deltaTime * cameraSpeed;
            rigidbody.AddForceX(-speed, ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.D))
        {
            //this.transform.position += Vector3.right * Time.deltaTime * cameraSpeed;
            rigidbody.AddForceX(speed, ForceMode2D.Impulse);
        }

        if (rigidbody.linearVelocity.x > maxSpeed) rigidbody.linearVelocity = new Vector2(maxSpeed, 0);
        if (rigidbody.linearVelocity.x < -maxSpeed) rigidbody.linearVelocity = new Vector2(-maxSpeed, 0);

        if (this.transform.position.x < -15.0f)
        {
            rigidbody.AddForceX(speed, ForceMode2D.Impulse);
        }
        if (this.transform.position.x > 65.0f)
        {
            rigidbody.AddForceX(-speed, ForceMode2D.Impulse);
        }
    }
}
