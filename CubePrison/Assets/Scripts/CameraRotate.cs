using UnityEngine;
using UnityEngine.UI;

public class CameraRotate : MonoBehaviour
{
    public Animator cameraAnimator;
    public Button leftButton;
    public Button rightButton;
    public Button upButton;
    public Button downButton;
    public BoxCollider[] BoxCollidersEsquerda;

    private int currentDirection = 0; // 0 = frente, 1 = direita, 2 = esquerda, 3 = trás, 4 = teto

    void Start()
    {
        // Atribui ouvintes para os cliques nos botões
        leftButton.onClick.AddListener(RotateLeft);
        rightButton.onClick.AddListener(RotateRight);
        upButton.onClick.AddListener(RotateUp);
        downButton.onClick.AddListener(RotateDown);
        UpdateColliders();
    }

    void RotateLeft()
    {
        if (currentDirection == 4)
        {
            // Teto está visível, mapeie para a esquerda
            currentDirection = 2;
            downButton.gameObject.SetActive(false); // Desativa o botão para baixo
        }
        else
        {
            // Rotação lateral normal
            currentDirection = (currentDirection == 0) ? 2 : (currentDirection == 2) ? 3 : (currentDirection == 3) ? 1 : 0;
            UpdateColliders();
        }

        // Atualiza o parâmetro do Animator para refletir a nova orientação da câmera
        cameraAnimator.SetInteger("NumeroParede", currentDirection);
    }

    void RotateRight()
    {
        if (currentDirection == 4)
        {
            // Teto está visível, mapeie para a direita
            currentDirection = 1;
            downButton.gameObject.SetActive(false); // Desativa o botão para baixo
        }
        else
        {
            // Rotação lateral normal
            currentDirection = (currentDirection == 0) ? 1 : (currentDirection == 1) ? 3 : (currentDirection == 3) ? 2 : 0;
            UpdateColliders();
        }

        // Atualiza o parâmetro do Animator para refletir a nova orientação da câmera
        cameraAnimator.SetInteger("NumeroParede", currentDirection);
    }

    void RotateUp()
    {
        // Rotação para o teto
        currentDirection = (currentDirection != 4) ? 4 : (currentDirection == 4) ? 3 : 0;
        downButton.gameObject.SetActive(true); // Ativa o botão para baixo

        // Atualiza o parâmetro do Animator para refletir a nova orientação da câmera
        cameraAnimator.SetInteger("NumeroParede", currentDirection);
    }

    void RotateDown()
    {
        // Rotação para baixo (voltar à visualização lateral)
        currentDirection = 0;
        downButton.gameObject.SetActive(false); // Desativa o botão para baixo

        // Atualiza o parâmetro do Animator para refletir a nova orientação da câmera
        cameraAnimator.SetInteger("NumeroParede", currentDirection);
        UpdateColliders();
    }

    public void UpdateColliders()
    {
         DisableAllColliders();

         switch (currentDirection)
        {
            case 0:
        
                break;
            case 1:
                
                break;
            case 2:
                EnableColliders(BoxCollidersEsquerda);
                break;
            case 3:
                
                break;
            default:
                Debug.LogWarning("Índice selecionado fora do intervalo. Nenhum collider será ativado.");
                break;
        }
    }

    void DisableAllColliders()
    {
        DisableColliders(BoxCollidersEsquerda);
    }

    void DisableColliders(BoxCollider[] colliders)
    {
        foreach (BoxCollider collider in colliders)
        {
            if (collider != null)
            {
                collider.enabled = false;
            }
        }
    }

    void EnableColliders(BoxCollider[] colliders)
    {
        foreach (BoxCollider collider in colliders)
        {
            if (collider != null)
            {
                collider.enabled = true;
            }
        }
    }
}
