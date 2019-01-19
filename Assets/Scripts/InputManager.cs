using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for all player controlling input managers
/// </summary>
[RequireComponent(typeof(PlayerController))]
public abstract class InputManager : MonoBehaviour
{
	protected PlayerController m_playerController;

	public void Start()
	{
		m_playerController = GetComponent<PlayerController>();
	}

	public void Update()
	{
		GatherInput();
	}

	/// <summary>
	/// Gather input to control the player
	/// </summary>
	public abstract void GatherInput();
}
