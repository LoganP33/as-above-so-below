using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
	public static GameMaster instance;
	public Vector2 lastCheckPointPos;
	
	void Awake(){
		
		if(instance == null){
			instance = this;
			DontDestroyOnLoad(instance);
		}
		
		else
		{
			Destroy(gameObject);
		}
		
	}
	
    public static void KillPlayer(Player player)
    {
        //Destroy(player.gameObject);
    }

}
