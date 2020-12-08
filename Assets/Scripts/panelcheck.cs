using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class panelcheck : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler{
    string panel_text;
    string panel_name;
    Vector3 first_pos;
    Vector3 obj_pos;
    GameObject obj;
    bool check;
    GameObject levelunlock ;

    public static int count = 8;
    // var changeX = 710;
    // var changeY = 454;
    // var changePosition = transform.position;

    void Start()
    {
        levelunlock = GameObject.Find("Sudoku").transform.Find("levelunlock").gameObject;
    }

    void Update()
    {
        if(count == 0)
        {
            levelunlock.SetActive(true);
        }
    }

    public void OnBeginDrag(PointerEventData eventData){
        // throw new System.NotImplementedException();
        first_pos = transform.position;
        panel_name = gameObject.name;
    }

    public void OnDrag(PointerEventData eventData){
        transform.position = eventData.position;
        // throw new System.NotImplementedException();
    }

    public void OnEndDrag(PointerEventData eventData){
        // throw new System.NotImplementedException();
        if(check){
            obj_pos = obj.transform.position;
            panel_text = GetComponent<Image>().sprite.name;
            Debug.Log(panel_text);
            //정답일 시 넣기 가능
            switch (obj.name){
                case "panel1":
                    if(panel_text == "panel2")
                    {
                        MovetoPanel(obj_pos);
                        GetComponent<Image>().raycastTarget = false;
                        count--;
                    }
                    else
                        MovetoPanel(first_pos);
                    break;
                case "panel2":
                    if(panel_text == "panel1")
                    {
                        MovetoPanel(obj_pos);
                        GetComponent<Image>().raycastTarget = false;
                        count--;
                    }
                    else
                        MovetoPanel(first_pos);
                    break;
                case "panel3":
                    if(panel_text == "panel1")
                    {
                        MovetoPanel(obj_pos);
                        GetComponent<Image>().raycastTarget = false;

                        count--;
                    }
                    else
                        MovetoPanel(first_pos);
                    break;
                case "panel4":
                    if(panel_text == "panel3")
                    {
                        MovetoPanel(obj_pos);
                        GetComponent<Image>().raycastTarget = false;

                        count--;
                    }
                    else
                        MovetoPanel(first_pos);
                    break;
                case "panel5":
                    if(panel_text == "panel4")
                    {
                        MovetoPanel(obj_pos);
                        GetComponent<Image>().raycastTarget = false;

                        count--;
                    }
                    else
                        MovetoPanel(first_pos);
                    break;
                case "panel6":
                    if(panel_text == "panel2")
                    {
                        MovetoPanel(obj_pos);
                        GetComponent<Image>().raycastTarget = false;

                        count--;
                    }
                    else
                        MovetoPanel(first_pos);
                    break;
                case "panel7":
                    if(panel_text == "panel2")
                    {
                        MovetoPanel(obj_pos);
                        GetComponent<Image>().raycastTarget = false;

                        count--;
                    }
                    else
                        MovetoPanel(first_pos);
                    break;
                case "panel8":
                    if(panel_text == "panel1")
                    {
                        MovetoPanel(obj_pos);
                        GetComponent<Image>().raycastTarget = false;

                        count--;
                    }
                    else
                        MovetoPanel(first_pos);
                    break;
                default:
                    Debug.Log("Error");
                    break;
            }
        }
        else{
            MovetoPanel(first_pos);
        }
    }

    public void MovetoPanel(Vector3 movepos){
        gameObject.transform.position = movepos;
    }

    public void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag.Equals("panel")){
            Debug.Log("check true");
            check = true;
            obj = other.gameObject;
        }
    }

    public void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag.Equals("panel")){
            Debug.Log("check false");
            check = false;
        }
    }
}