using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//슬롯 칸 정보
public class Slot : MonoBehaviour
{
    public GameObject ItemInSlot;//현재 들어있는 아이템
    public Image slotImage;//슬롯 이미지
    Color originalColor;//시작컬러

    public int num;

    private void Start()
    {
        slotImage = GetComponentInChildren<Image>();
        originalColor = slotImage.color;//기본 컬러 저장

    }

    private void Update()
    {
        //슬롯 오브젝트 부모 변경 방지
        gameObject.transform.SetParent(GameObject.Find("Inventory").transform, true);
    }


    public void ResetColor()//기본색으로 변경
    {
        slotImage.color = originalColor;
    }

}
