using System;
using UnityEngine;
using UnityEngine.UI;

namespace CodeMonkey.Utils {
  
  
  public class UI_Bar {
    
    public GameObject gameObject;
    private RectTransform rectTransform;
    private RectTransform background;
    private RectTransform bar;
    private Vector2 size;
    
    public class Outline {
      public float size = 1f;
      public Color color = Color.black;
      public Outline(float size, Color color) {
        this.size = size;
        this.color = color;
      }
    }
    
    public UI_Bar(Transform parent, Vector2 anchoredPosition, Vector2 size, Color barColor, float sizeRatio) {
      SetupParent(parent, anchoredPosition, size);
      SetupBar(barColor);
      SetSize(sizeRatio);
    }
    public UI_Bar(Transform parent, Vector2 anchoredPosition, Vector2 size, Color barColor, float sizeRatio, Outline outline) {
      SetupParent(parent, anchoredPosition, size);
      if (outline != null)


