using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPos : MonoBehaviour
{
	
	private GameMaster gm;
	public static int known = 0;
	void Start()
	{
		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
		transform.position = gm.lastCheckPointPos;
	}
	
	void Update()
	{
		if (HealthBar.heal == 0)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			HealthBar.heal = 3;
			
		}
	}

}
