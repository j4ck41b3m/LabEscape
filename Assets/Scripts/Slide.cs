using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slide : MonoBehaviour
{
    public Slider staminaSlider;
    public float currentStamina, maxStamina, losingStamina, MaxValue, regenerateAmount, staminaRegenerateStaminaTime;

    Coroutine mCoroutineLosing;
    Coroutine mCoroutineRegenerate;

    public float MaxStamina;
    // Start is called before the first frame update
    void Start()
    {
        currentStamina = maxStamina;
        staminaSlider.maxValue = maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UseStamina(float amount)
    {
        if (currentStamina - amount > 0)
        {
            if (mCoroutineLosing != null)
            {
                StopCoroutine(mCoroutineLosing);
            }
            mCoroutineLosing = StartCoroutine(LosingStaminaCoroutine(amount));
            if (mCoroutineRegenerate != null)
            {
                StopCoroutine(mCoroutineRegenerate);
            }
            mCoroutineRegenerate = StartCoroutine(RegenerateStaminaCoroutine());
        }
    }

    private IEnumerator LosingStaminaCoroutine(float amount)
    {
        while(currentStamina >= 0)
        {
            currentStamina -= amount;
            staminaSlider.value = currentStamina;
            yield return new WaitForSeconds(losingStamina);
        }
        mCoroutineLosing = null;
        FindObjectOfType<PlayerMovement>().isSprinting = false;
    }

    private IEnumerator RegenerateStaminaCoroutine()
    {
        yield return new WaitForSeconds(1);
        while(currentStamina > maxStamina)
        {
            currentStamina += regenerateAmount;
            yield return new WaitForSeconds(staminaRegenerateStaminaTime);
        }
    }
}
