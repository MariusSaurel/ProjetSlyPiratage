using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject PlayerModel;
    private Vector3 offset;


	void Start () {
        offset = transform.position - PlayerModel.transform.position;
	}
	

	void LateUpdate () {
        transform.position = PlayerModel.transform.position + offset;

	}
}
