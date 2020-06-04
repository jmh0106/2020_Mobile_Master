using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerState : MonoBehaviour
{
    int PlayerHp;
    int PlayerWater;
    int PlayerFood;

    public Slider PlayerHpSlider;
    public Slider PlayerWaterSlider;
    public Slider PlayerFoodSlider;

    private void Start()
    {
        PlayerHp = PlayerWater = PlayerFood = 100;
        StartCoroutine(PlayerStateDecrease());
    }

    private void Update()
    {
        PlayerUIUpdate();
    }

    void PlayerUIUpdate()
    {
        PlayerHpSlider.value = PlayerHp;
        PlayerWaterSlider.value = PlayerWater;
        PlayerFoodSlider.value = PlayerFood;
    }

    IEnumerator PlayerStateDecrease()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            PlayerWater--;
            PlayerFood--;
        }
    }
}
