using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//인벤토리 메뉴 on/off
public class Inventory_VR : MonoBehaviour
{

    private static Inventory_VR s_instance;
    public static Inventory_VR GetInstance { get { Init(); return s_instance; } }

    public GameObject Inventory;

    public GameObject xyz;//플레이어 시야
    public bool UIActive;

    private void Start()
    {
        Inventory.SetActive(false);
        UIActive = false;

    }

    private void Update()
    {
        //UI상시오픈
        if (Input.GetKeyDown(KeyCode.I))
        {
            UIActive = !UIActive;
            Inventory.SetActive(UIActive);
        }

        Inventory.transform.position = xyz.transform.position;

    }


    private static void Init()
    {
        if (!s_instance)
        {
            var go = GameObject.Find("Menu");
            if (!go)
            {
                go = new GameObject { name = "Menu" };
                go.AddComponent<Inventory_VR>();
            }

            s_instance = go.GetComponent<Inventory_VR>();
        }
    }
}
