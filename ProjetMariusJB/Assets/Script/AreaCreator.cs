<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaCreator : MonoBehaviour
{

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
    private int[,] array = new int[0, 0];

    // Use this for initialization
    void Start()
    {
    }

    public void CreateMap()
    {
        int i;
        foreach (GameObject Block in GameObject.FindGameObjectsWithTag("MapChildren"))
        {
            MapVariables BlockVariable = Block.GetComponent<MapVariables>();
            for (i = 0; i <= BlockVariable.NombrePorte; i++)
            {
                BlockVariable.PorteBas = false;
                BlockVariable.PorteDroite = false;
                BlockVariable.PorteGauche = false;
                BlockVariable.PorteHaut = false;
            }
        }
        foreach (GameObject Block in GameObject.FindGameObjectsWithTag("MapChildren"))
        {
            MapVariables BlockVariable = Block.GetComponent<MapVariables>();
            if (BlockVariable.NombrePorte != 1)
            {
                for (i = 0; i <= BlockVariable.NombrePorte; i++)
                {
                    if (BlockVariable.PorteBas != true)
                    {
                        foreach (int x in array)
                        {
                            if (x == BlockVariable.posx)
                            {

                            }
                        }
                    }
                }
            }
        }
    }

    public bool CreateBlock(int x, int y)
    {
        //Instantiate(); // nouveau block Background qui nous sert de base pour placer les murs
        int NombrePorte = Random.Range(1, 4);
        if (NombrePorte == 1)
        {
            return true;
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaCreator : MonoBehaviour
{

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
    private int[,] array = new int[0, 0];

    // Use this for initialization
    void Start()
    {
    }

    public void CreateMap()
    {
        int i;
        foreach (GameObject Block in GameObject.FindGameObjectsWithTag("MapChildren"))
        {
            MapVariables BlockVariable = Block.GetComponent<MapVariables>();
            for (i = 0; i <= BlockVariable.NombrePorte; i++)
            {
                BlockVariable.PorteBas = false;
                BlockVariable.PorteDroite = false;
                BlockVariable.PorteGauche = false;
                BlockVariable.PorteHaut = false;
            }
        }
        foreach (GameObject Block in GameObject.FindGameObjectsWithTag("MapChildren"))
        {
            MapVariables BlockVariable = Block.GetComponent<MapVariables>();
            if (BlockVariable.NombrePorte != 1)
            {
                for (i = 0; i <= BlockVariable.NombrePorte; i++)
                {
                    if (BlockVariable.PorteBas != true)
                    {
                        foreach (int x in array)
                        {
                            if (x == BlockVariable.posx)
                            {

                            }
                        }
                    }
                }
            }
        }
    }

    public bool CreateBlock(int x, int y)
    {
        //Instantiate(); // nouveau block Background qui nous sert de base pour placer les murs
        int NombrePorte = Random.Range(1, 4);
        if (NombrePorte == 1)
        {
            return true;
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
>>>>>>> master
