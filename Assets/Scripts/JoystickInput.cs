using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Input Manager for on-screen joysticks
/// </summary>
public class JoystickInput : InputManager
{
	[SerializeField] Joystick m_leftJoystick;
	[SerializeField] Joystick m_rightJoystick;

	/// <summary>
	/// Called by base class on Update();
	/// </summary>
	public override void GatherInput()
	{
		Vector3 lookDirection = new Vector2(m_rightJoystick.Horizontal, m_rightJoystick.Vertical);
		Vector2 moveDirection = new Vector2(m_leftJoystick.Horizontal, m_leftJoystick.Vertical);
		// Set the direction to move the player
		m_playerController.SetMoveDirection(moveDirection);
		// If the user is not touching the right joystick look in the direction of movement
		if (lookDirection.magnitude == 0)
		{
			lookDirection = moveDirection;
			m_playerController.SetShooting(false);
		}
		else
			m_playerController.SetShooting(true);
		// Set the direction the player should look
		m_playerController.SetLookDirection(lookDirection);
	}
}
