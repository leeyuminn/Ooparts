using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfessorMove : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;
    float rightMax = 8.5f; //좌로 이동가능한 (x)최대값
    float leftMax = -0.5f; //우로 이동가능한 (x)최대값
    float currentPosition; //현재 위치(x) 저장
    float direction = 3.0f; //이동속도+방향

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetInteger("WalkSpeed", (int)direction);
    }
    void Start()
    {
        currentPosition = transform.position.x;
    }

    void FixedUpdate()
    {
        Move();

        currentPosition += Time.deltaTime * direction;
        if (currentPosition >= rightMax)
        {
            direction *= -1;
            currentPosition = rightMax;
        }
        //현재 위치(x)가 우로 이동가능한 (x)최대값보다 크거나 같다면
        //이동속도+방향에 -1을 곱해 반전을 해주고 현재위치를 우로 이동가능한 (x)최대값으로 설정
        else if (currentPosition <= leftMax)
        {
            direction *= -1;
            currentPosition = leftMax;
        }
        //현재 위치(x)가 좌로 이동가능한 (x)최대값보다 크거나 같다면
        //이동속도+방향에 -1을 곱해 반전을 해주고 현재위치를 좌로 이동가능한 (x)최대값으로 설정
        transform.position = new Vector2(currentPosition, transform.position.y);
        //위치를 계산된 현재위치로 처리
    }


    public static float Abs(float a)
    {
        if (a > 0)
        {
            return a;
        }
        else
        {
            a *= (-1);
            return a;//넘겨온 값이 마이너스이면 -(음수)기호로 +로
        }
    }

    void Move()
    {
        //방향 전환 
        Vector3 moveVelocity = Vector3.zero;

        if (direction < 0)
        {
            moveVelocity = Vector3.left;
            transform.localRotation = Quaternion.Euler(0, -180, 0);
            //좌우반전
        }
        else if (direction > 0)
        {
            moveVelocity = Vector3.right;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            //다시 원위치 
        }
        transform.position += moveVelocity * Abs(direction) * Time.deltaTime;
    }
    

}


/*Rigidbody2D rigid;
public int nextMove; //행동지표를 결정(퍼블릭은 알아서 초기화가 됌)

void Awake()
{
    rigid = GetComponent<Rigidbody2D>();
    Think();

    Invoke("Think", 5);
}


void FixedUpdate()
{
    //알아서 움직이기
    rigid.velocity = new Vector2(nextMove, rigid.velocity.y);
}

void Think()
{
    nextMove = Random.Range(-1, 2);
    Invoke("Think", 5);
anim.SetInteger("WalkSpeed", direction);
}*/



