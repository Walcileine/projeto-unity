using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Colisão detectada com: " + other.name); // Adicione esta linha para depuração
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entrou na zona de morte!"); // Adicione esta linha para depuração
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1); // tira 1 de vida ao cair no buraco
                Debug.Log("Player tomou dano!"); // Adicione esta linha para depuração

                // Se quiser reiniciar a fase ao morrer, ele faz isso no script PlayerHealth
            }
        }
    }
}