using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCharacter : MonoBehaviour
{
    #region 캐릭터 스탯 관련 모음
    [Header("캐릭터 스탯 관련 모음")]
    
    [SerializeField]
    [Tooltip("공격력")]
    protected int damage;

    [SerializeField]
    [Tooltip("체력")]
    protected int hp;

    [SerializeField]
    [Tooltip("이동속도")]
    protected float speed;
    #endregion

    //[SerializeField]
    //[Tooltip("자신의 Rigidbody2D 컴포넌트")]
    //Rigidbody2D rigid;

    Vector3 speedVector;

    IEnumerator nowHitAction;

    private void Start()
    {
        StartSetting();
    }

    void Update()
    {
        Move();
    }

    void StartSetting()
    {
        speedVector = new Vector3(speed, 0, 0);
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= speedVector * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += speedVector * Time.deltaTime;
        }

        //rigid.velocity = Vector3.zero;
    }

    public void Hit(int damage)
    {
        hp -= damage;

        nowHitAction = HitAction();
        StartCoroutine(nowHitAction);
    }

    IEnumerator HitAction()
    {

        yield return null;
    }
}
