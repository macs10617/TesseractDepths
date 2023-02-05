using UnityEngine;

public class MouseDragComponent : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _moveForce;
    [SerializeField] private float _maxGrabDistance;
    [SerializeField] private LayerMask _draggableMask;
    private DraggableObject _target;
    private Vector3 _targetScreenPosition;
    private Vector3 _targetPosition;
    private float _distance;

    void Update()
    {
        if (!_camera)
            return;

        if (InputManager.Instance.IsInputEnabled(MyInputType.DragObjects))
            if (Input.GetMouseButtonDown(0))
            {
                _target = GetTargetFromClick();
                if (_target && !_target.CanDrag) _target = null;
            }

        if (InputManager.Instance.IsInputEnabled(MyInputType.InvertGravity))
            if (Input.GetMouseButtonDown(1))
            {
                InvertRigidbodyGravity();
            }

        if (Input.GetMouseButtonUp(0) && _target)
        {
            _target = null;
        }
    }

    void FixedUpdate()
    {
        if (_target)
        {
            Vector3 mousePositionOffset =
                _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _distance)) -
                _targetScreenPosition;
            _target.SetVelocity((_targetPosition + mousePositionOffset - _target.transform.position) *
                                (_moveForce * Time.deltaTime));
            _target.SetRotation(new Vector3(0f, _rotationSpeed * Input.GetAxis("Mouse ScrollWheel"), 0f));
        }
    }

    private DraggableObject GetTargetFromClick()
    {
        RaycastHit hitInfo = new RaycastHit();
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        bool hit = Physics.Raycast(ray, out hitInfo, _maxGrabDistance);
        if (hit)
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out DraggableObject draggableObject))
            {
                _distance = Vector3.Distance(ray.origin, hitInfo.point);
                _targetScreenPosition =
                    _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _distance));
                _targetPosition = hitInfo.collider.transform.position;
                return draggableObject;
            }
        }

        return null;
    }

    private void InvertRigidbodyGravity()
    {
        DraggableObject target = GetTargetFromClick();
        if (target)
        {
            target.InvertGravity();
            target.SetVelocity(Vector3.up * (_moveForce * Time.deltaTime));
        }
    }
}