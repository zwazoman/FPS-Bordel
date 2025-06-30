using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InputTest : MonoBehaviour
{
    private async void Start()
    {
        KeyCode[] keys =
            {
            KeyCode.C,
            KeyCode.O,
            KeyCode.N,
            KeyCode.N,
            KeyCode.Q,
            KeyCode.R,
            KeyCode.D,
            };

        print(await InputTools.InputCombination(keys.ToList(), 3));
    }
}
