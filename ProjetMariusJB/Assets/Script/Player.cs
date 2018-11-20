using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : IEnumerable {

    private int health;
    private float speed;
    private float damage;

    public int Health
    {
        get
        {
            return health;
        }

        set
        {
            health = value;
        }
    }

    public float Speed
    {
        get
        {
            return speed;
        }

        set
        {
            speed = value;
        }
    }

    public float Damage
    {
        get
        {
            return damage;
        }

        set
        {
            damage = value;
        }
    }

    public IEnumerator GetEnumerator()
    {
        throw new System.NotImplementedException();
    }

    void Start () {
		
	}

    public void Init()
    {
        Health = 10;
        Speed = 10;
        Damage = 1;
    }

    public void SetValue(int Health, float Speed, float Damage)
    {
        health = Health;
        speed = Speed;
        damage = Damage;
    }
	

	void Update () {
		
	}
}
