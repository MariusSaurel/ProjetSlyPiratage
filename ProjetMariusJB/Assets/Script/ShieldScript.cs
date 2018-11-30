using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour {

    public int Health;
    private EnemyController enemyScript;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        enemyScript = GetComponentInParent<EnemyController>();
        Health = enemyScript.Health;
		if (Health <= 0)
        {
            Destroy(this.gameObject);
        }
	}

    public void DamageEnemy(int damage)
    {
        if (Health > 0)
        {
            enemyScript.Health -= damage;
        }
    }
}
