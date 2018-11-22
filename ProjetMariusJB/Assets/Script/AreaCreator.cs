using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaCreator : MonoBehaviour {

    public GameObject BasOuvert;
    public GameObject BasFermé;
    public GameObject HautOuvert;
    public GameObject HautFermé;
    public GameObject DroiteOuvert;
    public GameObject DroitFermé;
    public GameObject GaucheOuvert;
    public GameObject GaucheFermé;
    private int posx;
    private int posy;
    private GameObject Block;
    public GameObject GameMap;
    private int[,] array = new int[0, 0];

    // Use this for initialization
    void Start () {
		
	}
	
    public void CreateMap()
    {
        int i;
        foreach (GameObject Block in GameMap)
        {
            for (i = 0; i <= Block.NombrePorte; i++)
            {
                Block.CheckGauche = false;
                Block.CheckDroite = false;
                Block.CheckHaut = false;
                Block.CheckBas = false;
            }
        }
            foreach (GameObject Block in GameMap)
        {
            if (Block.NombrePorte != 1)
            {
                for (i = 0;i <= Block.NombrePorte; i++)
                {
                    if(Block.CheckBas != true)
                    {
                        foreach(int x in array)
                        {
                            if (x == Block.posx)
                            {

                            }
                        }
                    }
                }
            }
        }
    }

    public bool CreateBlock(int x,int y)
    {
        Instantiate(); // nouveau block Background qui nous sert de base pour placer les murs
        int NombrePorte = Random.Range(1,4);
        if (NombrePorte == 1)
        {
            return true;
        }
        return false;
    }

	// Update is called once per frame
	void Update () {
		
	}
}
