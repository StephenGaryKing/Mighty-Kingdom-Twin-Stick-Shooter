using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is required to pass commands from the player animator to the relevent scripts
/// </summary>
public class PlayerAnimationReactor : MonoBehaviour
{

	[SerializeField] PlayerController m_playerController;

	/// <summary>
	/// Fire a bullet from the player
	/// </summary>
	void Shoot()
	{
		m_playerController.Shoot();
	}
}
