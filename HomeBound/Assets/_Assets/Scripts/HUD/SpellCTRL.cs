using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellCTRL : MonoBehaviour
{
    public Image icon;
    public Image highlight;

    public int damage;
    public float cooldownTime;

    [HideInInspector]
    public bool isLive = true; 

    public void SelectSpell()
    {
        highlight.GetComponent<Image>().color = new Color(255, 255, 255, 255);
    }

    public void CoolDown()
    {
        isLive = false;
        highlight.GetComponent<Image>().color = new Color(255, 0, 0, 255);
        StartCoroutine(Wait());
        //DeselectSpell();
    }

    public void DeselectSpell()
    {
        if (isLive)
        {
            highlight.GetComponent<Image>().color = new Color(255, 255, 255, 0);
            //isLive = true;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(cooldownTime);
        isLive = true;
        DeselectSpell();
    }
}
