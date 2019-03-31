using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    Animator anim;
    private float timer;

    [SerializeField]
    [Range(0.5f, 1.5f)]
    private float rateOfSpellFire = 1;

    [SerializeField]
    [Range(1, 10)]
    private float damage = 1;

    [SerializeField]
    private Transform PointOfFire;

    public GameObject[] effect;
    public Transform[] effectTransform;

    private SpellCTRL selectedSpell;
    public HUDSpellPanelCTRL spellPanel;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= rateOfSpellFire)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                selectedSpell = spellPanel.selectedSpell.GetComponent<SpellCTRL>();
                if (selectedSpell.isLive)
                // add which spell functionality here 
                {
                    anim.SetTrigger("castSpell");
                    StartCoroutine(WaitSpellOne());

                    //anim.SetInteger("SkillNumber", 0);
                    //Instantiate(effect[0], effectTransform[0].position, effectTransform[0].rotation);
                } 
                else
                {
                    // play error sound ? 
                }
            }
        }
        
    }


    private void ShootSpell()
    {
        //raycast
        Debug.DrawRay(PointOfFire.position, PointOfFire.forward * 100, Color.red, 2f);
        Ray ray = new Ray(PointOfFire.position, PointOfFire.forward);
        RaycastHit hitInfo;
        //hit handling 
        if(Physics.Raycast(ray, out hitInfo, 100) && hitInfo.transform.tag == "Enemy")
        {
            var enemyHit = hitInfo.collider.GetComponent<EnemyHealth>();
            if (enemyHit != null)
            {
                //print("before: " + enemyHit.currentHealth);
                //print(" - " +selectedSpell.damage);
                enemyHit.TakeDamage(selectedSpell.damage);
                //print("after: " + enemyHit.currentHealth);
            }

            //Destroy(hitInfo.collider.gameObject);
        }
        selectedSpell.CoolDown();
    }

    IEnumerator WaitSpellOne()
    {
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).
            length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime - 0.0f);
        anim.ResetTrigger("castSpell");
    }
}
