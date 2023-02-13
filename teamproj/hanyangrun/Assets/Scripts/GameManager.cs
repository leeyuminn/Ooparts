using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerMove Player;
    public int stageIndex;
    public int health;
    public GameObject[] Stages;

    public void NextStage()
    {
        //change stage
        if(stageIndex < Stages.Length - 1)
        {
            Stages[stageIndex].SetActive(false); //stage1 현재거 비활성화 //..?
            stageIndex++;
            Stages[stageIndex].SetActive(true); //stage2 활성화
            PlayerReposition();

        }
        else
        {
           //Game clear
            Time.timeScale = 0;
            Debug.Log("도착!");
        }
        
    }

    public void HealthDown()
    {
        if (health > 1)
        {
            health--;
            Debug.Log("안돼~~~~~~!");
        }
        else
        {
            //UI
            Debug.Log("죽었습니다!");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(health > 1)
            {
                //Player reposition
                PlayerReposition();
            }
            //heath down
            HealthDown();

            
        }
    }

    public void PlayerReposition()
    {
        Player.transform.position = new Vector3(-54.43f, -9.83f, 0);
        Player.VelocityZero();
    }
}
