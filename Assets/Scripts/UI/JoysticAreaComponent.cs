using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.OnScreen;


public class JoysticAreaComponent : myOnScreenStick, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] GameObject _joystic;
    [SerializeField] GameObject _area;
    [SerializeField] private Trajectory _tline;
    [SerializeField] private MyLaser _laser;
    [SerializeField] private LayerMask _touchingLayer;
    private Vector2 PointerDownPos;
    private Vector3 PointerStartPos;
   

    public void OnPointerDown(PointerEventData eventData)
    {
       
        PointerStartPos = transform.parent.InverseTransformPoint(eventData.pointerCurrentRaycast.worldPosition);
        _area.GetComponent<RectTransform>().anchoredPosition = PointerStartPos;
        _joystic.GetComponent<myOnScreenStick>().startPose(PointerStartPos);
        _laser.LaserSwitch(true);
       // _tline.TrajectorySwitch(false);
    }
    public void OnDrag(PointerEventData eventData)
    {
        
        if (eventData == null)
            throw new System.ArgumentNullException(nameof(eventData));

        var position1 = transform.parent.InverseTransformPoint(eventData.pointerCurrentRaycast.worldPosition);
        Vector3 delta = position1 - PointerStartPos;
        delta = Vector2.ClampMagnitude(delta, movementRange);
        //Debug.Log(delta);
        _tline.RenderLine(delta/10);
        _laser.SetDirection(delta);
        _joystic.GetComponent<myOnScreenStick>().OnDragPoint(delta);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
       
        _laser.LaserSwitch(false);
        _tline.HideLine();
       // _tline.TrajectorySwitch(false);
        _joystic.GetComponent<myOnScreenStick>().OnPointerUp();
        //ReloadLevelComponent.RL.StartBalls();
        
    }
   

}

   

