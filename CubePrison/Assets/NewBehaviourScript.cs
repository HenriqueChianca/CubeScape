using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public Image image;
    public float animationDuration = 10f;
    float _time = 0;

    float primeiraNota = 0.29f;
    

    // Update is called once per frame
    void Update()
    {
        if(_time > animationDuration)
        {
            _time += Time.deltaTime;
            float anim = Mathf.Lerp(0, primeiraNota, _time);

            image.material.SetFloat("_Reveal", anim);
        }
        else
        {
            _time = 0;
        }
    }
}


/*using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShaderController : MonoBehaviour
{
    // Referência ao GameObject que contém o componente UI (Image)
    public Image uiImage;

    // Nome da propriedade do shader
    private string revealProperty = "_Reveal";  // Certifique-se de que o nome da propriedade corresponde ao nome exato no shader

    void Start()
    {
        // Inicia a corrotina para alterar o valor de _Reveal ao longo de um segundo
        StartCoroutine(ChangeRevealValueOverTime(0f, 0.32f, 1f));
    }

    // Corrotina para alterar o valor da propriedade Reveal ao longo do tempo
    IEnumerator ChangeRevealValueOverTime(float startValue, float endValue, float duration)
    {
        float elapsedTime = 0f;

        // Verifica se o material está presente
        Material mat = uiImage.material;

        if (mat != null)
        {
            while (elapsedTime < duration)
            {
                // Calcula o valor atual com base no tempo decorrido
                float currentValue = Mathf.Lerp(startValue, endValue, elapsedTime / duration);
                mat.SetFloat(revealProperty, currentValue);

                // Incrementa o tempo decorrido
                elapsedTime += Time.deltaTime;

                // Aguarda o próximo frame
                yield return null;
            }

            // Assegura que o valor final seja definido corretamente
            mat.SetFloat(revealProperty, endValue);
        }
    }
}*/
