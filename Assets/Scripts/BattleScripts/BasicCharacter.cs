using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCharacter : MonoBehaviour
{
    #region ĳ���� ���� ���� ����
    [Header("ĳ���� ���� ���� ����")]
    
    [SerializeField]
    [Tooltip("���ݷ�")]
    protected int damage;

    [SerializeField]
    [Tooltip("ü��")]
    protected int hp;

    [SerializeField]
    [Tooltip("�̵��ӵ�")]
    protected float speed;
    #endregion

    //[SerializeField]
    //[Tooltip("�ڽ��� Rigidbody2D ������Ʈ")]
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
