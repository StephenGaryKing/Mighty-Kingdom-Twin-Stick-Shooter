using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the movement and appearance of the player
/// </summary>
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BulletManager))]
public class PlayerController : MonoBehaviour
{
	[SerializeField] Transform m_playerModel;
	[SerializeField] Animator m_playerAnimator;
	[SerializeField] float m_movementSpeed = 0.1f;
	[SerializeField] float m_shootSpeed = 1;
	Rigidbody m_rb;
	BulletManager m_bulletManager;
	Vector3 m_moveDirection;
	Vector3 m_lookDirection;
	bool m_shooting = false;

	// Start is called before the first frame update
	void Start()
    {
		m_rb = GetComponent<Rigidbody>();
		m_bulletManager = GetComponent<BulletManager>();
		// ShootSpeed modifies the speed of the shooting animation
		m_playerAnimator.SetFloat("ShootSpeed", m_shootSpeed);
    }

	/// <summary>
	/// Set the Move Direction via another script
	/// </summary>
	/// <param name="direction">
	/// Move Direction
	/// </param>
	public void SetMoveDirection(Vector2 direction)
	{
		// Convert the value to a Vector3 for easy use
		m_moveDirection = new Vector3(direction.x, 0, direction.y);
	}

	/// <summary>
	/// Set the Move Direction via another script
	/// </summary>
	/// <param name="direction">
	/// Look Direction
	/// </param>
	public void SetLookDirection(Vector2 direction)
	{
		// Convert the value to a Vector3 for easy use
		m_lookDirection = new Vector3(direction.x, 0, direction.y).normalized;
	}

	/// <summary>
	/// Set Shooting via another script
	/// </summary>
	/// <param name="shooting">
	/// Shooting value
	/// </param>
	public void SetShooting(bool shooting)
	{
		m_shooting = shooting;
	}

	void FixedUpdate()
	{
		Move();
		Rotate();
		Animate();
	}

	/// <summary>
	/// Move the player's rigidbody (rb is used to maintain player's physical presence with objects in the scene)
	/// </summary>
	void Move()
	{
		m_rb.MovePosition(transform.position + m_moveDirection * m_movementSpeed);
	}

	/// <summary>
	/// Rotate the player's model (the model is used instead of the root object to maintain simplicity when moving)
	/// </summary>
	void Rotate()
	{
		// if the user is inputting a value, face the corresponding direction
		if (m_lookDirection.magnitude > 0)
			m_playerModel.transform.forward = m_lookDirection;
	}

	/// <summary>
	/// Set values within the player's animator
	/// </summary>
	void Animate()
	{
		// Animate Movement
		if (m_moveDirection.magnitude > 0)
			m_playerAnimator.SetBool("Moving", true);
		else
			m_playerAnimator.SetBool("Moving", false);
		// Velocity modifies the speed of the running animation
		m_playerAnimator.SetFloat("Velocity", m_moveDirection.magnitude);

		// Animate When Shooting
		if (m_shooting)
			m_playerAnimator.SetBool("Shooting", true);
		else
			m_playerAnimator.SetBool("Shooting", false);
	}

	/// <summary>
	/// Fire a bullet using the bullet manager
	/// </summary>
	public void Shoot()
	{
		m_bulletManager.Shoot(m_playerModel.transform.forward);
	}
}
