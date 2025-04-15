using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Valve.VR;
using Valve.VR.InteractionSystem;
using UnityEngine.UI;


//아이템 상호작용
public class Item : MonoBehaviour
{

    public GameObject CollidingObj;//자기자신
    public Camera cam;//플레이어 시야

    public bool inSlot = false;//슬롯에 들어가 있는가
    public Slot CurrentSlot;//들어가 있는 슬롯
    public int num;//슬롯 번호(장비 구분용)

    private bool Swap = false;//스왑중 체크


    protected void OnHandHoverBegin(Hand hand)
    {
        //Debug.Log("핸들시작");
    }


    protected void HandHoverUpdate(Hand hand)
    {

        GrabTypes type = hand.GetBestGrabbingType(GrabTypes.Grip); //Input.GetMouseButton();
        if (type == GrabTypes.Grip) //집었을때
        {
            //오브젝트 부모를 아이템 위치로 변경
            CollidingObj.transform.SetParent(GameObject.Find("Item").transform, true);
            Inventory_VR.GetInstance.Inventory.SetActive(true);//UI띄우기

            //카메라 각도별 집은 오브젝트 위치 떨어트리기
            if (cam.transform.eulerAngles.y % 360 <= 45f || cam.transform.eulerAngles.y % 360 >= 315f)
            {
                CollidingObj.transform.position = new Vector3(hand.transform.position.x, hand.transform.position.y, cam.transform.position.z + 1.5f);
            }
            else if (cam.transform.eulerAngles.y % 360 >= 45f && cam.transform.eulerAngles.y % 360 <= 135f)
            {
                CollidingObj.transform.position = new Vector3(cam.transform.position.x + 1.5f, hand.transform.position.y, hand.transform.position.z);
            }
            else if (cam.transform.eulerAngles.y % 360 >= 135f && cam.transform.eulerAngles.y % 360 <= 225f)
            {
                CollidingObj.transform.position = new Vector3(hand.transform.position.x, hand.transform.position.y, cam.transform.position.z - 1.5f);
            }
            else if (cam.transform.eulerAngles.y % 360 >= 225f && cam.transform.eulerAngles.y % 360 <= 315f)
            {
                CollidingObj.transform.position = new Vector3(cam.transform.position.x - 1.5f, hand.transform.position.y, hand.transform.position.z);
            }



        }
        else//놓앗을때
        {

            if (inSlot)//슬롯에 들어가 있다면
            {
                //오브젝트 위치 슬롯 중앙에 맞추고 해당 슬롯 부모 밑에 아이템 오브젝트를 옮김
                CollidingObj.transform.position = CurrentSlot.transform.position;
                CollidingObj.transform.SetParent(CurrentSlot.transform, true);
            }


            if (Inventory_VR.GetInstance.UIActive != true)//UI상시 오픈이 아닐때만 UI 닫힘
            {
                Inventory_VR.GetInstance.Inventory.SetActive(false);
            }
        }
    }

    //슬롯과 아이템이 충돌중일 떄
    private void OnTriggerEnter(Collider other)
    {

        GameObject obj = other.gameObject;
        //Debug.Log("아이템 이름:" + obj);

        if (obj.GetComponent<Slot>().ItemInSlot != null)//해당 슬롯에 아이템이 들어있다면
        {
            return;
        }
        else
        {
            //슬롯 번호가 0이거나 아이템이랑 슬롯번호가 같을 때(0:all, 1:머리, 2:갑옷, 3:바지, 4:무기)
            if (obj.GetComponent<Slot>().num == 0 || obj.GetComponent<Slot>().num == num)
            {
                if (CurrentSlot != null)//아이템이 들어가있는 슬롯이 없다면
                {
                    if (CurrentSlot != obj.GetComponent<Slot>())//슬롯에서 슬롯으로 옮기는 거라면
                    {

                        CurrentSlot.GetComponent<Slot>().ItemInSlot = null;
                        CurrentSlot.transform.parent = null;
                        CurrentSlot.ResetColor();
                        Swap = true;
                    }
                }

                //아이템 삽입
                gameObject.transform.localPosition = Vector3.zero;
                inSlot = true;
                CurrentSlot = obj.GetComponent<Slot>();
                obj.GetComponent<Slot>().ItemInSlot = gameObject;
                obj.GetComponent<Slot>().slotImage.color = Color.gray;
                CollidingObj.transform.position = CurrentSlot.transform.position;
            }
            else//들어갈 수 없는 슬롯
            {
                obj.GetComponent<Slot>().slotImage.color = Color.red;
            }
        }

    }

    //충돌이 끝났을 때
    private void OnTriggerExit(Collider other)
    {
        if (Swap == false)//슬롯 스왑이 아닐때만
        {
            //Debug.Log("충돌 끝! " + other);

            GameObject obj = other.gameObject;          
            obj.GetComponent<Slot>().ItemInSlot = null;
            obj.transform.parent = null;
            inSlot = false;
            obj.GetComponent<Slot>().ResetColor();
            CurrentSlot = null;


        }
        else
        {
            Swap = false;
        }

    }


    protected void OnHandHoverEnd(Hand hand)
    {


    }



}
