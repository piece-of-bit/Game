using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public sealed class CustomSlider : UIBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private bool isDragging, isOpen;

    public RectTransform fillRect;

    private RectTransform canvasRect, rectTransform;

    private float fillHeight, imageHeight, minPosY, maxPosY, targetPosY;
    public void Open()
    {
        if (this.isOpen == false && this.isDragging == false) this.isOpen = true;
    }
    public void Close()
    {
        if (this.isOpen && this.isDragging == false) this.isOpen = false;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        this.isDragging = true;
    }
    public void OnDrag(PointerEventData eventData)
    {
        Camera eventCam = eventData.pressEventCamera;
        Vector2 worldPoint = eventCam.ScreenToWorldPoint(eventData.position);
        Vector2 localPoint = this.canvasRect.InverseTransformPoint(worldPoint);
        this.targetPosY = localPoint.y;
    }
    public void OnEndDrag(PointerEventData eventData) 
    {
        this.isDragging = false;
    }
    // Start is called before the first frame update
    protected override void Start()
    {
        Canvas canvas = GetComponentInParent<Canvas>();
        this.canvasRect = canvas.transform as RectTransform;

        this.rectTransform = this.transform as RectTransform;

        this.imageHeight = this.rectTransform.sizeDelta.y;

        Vector3[] fillCorners = new Vector3[4];
        this.fillRect.GetLocalCorners(fillCorners);
        this.fillHeight = Mathf.Abs(fillCorners[0].y * 2f);
        this.maxPosY = fillCorners[0].y + this.imageHeight / 2f;
        this.minPosY = fillCorners[1].y - this.imageHeight / 2f;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateFill();
        UpdatePosition();
    }
    private void UpdateFill()
    {
        float value = GetFillValue();
        float newSizeY = this.fillHeight * value;
        RectTransform.Edge edge = RectTransform.Edge.Bottom;
        this.fillRect.SetInsetAndSizeFromParentEdge(edge, 0f, newSizeY);
    }
    private void UpdatePosition()
    {
        Vector2 currentPos = this.rectTransform.localPosition;
        float yPos = Mathf.Clamp(this.targetPosY, this.maxPosY, this.minPosY);
        this.rectTransform.localPosition = new Vector2(currentPos.x, yPos);

        if (this.isDragging == false)
        {
            float newYPos = (this.isOpen) ? this.maxPosY : this.minPosY;
            float speed = Time.deltaTime * 10f;
            this.targetPosY = Mathf.Lerp(currentPos.y, newYPos, speed);
        }
        float Pos = Mathf.Clamp(this.targetPosY, this.maxPosY, this.minPosY);
        this.rectTransform.localPosition = new Vector2(currentPos.x, yPos);
    }

    private float GetFillValue()
    {
        float currentYPos = this.rectTransform.localPosition.y;
        float diff = currentYPos - this.minPosY;
        float result = -(diff / (this.fillHeight - this.imageHeight));
        return result;
    }
}
