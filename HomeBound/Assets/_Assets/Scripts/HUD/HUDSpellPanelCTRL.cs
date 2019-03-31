using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDSpellPanelCTRL : MonoBehaviour
{
    [HideInInspector]
    public GameObject selectedSpell;
    private GameObject[] spells = new GameObject[3];

    void Start()
    {
        int i = 0;
        foreach (Transform child in transform)
        { 
            spells[i] = child.gameObject;
            i++;
        }

        selectedSpell = spells[0];
        selectedSpell.GetComponent<SpellCTRL>().SelectSpell();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) { toggleSpell(0); }

        if (Input.GetKeyDown(KeyCode.Alpha2)) { toggleSpell(1); }

        if (Input.GetKeyDown(KeyCode.Alpha3)) { toggleSpell(2); }
    }

    void toggleSpell(int i)
    {
        selectedSpell.GetComponent<SpellCTRL>().DeselectSpell();
        selectedSpell = spells[i];
        spells[i].GetComponent<SpellCTRL>().SelectSpell();
    }
}
