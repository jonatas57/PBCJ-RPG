using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Caractere {
	public Inventario inventarioPrefab;   // referencia ao objeto prefab criado do Inventario
	Inventario inventario;
	public HealthBar healthBarPrefab;     // referencia ao objeto prefab criado da HealthBar
	HealthBar healthBar;

	private void Start() {
		inventario = Instantiate(inventarioPrefab);
		pontosDano.valor = inicioPontosDano;
		healthBar = Instantiate(healthBarPrefab);
		healthBar.caracter = this;
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.CompareTag("Coletavel")) {
			Item DanoObjeto = collision.gameObject.GetComponent<Consumable>().item;
			if (DanoObjeto != null) {
				bool DeveDesaparecer = false;
				//print("Acertou: " + DanoObjeto.NomeObjeto);
				switch (DanoObjeto.tipoItem) {
					case Item.TipoItem.MOEDA:
						DeveDesaparecer = inventario.AddItem(DanoObjeto);
						break;

					case Item.TipoItem.HEALTH:
						DeveDesaparecer = AjustePontosDano(DanoObjeto.quantidade);
						break;

					default:
						break;
				}
				if (DeveDesaparecer) {
					collision.gameObject.SetActive(false);
				}
			}
		}
	}			

	public bool AjustePontosDano(int quantidade) {
		if (pontosDano.valor < MaxPontosDano) {
			pontosDano.valor = pontosDano.valor + quantidade;
			print("Ajustando PD por: " + quantidade + ". Novo Valor = " + pontosDano.valor);
			return true;
		}
		return false;
	}
}

