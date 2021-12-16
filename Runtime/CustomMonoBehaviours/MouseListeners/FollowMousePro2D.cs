using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using U.Gears.MouseListeners;
using U.Gears;
using U.Gears.Math;
using U.Gears.Timers;

namespace U.Gears.MouseListeners
{
    public class FollowMousePro2D : MonoBehaviour
    {
        public enum FollowMode
        {
            OnHold,
            Always,
            OnClick,
        }

        //                       repeel radio          no action radio        desaceelration radio    maxspeed radio           outside Radio
        //                         v                    v                        v                     v                       v
        // Object )    repeel      /        noAction    /     desaceleration     /    max velocity     /     aceleration       /   noAction           

        [Header("Listener")]
        [SerializeField] private PrimaryClickListener clickListener;
        [SerializeField] private PrimaryClickInTriggerListener clickListenerInTrigger;
        [Header("Settings")]
        [SerializeField] private FollowMode faceMode = FollowMode.OnHold;
        [SerializeField] private float moveSpeed = 50f;
        [SerializeField] private float repeelSpeed = 10f;
        [SerializeField] private float desacelerationSpeed = .5f;
        [SerializeField] private int frecuency = 20;
        [Header("Radius")]
        [SerializeField] private float repeelRadio = 2; // Inside this area will repeel
        [SerializeField] private float noActionRadio = 2.5f; // Inside this area wont move
        [SerializeField] private float desacelerationRadio = 3.5f; // Inside this area will desacelerate
        [SerializeField] private float maxSpeedRadio = 7f; // Inside this area is max speed area
        [SerializeField] private float outsideRadio = 9f; // Outside this area will not move


