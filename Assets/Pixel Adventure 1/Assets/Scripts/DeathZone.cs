using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Colis�o detectada com: " + other.name); // Adicione esta linha para depura��o
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entrou na zona de morte!"); // Adicione esta linha para depura��o
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1); // tira 1 de vida ao cair no buraco
                Debug.Log("Player tomou dano!"); // Adicione esta linha para depura��o

                // Se quiser reiniciar a fase ao morrer, ele faz isso no script PlayerHealth
            }
        }
    }
}