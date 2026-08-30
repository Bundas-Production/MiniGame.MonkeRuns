using UnityEngine;

public class PlayerController : MonoBehaviour
{
	// Cambié el nombre a 'rb' ya que 'rigidbody' puede causar advertencias por ocultar propiedades heredadas
	[SerializeField] Rigidbody2D rb;
	[SerializeField] float maxSpeed = 5f;
	[SerializeField] float speed = 10f; // Necesitarás valores más altos si usas ForceMode2D.Force
	[SerializeField] Animator animator;
	int speedParam;

	private float moveInput = 0f;

	void Start()
	{
		speedParam = Animator.StringToHash("Speed");
	}

	void Update()
	{
		// 1. Recoger el input en Update (dependiente del framerate)
		moveInput = 0f;
		if (Input.GetKey(KeyCode.A)) moveInput = -1f;
		if (Input.GetKey(KeyCode.D)) moveInput = 1f;

		bool isMoving = moveInput != 0f;
		UpdateMove(isMoving);
	}

	void FixedUpdate()
	{
		// 2. Aplicar físicas en FixedUpdate (independiente del framerate)
		if (moveInput != 0f)
		{
			// Usamos 'Force' para movimiento continuo al mantener la tecla presionada
			rb.AddForceX(moveInput * speed, ForceMode2D.Force);
		}

		// 3. Limitar velocidad manteniendo la velocidad Y intacta (para no romper la gravedad)
		float currentVelX = rb.linearVelocity.x;
		if (currentVelX > maxSpeed)
		{
			rb.linearVelocity = new Vector2(maxSpeed, rb.linearVelocity.y);
		}
		else if (currentVelX < -maxSpeed)
		{
			rb.linearVelocity = new Vector2(-maxSpeed, rb.linearVelocity.y);
		}

		// 4. Límites del mapa (Aquí sí tiene sentido el Impulse como empuje único)
		if (this.transform.position.x < -15.0f)
		{
			rb.AddForceX(speed, ForceMode2D.Impulse);
		}
		else if (this.transform.position.x > 65.0f)
		{
			rb.AddForceX(-speed, ForceMode2D.Impulse);
		}
	}

	void UpdateMove(bool isMoving)
	{
		float movement = animator.GetFloat(speedParam);
		if (isMoving) movement += Time.deltaTime;
		else movement -= Time.deltaTime * 10;

		// Clamp01 es una forma más limpia de mantener el valor entre 0 y 1
		movement = Mathf.Clamp01(movement);

		animator.SetFloat(speedParam, movement);
	}
}