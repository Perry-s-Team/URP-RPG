using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightIntencity : MonoBehaviour
{
    private Light2D light2D;
    private float transitionDuration = 5f;
    private float nightIntensity = 0.1f;
    private float dayIntensity = 1.1f;
    private bool isDay = true;
    private float transitionTimer = 0f;

    private void Awake()
    {
        light2D = GetComponent<Light2D>();
    }

    private void Update()
    {
        if (isDay)
        {
            transitionTimer += Time.deltaTime;
        }
        else
        {
            transitionTimer -= Time.deltaTime;
        }

        transitionTimer = Mathf.Clamp(transitionTimer, 0f, transitionDuration);

        float transitionProgress = transitionTimer / transitionDuration;

        light2D.intensity = Mathf.Lerp(dayIntensity, nightIntensity, transitionProgress);

        if (transitionTimer >= transitionDuration && isDay)
        {
            Debug.Log("Наступила ночь!");

            isDay = false;
        }
        else if (transitionTimer <= 0f && !isDay)
        {
            Debug.Log("Наступил день!");

            isDay = true;
        }
    }
}
