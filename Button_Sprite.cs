using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace MeatRobot.Utils {
  
  private static Func<Camera> GetWorldCamera;
  
  public static void SetGetWorldCamera(Func<Camera> GetWorldCamera) {
    Button_Sprite.GetWorldCamera = GetWorldCamera;
  }
  
  
  
  
  public Action ClickFunc = null;
  public Action MouseRightDownOnceFun = null;
  public Action MouseRightDownFunc = null;
  public Action MouseRightUpFunc = null;
  public Action MouseDownOnceFunc = null;
  public Action MouseUpOnceFunc = null;
  public Action MouseOverOnceFunc = null;
  public Action MouseOutOnceFunc = null;
  public Action MouseOverOnceTooltipFunc = null;
  public Action MouseOutOnceTooltipFunc = null;
  
  private bool draggingMouseRight;
  private Vector3 mouseRightDragStart;
  public Action<Vector3, Vector3> MouseRightDragFunc = null;
  public Action<Vector3, Vector3> MouseRightDragUpdateFunc = null;
  public bool triggerMouseRightDragOnEnter = false;
  
  public enum HoverBehaviour {
    Custom,
    Change_Color,
    Change_Image,
    Change_SetActive,
  }
  public HoverBehaviour hoverBehaviourType = HoverBehaviour.Custom;
  private Action hoverBehaviourFunc_Enter, hoverBehaviourFunc_Exit;
  
  public Color hoverBehaviour_Color_Enter = new Color(1, 1, 1, 1), hoverBehaviour_Color_Exit = new Color(1, 1, 1, 1);
  public SpriteRenderer hoverBehaviour_Image;
  public Sprite hoverBehaviour_Sprite_Exit, hoverBehaviour_Sprite_Enter;
  public bool hoverBehaviour_Move = false;
  public Vector2 hoverBehaviour_Move_Amount = Vector2.zero;
  private Vector3 posExit, posEnter;
  public bool triggerMouseOutFuncOnClick = false;
  public bool clickThroughUI = false;
  
  private Action internalOnMouseDownFunc, internalOnMouseEnterFunc, internalOnMouseExitFunc;
  
 #if SOUND_MANAGER
  public Sound_Manager.Sound mouseOverSound, mouseClickSound;
  #endif
  #if CURSOR_MANAGER
    public CursorManager.CursorType cursorMouseOver, cursorMouseOut;
  #endif
  
  public void SetHoverBehaviourChangeColor(Color colorOver, Color colorOut) {
    hoverBehaviourType = HoverBehaviour.Change_Color;
    hoverBehaviour_Color_Enter = colorOver;
    hoverBehaviour_Color_Exit = colorOut;
    if (hoverBehaviour_Image == null) hoverBehaviour_Image = transform.GetComponent<SpriteRenderer>();
    hoverBehaviour_Image.color = hoverBehaviour_Color_Exit;
    SetupHoverBehaviour();
    }
    void OnMouseDown() {
    
  
  

