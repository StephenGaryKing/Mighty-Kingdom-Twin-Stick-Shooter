using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{

	[SerializeField] Transform m_barrel;
	[SerializeField] GameObject m_bulletPrefab;
	[SerializeField] int m_poolSize = 10;
	[SerializeField] float m_bulletSpeed = 1;
	List<GameObject> m_pool = new List<GameObject>();
	int m_currentIndexToSpawn = 0;

	// Start is called before the first frame update
	void Start()
    {
		PopulatePool();
    }

	/// <summary>
	/// Populate pool of bullets
	/// </summary>
	void PopulatePool()
	{
		// Create a container to hold the pool to keep the hierarchy clean
		Transform bulletContainer = new GameObject("Bullet Container").transform;
		bulletContainer.parent = transform;
		// Populate the pool with instances of the bullet prefab
		for (int i = 0; i < m_poolSize; i++)
		{
			GameObject bullet = Instantiate(m_bulletPrefab).gameObject;
			bullet.transform.parent = bulletContainer;
			// Deactivate the bullet while they're not in use
			bullet.SetActive(false);
			m_pool.Add(bullet);
		}
	}
	
	/// <summary>
	/// Fire the next bullet in the pool from the barrel
	/// </summary>
	/// <param name="shootDirection">
	/// direction to fire the bullet
	/// </param>
	public void Shoot(Vector3 shootDirection)
	{
		// Get the next bullet in the pool
		GameObject bullet = m_pool[m_currentIndexToSpawn];
		bullet.SetActive(true);
		bullet.transform.position = m_barrel.transform.position;

		// Go to the next index of the pool
		m_currentIndexToSpawn++;
		// If the next index is over the end of the list, wrap arround to the beginning of the list
		if (m_currentIndexToSpawn >= m_pool.Count)
			m_currentIndexToSpawn = 0;

		// Set the velocity of the bullet, rb is used to simplify movement and collision checks
		bullet.GetComponent<Rigidbody>().velocity = shootDirection * m_bulletSpeed;
	}

}
