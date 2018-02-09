using UnityEngine;
using System.Collections;

public class Lava : MonoBehaviour {

	public GameObject player;
	public GameObject lava;
	public float LavaDmg = 0;
	public float LavaDmgCldwn = 1;
	public int LavaCldwn = 5;
	public bool triggerOn = false;
	
	void Awake (){
		player = GameObject.FindGameObjectWithTag ("Player");
		lava = GameObject.FindGameObjectWithTag ("Lava");
	}

	void OnTriggerEnter (Collider c){
		if (c.gameObject.tag == "Player"){
			triggerOn = true;
		}
	}
	
	void Update (){
		if (triggerOn == true){
			LavaDmg = 10;
			Player pstats = player.GetComponent<Player>();
					 
			if (LavaDmgCldwn <= 1){
				LavaDmgCldwn -= Time.deltaTime;
			}
			if (LavaDmgCldwn <= 0){
				pstats.CurHealth -= LavaDmg;
				LavaCldwn -= 1;
				LavaDmgCldwn = 1;
			}
			if (LavaCldwn <= 0){
				LavaDmg = 0;
				triggerOn = false;
				LavaCldwn = 5;
			}
		}
	}
}