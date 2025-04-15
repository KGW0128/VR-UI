using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Valve.VR;
using Valve.VR.InteractionSystem;
using UnityEngine.UI;


//������ ��ȣ�ۿ�
public class Item : MonoBehaviour
{

    public GameObject CollidingObj;//�ڱ��ڽ�
    public Camera cam;//�÷��̾� �þ�

    public bool inSlot = false;//���Կ� �� �ִ°�
    public Slot CurrentSlot;//�� �ִ� ����
    public int num;//���� ��ȣ(��� ���п�)

    private bool Swap = false;//������ üũ


    protected void OnHandHoverBegin(Hand hand)
    {
        //Debug.Log("�ڵ����");
    }


    protected void HandHoverUpdate(Hand hand)
    {

        GrabTypes type = hand.GetBestGrabbingType(GrabTypes.Grip); //Input.GetMouseButton();
        if (type == GrabTypes.Grip) //��������
        {
            //������Ʈ �θ� ������ ��ġ�� ����
            CollidingObj.transform.SetParent(GameObject.Find("Item").transform, true);
            Inventory_VR.GetInstance.Inventory.SetActive(true);//UI����

            //ī�޶� ������ ���� ������Ʈ ��ġ ����Ʈ����
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
        else//��������
        {

            if (inSlot)//���Կ� �� �ִٸ�
            {
                //������Ʈ ��ġ ���� �߾ӿ� ���߰� �ش� ���� �θ� �ؿ� ������ ������Ʈ�� �ű�
                CollidingObj.transform.position = CurrentSlot.transform.position;
                CollidingObj.transform.SetParent(CurrentSlot.transform, true);
            }


            if (Inventory_VR.GetInstance.UIActive != true)//UI��� ������ �ƴҶ��� UI ����
            {
                Inventory_VR.GetInstance.Inventory.SetActive(false);
            }
        }
    }

    //���԰� �������� �浹���� ��
    private void OnTriggerEnter(Collider other)
    {

        GameObject obj = other.gameObject;
        //Debug.Log("������ �̸�:" + obj);

        if (obj.GetComponent<Slot>().ItemInSlot != null)//�ش� ���Կ� �������� ����ִٸ�
        {
            return;
        }
        else
        {
            //���� ��ȣ�� 0�̰ų� �������̶� ���Թ�ȣ�� ���� ��(0:all, 1:�Ӹ�, 2:����, 3:����, 4:����)
            if (obj.GetComponent<Slot>().num == 0 || obj.GetComponent<Slot>().num == num)
            {
                if (CurrentSlot != null)//�������� ���ִ� ������ ���ٸ�
                {
                    if (CurrentSlot != obj.GetComponent<Slot>())//���Կ��� �������� �ű�� �Ŷ��
                    {

                        CurrentSlot.GetComponent<Slot>().ItemInSlot = null;
                        CurrentSlot.transform.parent = null;
                        CurrentSlot.ResetColor();
                        Swap = true;
                    }
                }

                //������ ����
                gameObject.transform.localPosition = Vector3.zero;
                inSlot = true;
                CurrentSlot = obj.GetComponent<Slot>();
                obj.GetComponent<Slot>().ItemInSlot = gameObject;
                obj.GetComponent<Slot>().slotImage.color = Color.gray;
                CollidingObj.transform.position = CurrentSlot.transform.position;
            }
            else//�� �� ���� ����
            {
                obj.GetComponent<Slot>().slotImage.color = Color.red;
            }
        }

    }

    //�浹�� ������ ��
    private void OnTriggerExit(Collider other)
    {
        if (Swap == false)//���� ������ �ƴҶ���
        {
            //Debug.Log("�浹 ��! " + other);

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
