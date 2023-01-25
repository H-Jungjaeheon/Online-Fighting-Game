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

    #region 대쉬 관련 모음
    [Header("대쉬 관련 모음")]

    [Tooltip("대쉬 파워(속력)")]
    private const int DASH_POWER = 1000;

    [Tooltip("대쉬 쿨타임인지 판별")]
    private bool isDashCoolTime;

    [Tooltip("대쉬 효과 종료 딜레이")]
    WaitForSeconds dashDelay = new WaitForSeconds(0.1f);

    [Tooltip("대쉬 쿨타임 딜레이")]
    WaitForSeconds dashCoolTime = new WaitForSeconds(2f);
    #endregion

    [SerializeField]
    [Tooltip("자신의 Rigidbody2D 컴포넌트")]
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
    /// 대쉬 키 입력 받고 대쉬 시작하는 함수
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
    /// 대쉬 쿨타임 및 대쉬 효과 종료 함수
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
    /// 이동 함수
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
    /// 공격 맞았을 때 실행하는 함수
    /// </summary>
    /// <param name="damage"> 현재 받은 데미지 </param>
    public void Hit(int damage)
    {
        hp -= damage;

        nowHitAction = HitAction();
        StartCoroutine(nowHitAction);
    }

    /// <summary>
    /// 공격 맞았을 때 캐릭터 효과 함수
    /// </summary>
    /// <returns></returns>
    IEnumerator HitAction()
    {

        yield return null;
    }
}
