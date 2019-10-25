using UnityEngine;
using UnityEngine.UI;

namespace Complete
{
    public class TankHealth : MonoBehaviour
    {
        public Slider sliderHP;                             // Slider do canvas para a barra de HP
       
        public float vidaInicial = 100f;                    // Vida inicial do player
        private float vidaAtual;                            // Vida atual do player
        public float danoTomado = 50f;

        private bool isMorto;                                // boolean para verificar se o jogador está vivo ou morto;
       
        private void OnEnable()
        {
            vidaAtual = vidaInicial;      // seta a vida atual para a vida inicial (vida maxima)
            isMorto = false;              // define que o jogador não esta morto (ou que está vivo, no caso)

            SetHealthUI();
        }

        public void TakeDamage (float amount)    // função com parametro de dano para descontar da vida atual e fazer a verificação se o player ainda está vivo
        {
            vidaAtual -= amount;

            SetHealthUI ();

            if (vidaAtual <= 0f && !isMorto)
            {
                OnDeath ();
            }
        }

        private void OnTriggerEnter(Collider other)     //função para verificar o colisor do player com os inimigos
        {
           if (other.gameObject.tag == "Enemy")
           {
                TakeDamage(danoTomado);              // passando o parametro de dano para a função TakeDamage
                other.gameObject.SetActive(false);     // "desativando" o inimigo
           }
        }

        private void SetHealthUI ()       // seta o value do slider para o valor da vida atual
        {
            sliderHP.value = vidaAtual;

        }

        void OnDeath ()           // função executada quando o player morre para mudar a Scene para o Game Over
        {
            isMorto = true;

            FindObjectOfType<MudaScene>().EndGame();
        }
    }
}