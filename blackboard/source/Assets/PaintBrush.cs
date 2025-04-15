using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Valve.VR;
using Valve.VR.InteractionSystem;
using UnityEngine.UI;

public class PaintBrush : MonoBehaviour
{

    public LineRenderer LinkLine = null;
    public float weight = 0.05f;

    public List<Vector3> ClickPosList = new List<Vector3>();
    private List<Vector3> SavePosList = new List<Vector3>();
    private List<Vector3> LostPosList = new List<Vector3>();

    private int count = 0;
    private bool set = false;

    void Start()
    {
        LinkLine.SetWidth(0.05f, 0.05f) ;       
    }


    protected void OnHandHoverBegin(Hand hand)
    {
        Debug.Log("핸들시작");
    }


    protected void HandHoverUpdate(Hand hand)
    {
        GrabTypes type = hand.GetBestGrabbingType(GrabTypes.Grip); //Input.GetMouseButton();
        if (type == GrabTypes.Grip)
        {
            Debug.Log( $"버턴 누름 : {hand.transform.position} ");

            ClickPosList.Add(hand.transform.position);

            LinkLine.positionCount = ClickPosList.Count;
            LinkLine.SetPositions( ClickPosList.ToArray() );

            //count++;
            set = true;
        }
        else
        {

            if (set == true)
            {
                Debug.Log($"버턴 땜");
                SavePosList = ClickPosList;

                //for (int i = 0; i < count; i++)
                //{
                //    SavePosList.RemoveAt(i);
                  
                //}

                //count = ClickPosList.Count;

                //SavePosList.Add(ClickPosList[count]);
                set = false;
            }

        }
      

    }


    protected void OnHandHoverEnd(Hand hand)
    {
      
        Debug.Log("핸들종료");
    }


    public void SetWeight(bool set)
    {
       if(set==true)
        {
            if (weight < 0.1f)
            {
                weight += 0.01f;
            }
        }
        else
        {
            if (weight > 0.01f)
            {
                weight -= 0.01f;
            }
        }

        LinkLine.SetWidth(weight, weight);
    }


    public void SetColor(int set)
    {
        if (set == 1)
        {
            LinkLine.SetColors(Color.red, Color.red);
          
        }
        else if (set == 2)
        {
            LinkLine.SetColors(Color.green, Color.green);
           
        }
        else if (set == 3)
        {
            LinkLine.SetColors(Color.blue, Color.blue);
            
        }
        else
        {
            LinkLine.SetColors(Color.white, Color.white);
         
        }
      
    }


    public void SetLineClear()
    {
        ClickPosList.Clear();
        SavePosList = ClickPosList;

        LinkLine.positionCount = ClickPosList.Count;
        LinkLine.SetPositions(ClickPosList.ToArray());

        count = 0;
    }


    public void SetLineBack()
    {

        SavePosList = ClickPosList;

        ClickPosList = LostPosList;

        LinkLine.positionCount = LostPosList.Count;
        LinkLine.SetPositions(LostPosList.ToArray());

        LostPosList=SavePosList;
     
    }

}
