using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
  //  public Animator animator;

    public Transform attackPoint; // The point from which the wepons range is calculated
    public float mainAttackRange = 0.5f;// the range the wepon can attack up to
    public float seccondAttackRange = 1.75f;//seccondary attacks range
    public LayerMask enemyLayers;// defines what an enemy is

    public int mainAttackDamage = 1;// the players damage
    public int seccondAttackDamage = 10;//seccondarys attack damage
    public int amoCountMax = 5; //players amo count 
    int amoCount = 0;

    private void Start()
    {
        amoCount = amoCountMax;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))//triggers when left mouse click is clicked
        {
            if (amoCount >= 0)
            {
                MainAttack();
            } 
            else
            Debug.Log("Out of amo");  //will play a ui element telling the player to reload
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))//secondary attack
        {
            if (amoCount == amoCountMax)//only attacks if player has max ammo
            {
                SecondAttack();
            }
            else
                Debug.Log("Not enough ammo to powwer attack");//will play a ui element telling the player they dont have enough ammo

        }      
    }

    void MainAttack()// the mainAttack function 
    {
        //play the attack animation, to be fully implemented once animator is ready
        // animator.SetTrigger("Attack"); // name of the trigger will go in the brakets


        //detect enemies in range

        amoCount--;

        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, mainAttackRange, enemyLayers);


        //damage them
        foreach (Collider enemy in hitEnemies)
        {
            //damage the enemies
            Debug.Log("Hit" + enemy.name);

            enemy.GetComponent<Enemy>().TakeDamage(mainAttackDamage);//calls the enemy script and allows damage to be done 
        }
    }

    void SecondAttack()//seccondary attack, right mouse click
    {
        //play the attack animation, to be fully implemented once animator is ready
        // animator.SetTrigger("Attack"); // name of the trigger will go in the brakets


        //detect enemies in range

        amoCount = 0;

        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, seccondAttackRange, enemyLayers);


        //damage them
        foreach (Collider enemy in hitEnemies)
        {
            //damage the enemies
            Debug.Log("Hit" + enemy.name);

            enemy.GetComponent<Enemy>().TakeDamage(seccondAttackDamage);//calls the enemy script and allows damage to be done 
        }
    }

   public void Reload()
   {

        Debug.Log("Reloaded");//logs a reload
        amoCount = amoCountMax;//sets current amo = to max amo
   }

    private void OnDrawGizmosSelected()//draws the main attacks range
    {
        
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(attackPoint.position, mainAttackRange);
    }

    private void OnDrawGizmos()//draws the seccondary attacks range
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position , seccondAttackRange);
    }
}