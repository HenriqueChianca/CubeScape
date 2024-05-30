using UnityEngine;

public class LightAnimCtrl : MonoBehaviour
{
    private Animator animator;

    // Método chamado antes do primeiro frame
    void Start()
    {
        // Obtém o componente Animator anexado ao GameObject
        animator = GetComponent<Animator>();

        // Inicia a repetição da função para definir aleatoriamente Pisca
        InvokeRepeating("RandomizePisca", Random.Range(10f, 20f), Random.Range(10f, 20f));
    }

    // Função para definir Pisca aleatoriamente entre 1 e 3
    void RandomizePisca()
    {
        float randomSeconds = Random.Range(10f, 20f);
        Debug.Log("Random seconds: " + randomSeconds);

        int randomPisca = Random.Range(1, 4); // Gera um número aleatório entre 1 e 3
        Debug.Log("Random Pisca: " + randomPisca);

        animator.SetInteger("Pisca", randomPisca);
    }

    // Método chamado a cada frame
    void Update()
    {
        // Verifica o valor da variável Pisca no Animator
        int valorPisca = animator.GetInteger("Pisca");

        // Verifica o valor de Pisca e executa a animação correspondente
        switch (valorPisca)
        {
            case 1:
                animator.Play("Pisca 1");
                break;
            case 2:
                animator.Play("Pisca 2");
                break;
            case 3:
                animator.Play("Pisca 3");
                break;
            default:
                // Se Pisca não for 1, 2 ou 3, não faz nada
                break;
        }
    }

    // Função para definir Pisca como 0 (Aceso)
    public void ResetPisca()
    {
        animator.SetInteger("Pisca", 0);
    }
}
