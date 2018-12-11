using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zero_character_controller : MonoBehaviour {

    //public float speed = 10f;
    public float moveX = 0.0f;
    public float moveY = 0.0f;
    Vector3 dir;

    bool facingRight = true;
    bool canMove = true;

    CharacterController controller;
    // animator variables
    Animator anim;
    int isAttackingHash = Animator.StringToHash("isAttacking");
    int comboNum = Animator.StringToHash("comboNum");
    int attack1Hash = Animator.StringToHash("attack1");
    int attack2Hash = Animator.StringToHash("attack2");
    int attack3Hash = Animator.StringToHash("attack3");

    // sphere colliders for attack (each game object can only have one sphere collider)
    GameObject attack1;
    GameObject attack2;
    GameObject attack3;
    SphereCollider attack1Collider;
    SphereCollider attack2Collider;
    SphereCollider attack3Collider;

    // Use this for initialization
    void Start ()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();

        attack1 = GameObject.Find("attack1Collider");
        attack2 = GameObject.Find("attack2Collider");
        attack3 = GameObject.Find("attack3Collider");

        attack1Collider = attack1.GetComponent<SphereCollider>();
        attack2Collider = attack2.GetComponent<SphereCollider>();
        attack3Collider = attack3.GetComponent<SphereCollider>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        

        // attack combo
        if (Input.GetButtonDown("Fire1"))
        {
            attackCombo();
        }

        canMove = !anim.GetBool(isAttackingHash);

        if (canMove)
        {
            // gets input values and creates a new vector3
            moveX = Input.GetAxis("Horizontal");
            moveY = Input.GetAxis("Vertical");
            dir = Vector3.Normalize(new Vector3(moveX, 0, moveY));

            controller.Move(dir * Time.deltaTime);

            //sets the animator speed value to the larger of the two x and y move values
            anim.SetFloat("speed", Mathf.Max(Mathf.Abs(moveX), Mathf.Abs(moveY)));


            // flips the game object given certain conditions
            if (moveX > 0 && !facingRight)
                Flip();
            else if (moveX < 0 && facingRight)
                Flip();
        }
        else
        {
            anim.SetFloat("speed", 0);
            controller.Move(new Vector3(0,0,0));
        }

       
    }

    // flips the character when turning in a different direction
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    // handles the attack combo
    void attackCombo()
    {
        anim.SetBool(isAttackingHash, true);
        int num = anim.GetInteger(comboNum);
        num++;

        if(num == 1)
        {
            anim.SetBool(attack1Hash, true);
        }
        else if(num == 2)
        {
            anim.SetBool(attack2Hash, true);
        }
        else if(num == 3)
        {
            anim.SetBool(attack3Hash, true);
        }

        num = Mathf.Clamp(num, 0, 3);
        anim.SetInteger(comboNum, num);

    }

    // toggles the spherecollider for attack1
    void toggleAttack1()
    {
        attack1Collider.enabled = !attack1Collider.enabled;
    }

    void toggleAttack2()
    {
        attack2Collider.enabled = !attack2Collider.enabled;
    }

    void toggleAttack3()
    {
        attack3Collider.enabled = !attack3Collider.enabled;
    }
}
