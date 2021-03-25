using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Caractere {
	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.CompareTag("Coletavel")) {
			Item DanoObjeto = collision.gameObject.GetComponent<Consumable>().item;
			if (DanoObjeto != null) {
				print("Acertou: " + DanoObjeto.NomeObjeto);
				switch (DanoObjeto.tipoItem) {
					case Item.TipoItem.MOEDA:
						break;

					case Item.TipoItem.HEALTH:
						AjustePontosDano(DanoObjeto.quantidade);
						break;

					default:
						break;
				}
				collision.gameObject.SetActive(false);
			}
		}
	}			

	public void AjustePontosDano(int quantidade) {
		PontosDano = PontosDano + quantidade;
		print("Ajustando Pontos Dano por: " + quantidade + ". Novo Valor = " + PontosDano);
	}
}

