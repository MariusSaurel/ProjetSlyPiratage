using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteDestructibleScript : MonoBehaviour {

    public int Health = 5;
	
	void Update () {
		if (Health <= 0)
        {
            GameOver();
        }
	}

    public void DamageEnemy(int damage)
    {
        Health -= damage;
    }

    public void GameOver()
    {
        Destroy(this.gameObject);
    }
}
