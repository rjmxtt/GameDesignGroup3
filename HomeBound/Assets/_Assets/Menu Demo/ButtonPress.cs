using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPress : MonoBehaviour
{
    [SerializeField] RawImage screen;

    [SerializeField] Texture thisImage;

    public void ButtonClicked()
    {
        screen.texture = thisImage;
        Debug.Log("texture change - " + this.ToString());
    }
}
