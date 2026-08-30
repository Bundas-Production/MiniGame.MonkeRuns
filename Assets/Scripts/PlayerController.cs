using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidbody;
    [SerializeField] float maxSpeed = 0.1f;
    [SerializeField] float speed = 0.01f;
    [SerializeField] Animator animator;
    int speedParam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speedParam = Animator.StringToHash("Speed");
    }

    // Update is called once per frame
    void Update()
    {
        bool isMoving = false;
        if (Input.GetKey(KeyCode.A))
        {
            rigidbody.AddForceX(-speed, ForceMode2D.Impulse);
            isMoving = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rigidbody.AddForceX(speed, ForceMode2D.Impulse);
            isMoving = true;
        }

        UpdateMove(isMoving);

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

    void UpdateMove(bool isMoving)
    {
        float movement = animator.GetFloat(speedParam);
        if (isMoving) movement += Time.deltaTime;
        else movement -= Time.deltaTime * 10;

        if (movement < 0) movement = 0;
        if (movement > 1) movement = 1;

        animator.SetFloat(speedParam, movement);
    }
}
