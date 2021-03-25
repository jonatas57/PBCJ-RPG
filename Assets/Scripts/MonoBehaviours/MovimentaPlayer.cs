using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentaPlayer : MonoBehaviour {
	public float VelocidadeMovimento = 3.0f;      // equivale ao momento (impulso) a ser dado ao player
	Vector2 Movimento = new Vector2();            // detectar movimento pelo teclado

	Animator animator;                            // guarda a componente Controlador de Animação
	string estadoAnimacao = "EstadoAnimacao";			// guarda o nome do parametro de animacao
	Rigidbody2D rb2D;                             // guarda a componente CorpoRigido do Player


	enum EstadoAnimacao {
		idle,
		andaLeste,
		andaOeste,
		andaNorte,
		andaSul
	}

	// Start is called before the first frame update
	void Start() {
		animator = GetComponent<Animator>();
		rb2D = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update() {
		UpdateEstado();
	}

	private void FixedUpdate() {
		MoveCaractere();
	}

	private void MoveCaractere() {
		Movimento.x = Input.GetAxisRaw("Horizontal");
    Movimento.y = Input.GetAxisRaw("Vertical");
		Movimento.Normalize();
		rb2D.velocity = Movimento * VelocidadeMovimento;
	}

	private void UpdateEstado() {
		if (Movimento.x > 0) {
			animator.SetInteger(estadoAnimacao, (int)EstadoAnimacao.andaLeste);
		}
		else if (Movimento.x < 0) {
			animator.SetInteger(estadoAnimacao, (int)EstadoAnimacao.andaOeste);
		}
		else if (Movimento.y > 0) {
			animator.SetInteger(estadoAnimacao, (int)EstadoAnimacao.andaNorte);
		}
		else if (Movimento.y < 0) {
			animator.SetInteger(estadoAnimacao, (int)EstadoAnimacao.andaSul);
		}
		else {
			animator.SetInteger(estadoAnimacao, (int)EstadoAnimacao.idle);
		}
	}
}
