using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Follow a target smoothly while maintaining an offset
/// </summary>
public class CameraMovement : MonoBehaviour
{

	[SerializeField] Transform m_target;
	[SerializeField] float m_smoothing = 0.5f;
	Vector3 m_offset;

    // Start is called before the first frame update
    void Start()
    {
		// set the offset of the camera's position when compared to the target's position
		m_offset = transform.position - m_target.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		FollowPlayer();
    }

	/// <summary>
	/// Smoothly follow the player with an offset
	/// </summary>
	void FollowPlayer()
	{
		Vector3 destination = m_target.transform.position + m_offset;
		transform.position = Vector3.Lerp(transform.position, destination, m_smoothing);
	}
}
