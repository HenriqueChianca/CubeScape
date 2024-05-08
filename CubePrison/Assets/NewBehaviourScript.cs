using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public Image image;
    public float animationDuration = 10f;
    float _time = 0;

    float primeiraNota = 0.29f;
    float segundaNota = 0.43f;
    

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
