using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//���� ĭ ����
public class Slot : MonoBehaviour
{
    public GameObject ItemInSlot;//���� ����ִ� ������
    public Image slotImage;//���� �̹���
    Color originalColor;//�����÷�

    public int num;

    private void Start()
    {
        slotImage = GetComponentInChildren<Image>();
        originalColor = slotImage.color;//�⺻ �÷� ����

    }

    private void Update()
    {
        //���� ������Ʈ �θ� ���� ����
        gameObject.transform.SetParent(GameObject.Find("Inventory").transform, true);
    }


    public void ResetColor()//�⺻������ ����
    {
        slotImage.color = originalColor;
    }

}
