using UnityEngine.Serialization;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.UI;

namespace UnityEngine.InputSystem.OnScreen
{
    public class myOnScreenStick : OnScreenControl
    {
        private bool _isTouching;
        [SerializeField] private Color _touchedColor;
       
        public void startPose(Vector3 start)
        {
            m_StartPos = ((RectTransform)transform).anchoredPosition = start;
            _isTouching = true;
        }
        public void OnDragPoint(Vector2 delta)
        {
            Vector3 newDelta = new Vector3(delta.x, delta.y, 0);
            ((RectTransform)transform).anchoredPosition = m_StartPos + newDelta;
            var newPos = new Vector2(delta.x / movementRange, delta.y / movementRange);
            SendValueToControl(newPos);
        }
        public void OnPointerUp()
        {
            ((RectTransform)transform).anchoredPosition = m_StartPos;
            SendValueToControl(Vector2.zero);
            _isTouching = false;
           
        }
        private void Update()
        {
            if (_isTouching)
            {
                _touchedColor.a = 1;
            }
            else
            {
                _touchedColor.a = Mathf.Lerp(_touchedColor.a, 0, Time.deltaTime * 2);
                
            }
            this.GetComponent<Image>().color = _touchedColor;
        }

        public float movementRange
        {
            get => m_MovementRange;
            set => m_MovementRange = value;
        }

        [FormerlySerializedAs("movementRange")]
        [SerializeField]
        protected float m_MovementRange = 50;

        [InputControl(layout = "Vector2")]
        [SerializeField]
        private string m_ControlPath;
        
        private Vector3 m_StartPos;

        protected override string controlPathInternal
        {
            get => m_ControlPath;
            set => m_ControlPath = value;
        }
    }
}