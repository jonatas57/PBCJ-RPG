using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGGameManager : MonoBehaviour {
	public static RPGGameManager instanciaCompartilhada = null;
	public RPGCameraManager cameraManager;

	public PontoSpawn playerPontoSpawn;

	private void Awake() {
		if (instanciaCompartilhada != null && instanciaCompartilhada != this) {
			Destroy(gameObject);
		}
		else {
			instanciaCompartilhada = this;
		}
	}

	// Start is called before the first frame update
	void Start() {
		SetupScene();
	}

	public void SetupScene() {
		SpawnPlayer();
	}

	public void SpawnPlayer() {
		if (playerPontoSpawn != null) {
			GameObject player = CenaManager.instancia.player;
			if (player == null) {
				player = playerPontoSpawn.SpawnO();
				CenaManager.instancia.player = player;
				DontDestroyOnLoad(CenaManager.instancia.player);
			}
			player.transform.position = playerPontoSpawn.transform.position;
			cameraManager.virtualCamera.Follow = player.transform;
		}
	}

	// Update is called once per frame
	void Update() {

	}
}
