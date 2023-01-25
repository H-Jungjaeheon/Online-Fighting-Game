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

    #region �뽬 ���� ����
    [Header("�뽬 ���� ����")]

    [Tooltip("�뽬 �Ŀ�(�ӷ�)")]
    private const int DASH_POWER = 1000;

    [Tooltip("�뽬 ��Ÿ������ �Ǻ�")]
    private bool isDashCoolTime;

    [Tooltip("�뽬 ȿ�� ���� ������")]
    WaitForSeconds dashDelay = new WaitForSeconds(0.1f);

    [Tooltip("�뽬 ��Ÿ�� ������")]
    WaitForSeconds dashCoolTime = new WaitForSeconds(2f);
    #endregion

    [SerializeField]
    [Tooltip("�ڽ��� Rigidbody2D ������Ʈ")]
    Rigidbody2D rigid;

    Vector3 speedVector;

    IEnumerator nowHitAction;

    private void Start()
    {
        StartSetting();
    }

    void FixedUpdate()
    {
        Move();
    }

    void StartSetting()
    {
        speedVector = new Vector3(speed, 0, 0);
        StartCoroutine(Dash());
    }

    IEnumerator Jump()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                rigid.AddForce(Vector2.up * 10);
            }

            yield return null;
        }
    }

    /// <summary>
    /// �뽬 Ű �Է� �ް� �뽬 �����ϴ� �Լ�
    /// </summary>
    /// <returns></returns>
    IEnumerator Dash()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && isDashCoolTime == false)
            {
                if (Input.GetKey(KeyCode.A))
                {
                    rigid.AddForce(Vector2.left * DASH_POWER);
                }
                else
                {
                    rigid.AddForce(Vector2.right * DASH_POWER);
                }

                isDashCoolTime = true;

                StartCoroutine(DashEffect());
            }

            yield return null;
        }
    }

    /// <summary>
    /// �뽬 ��Ÿ�� �� �뽬 ȿ�� ���� �Լ�
    /// </summary>
    /// <returns></returns>
    IEnumerator DashEffect()
    {
        yield return dashDelay;

        rigid.velocity = Vector2.zero;

        yield return dashCoolTime;

        isDashCoolTime = false;
    }

    /// <summary>
    /// �̵� �Լ�
    /// </summary>
    private void Move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= speedVector * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += speedVector * Time.deltaTime;
        }
    }

    /// <summary>
    /// ���� �¾��� �� �����ϴ� �Լ�
    /// </summary>
    /// <param name="damage"> ���� ���� ������ </param>
    public void Hit(int damage)
    {
        hp -= damage;

        nowHitAction = HitAction();
        StartCoroutine(nowHitAction);
    }

    /// <summary>
    /// ���� �¾��� �� ĳ���� ȿ�� �Լ�
    /// </summary>
    /// <returns></returns>
    IEnumerator HitAction()
    {

        yield return null;
    }
}
