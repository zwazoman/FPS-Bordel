using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public static class InputTools
{
    public enum InputDirection {Left, Right, Up, Down }

    /// <summary>
    /// checks if the player is holding the holding key for the right amount of time. returns the completion of the action
    /// </summary>
    /// <param name="holdingKey"></param>
    /// <param name="duration"></param>
    /// <returns></returns>
    public static async Task InputHold(KeyCode holdingKey, float duration)
    {
        float completion = 0f; // completion percentage on a 1 basis
        float timer = 0f;

        while (timer < duration)
        {
            if (Input.GetKey(holdingKey))
                timer += Time.deltaTime;

            completion = timer / duration;

            await Task.Yield();
        }
    }

    public static async Task InputMash(KeyCode mashingKey, float pressvalue, float decreaseRate, float mashThreshold)
    {
        float mashValue = 0f;

        while(mashValue < mashThreshold)
        {
            if (Input.GetKeyDown(mashingKey))
                mashValue += pressvalue;

            mashValue -= Time.deltaTime * decreaseRate;

            mashValue = Mathf.Clamp(mashValue, 0f, mashThreshold);

            await Task.Yield();
        }
    }

    public static async Task<bool> InputCombination(List<KeyCode> keys, float maxDelay)
    {
        int cpt = 0;
        float timer = 0f;

        while(cpt < keys.Count && timer <= maxDelay)
        {
            if (Input.GetKeyDown(keys[cpt]))
            {
                cpt++;
                timer = 0f;
                Debug.Log("right key pressed !");
            }

            timer += Time.deltaTime;

            await Task.Yield();
        }

        if (timer >= maxDelay)
            return false;
        return true;

    }

    public static InputDirection MouseMove()
    {
        return InputDirection.Left;
    }
}
