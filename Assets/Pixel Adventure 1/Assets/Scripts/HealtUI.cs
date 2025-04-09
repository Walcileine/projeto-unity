using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthSystem : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    // Propriedade pública para acessar a vida atual
    public int CurrentHealth
    {
        get { return currentHealth; }
    }

    void Start()
    {
        currentHealth = maxHealth;
    }

    // Método para tomar dano
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Método de morte
    void Die()
    {
        // Aqui pode colocar animação ou tela de Game Over
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // reinicia a fase
    }
}
