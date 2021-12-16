using UnityEngine;
using U.Gears.MouseListeners;
using U.Gears.Math;

public class FaceMouse2D : MonoBehaviour
{
    public enum FaceMode
    {
        OnHold,
        Always,
        OnClick,
    }

    [Header("Listener")]
    [SerializeField] private PrimaryClickListener clickListener;
    [SerializeField] private PrimaryClickInTriggerListener clickListenerInTrigger;
    [Header("Settings")]
    [SerializeField] private float rotationSpeed = 1;
    [SerializeField] private float facingAngle = 0f;
    [SerializeField] private FaceMode faceMode = FaceMode.OnHold;
    [SerializeField] private float desacelerationSpeed = 0.9f;


    private IClickListener l;
    private Vector2 distanceVector;
    private float currentSpeed;
    private Quaternion currentRotation;

    private void Start()
    {
        if (clickListener == null)
        {
            clickListener = GetComponent<PrimaryClickListener>();
            if (clickListener == null)
            {
                if (clickListenerInTrigger == null)
                {
                    clickListenerInTrigger = GetComponent<PrimaryClickInTriggerListener>();
                    if (clickListenerInTrigger == null)
                    {
                        throw new System.ArgumentNullException("FaceMouse2D: Cant find a valid click listener");
                    }
                    else l = clickListenerInTrigger;
                }
                else l = clickListenerInTrigger;
            }
            else l = clickListener;
        }
        else l = clickListener;
    }

    private void Update()
    {

        // Si debe girar
        if ((faceMode == FaceMode.Always) || (faceMode == FaceMode.OnHold && l.isHold) || (faceMode == FaceMode.OnClick && l.isClick))
        {
            // Vector de dsitancia entre el objeto y el touch
            distanceVector = l.currentMousePoss.Distance(transform.position);
            currentRotation = transform.rotation;

            // Velocidad normal
            currentSpeed = rotationSpeed * Time.deltaTime;
        }
        // Si no debe girar
        else
        {
            // Reducira la velocidad gradualmente
            currentSpeed = currentSpeed * desacelerationSpeed * Time.deltaTime;

        }

        // ROTACION
        // Calculos para las rotaciones
        float angle = Mathf.Atan2(distanceVector.y, distanceVector.x) * Mathf.Rad2Deg;
        Quaternion target = Quaternion.Euler(0, 0, angle + facingAngle);
        // Cambiar la rotacion de este objeto
        transform.rotation = Quaternion.Slerp(currentRotation, target, currentSpeed);
    }

}