        private IClickListener l;
        private Rigidbody2D rb;
        private Timer ft;
        private bool isClick;
        private float deltaTime;


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
                            throw new System.ArgumentNullException("FollowMouse2D: Cant find a valid click listener");
                        }
                        else l = clickListenerInTrigger;
                    }
                    else l = clickListenerInTrigger;
                }
                else l = clickListener;
            }
            else l = clickListener;

            if (rb == null)
            {
                rb = GetComponent<Rigidbody2D>();
                if (rb == null) throw new System.NullReferenceException("FollowMouse2D: Cant find a valid rigidBody2D");
            }

            ft = Timer.AddComponent(gameObject, new Timer.Properties
            {
                allowUnexpectedEnd = true,
                duration = 1 / ((float)frecuency),
                loop = false,
                playOnAwake = true,
                timeMode = Timer.TimeMode.DeltaTime,
            });

        }

        private void Update()
        {
            if (l.isClick) isClick = true;

            if (ft.IsWorking)
            {
                deltaTime += Time.deltaTime;
                return;
            }

            Aceleration2();
            ft.Restart();
            deltaTime = 0;
            isClick = false;

        }


        private void Aceleration2()
        {
            // Distance between mouse and object
            var distance = l.currentMousePoss.Distance(transform.position).magnitude;
            var normDistance = l.currentMousePoss.Distance(transform.position).normalized;



            // Si debe moverse
            if ((faceMode == FollowMode.Always) || (faceMode == FollowMode.OnHold && l.isHold) || (faceMode == FollowMode.OnClick && isClick))
            {

                // No Action
                if ((distance > outsideRadio) || (distance > repeelRadio && distance <= noActionRadio))
                {
                    Desacelerate();
                    return;
                }

                // repeel
                if (distance <= repeelRadio)
                {
                    var dd = (distance - repeelRadio) / distance;
                    rb.velocity = new Vector2(repeelSpeed * dd * deltaTime * normDistance.x, repeelSpeed * dd * deltaTime * normDistance.y);
                    return;
                }

                // max velocity
                if (distance > desacelerationRadio && distance <= maxSpeedRadio)
                {
                    rb.velocity = new Vector2(moveSpeed * deltaTime * normDistance.x, moveSpeed * deltaTime * normDistance.y);
                    return;
                }

                // desaceleration
                if (distance > noActionRadio && distance <= desacelerationRadio)
                {
                    var dd = (distance - noActionRadio) / (desacelerationRadio - noActionRadio);
                    rb.velocity = new Vector2(moveSpeed * dd * deltaTime * normDistance.x, moveSpeed * dd * deltaTime * normDistance.y);
                    return;
                }

                // aceleration
                if (distance > maxSpeedRadio && distance <= outsideRadio)
                {
                    var aa = outsideRadio - maxSpeedRadio;
                    var dd = (aa - (distance - maxSpeedRadio)) / aa;
                    rb.velocity = new Vector2(moveSpeed * dd * deltaTime * normDistance.x, moveSpeed * dd * deltaTime * normDistance.y);
                    return;
                }

            }
            // If moust dont move just desacelerate
            else
            {
                //Debug.Log("NoActivated");
                Desacelerate();
            }

            void Desacelerate()
            {
                rb.velocity = new Vector2(rb.velocity.x * desacelerationSpeed * deltaTime * normDistance.x, rb.velocity.y * desacelerationSpeed * deltaTime * normDistance.y);
            }


        }



        private void Aceleration()
        {
            Vector2 aceleration = new Vector2(0, 0);

            // Si debe moverse
            if ((faceMode == FollowMode.Always) || (faceMode == FollowMode.OnHold && l.isHold) || (faceMode == FollowMode.OnClick && isClick))
            {
                // Vector de ditancia entre el objeto y el touch
                var distanceVector = l.currentMousePoss.Distance(transform.position);

                // Magnitud de la distancia entre el objeto y el touch
                var distanceMag = distanceVector.magnitude;
                // Vector de normalizado de la distancia
                var distanceVectorNormal = distanceVector.normalized;

                // <Distancia calculada desde el objeto a el circulo de maximo acercamiento
                var outsideAceleration = distanceMag - repeelRadio;
                // Ajustar para hacer que la distancia minima sea 0 y no de cosas negativas si esta mas cerca de donde es 0
                if (outsideAceleration < 0) outsideAceleration = 0;
                // Calcular segun la distancia entre y el area de atenuacion
                // Si esta lejos no hace nada y deja el valor en uno, siesta muy cerca aplica la atenuacion y el valor sera menor que uno
                if (outsideAceleration > desacelerationRadio) outsideAceleration = 1f;
                // si esta cerca se calcula que tan cerca segun el radio de suavizado para entre mas cerca atenuar mas y entre mas lejos atenuar menos
                else outsideAceleration = outsideAceleration / desacelerationRadio;

                // Distancia desde el radio de far hasta donde este el objeto
                float distanceFomFar = distanceMag - maxSpeedRadio;
                // Distancia desde el radio far hasta donde funciona el controlador
                float distanceFromFarToEnd = outsideRadio - maxSpeedRadio;
                // Si es menor que cero es 0
                if (distanceFomFar < 0) distanceFomFar = 0;
                // Calcula el valor de la desaceleracion segun la distancioa entre donde empieza a deshacelerar y la distancia del objeto multiplicado por una atenuacion
                float farAtenuation = distanceFomFar / distanceFromFarToEnd;
                // Invertir el valor y ajustarlo
                farAtenuation = 1 - farAtenuation;
                if (farAtenuation < .07f) farAtenuation = 0;
                if (farAtenuation > .97f) farAtenuation = 1;
                // Aplica la deshaceleracion
                outsideAceleration = outsideAceleration * farAtenuation;
                // >Distancia calculada desde el circulo de maximo acercamiento


                // <Distancia desde el centro hasta donde no debe repelerse
                var insideAceleration = distanceMag;
                //Ajustamos los valores para  que la distancia maxima sea la distancia desde el centro hasta donde no va a ser repelido
                if (insideAceleration > (repeelRadio - noActionRadio)) insideAceleration = (repeelRadio - noActionRadio);
                // Normalizamos el valor para hacer que si la distancia es la maxima esto valga uno y si es menos de la maxima valga menos de uno
                insideAceleration = insideAceleration / (repeelRadio - noActionRadio);
                // Invertimos el valor para hacer que si la distancia es maxima el valor del movimiento que va a tener sera 0 y si no es maxima sera mas que cero
                insideAceleration = 1 - insideAceleration;
                // Hacemos un minimo para que no este baialndop el el borde y llegue a cero bien
                if (insideAceleration < .07f) insideAceleration = 0;
                // <Distancia desde el centro hasta donde no debe repelerse


                // MOVIMIENTO 
                // Mover el objeto mas cerca del punto objetivo si no esta mas cerca de la maxima distancia
                if (outsideAceleration > 0)
                {
                    aceleration = new Vector2(moveSpeed * distanceVectorNormal.x * outsideAceleration, moveSpeed * distanceVectorNormal.y * outsideAceleration);
                }
                if (insideAceleration > 0)
                {
                    aceleration = new Vector2(repeelSpeed * distanceVectorNormal.x * (-1f) * insideAceleration, repeelSpeed * distanceVectorNormal.y * (-1f) * insideAceleration);
                }


            }
            // Si no debe moverse
            else
            {
                // Disminuir gradualmente la aceleracion
                aceleration = new Vector2(rb.velocity.x * desacelerationSpeed, rb.velocity.y * desacelerationSpeed);

            }

            rb.velocity = aceleration;









        }


        void OnDrawGizmosSelected()
        {
            if (outsideRadio < maxSpeedRadio) Debug.LogError("FollowMouse2D: outsideRadio must be bigger than maxSpeedRadio");
            if (maxSpeedRadio < desacelerationRadio) Debug.LogError("FollowMouse2D: maxSpeedRadio must be bigger than desacelerationRadio");
            if (desacelerationRadio < noActionRadio) Debug.LogError("FollowMouse2D: desacelerationRadio must be bigger than noActionRadio");
            if (noActionRadio < repeelRadio) Debug.LogError("FollowMouse2D: noActionRadio must be bigger than repeelRadio");

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, repeelRadio);
            Gizmos.DrawWireSphere(transform.position, noActionRadio);
            Gizmos.DrawWireSphere(transform.position, desacelerationRadio);
            Gizmos.DrawWireSphere(transform.position, maxSpeedRadio);
            Gizmos.DrawWireSphere(transform.position, outsideRadio);
        }
    }
}