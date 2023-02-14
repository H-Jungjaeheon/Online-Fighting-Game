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

    [Tooltip("대쉬 파워(힘)")]
    const int DASH_POWER = 1000;

    [Tooltip("대쉬 쿨타임인지 판별")]
    bool isDashCoolTime;

    [Tooltip("대쉬 효과 종료 딜레이")]
    WaitForSeconds dashDelay = new WaitForSeconds(0.1f);

    [Tooltip("대쉬 쿨타임 딜레이")]
    WaitForSeconds dashCoolTime = new WaitForSeconds(2f);
    #endregion

    #region 점프 관련 모음
    [Header("점프 관련 모음")]

    [Tooltip("점프 파워(힘)")]
    const int JUMP_POWER = 675;

    [Tooltip("점프중인지 판별")]
    bool isJumping;
    #endregion

    [SerializeField]
    [Tooltip("강체 범위 오브젝트")]
    GameObject rigidObj;

    [SerializeField]
    [Tooltip("자신의 Rigidbody2D 컴포넌트")]
    Rigidbody2D rigid;

    Vector3 speedVector;

    IEnumerator nowHitAction;

    void Start()
    {
        StartSetting();
    }

    void FixedUpdate()
    {
        Move();
        rigidObj.transform.position = transform.position;
    }

    void StartSetting()
    {
        //Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), GetComponentsInChildren<BoxCollider2D>()[1]);
        speedVector = Vector3.zero;
        speedVector.x = speed;

        StartCoroutine(Dash());
        StartCoroutine(Jump());
    }

    /// <summary>
    /// 캐릭터 점프 함수
    /// </summary>
    /// <returns></returns>
    IEnumerator Jump()
    {
        while (true)
        {
            if (Input.GetKey(KeyCode.W) && isJumping == false)
            {
                isJumping = true;
                rigid.AddForce(Vector2.up * JUMP_POWER);
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
    void Move()
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}
