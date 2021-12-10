using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using U.Gears;

namespace U.Gears.MouseListeners
{
    public class AddVelocityOnClick : MonoBehaviour
    {

        #region PROPS-INSPECTOR

        [Header("Movement")]
        public Vector2 onClickSpeed = new Vector2(1, 1);
        public EffectOnObject effectOnObject = EffectOnObject.ATTRACT;

        [Header("Click")]
        public float timeBetweenClicks = .5f;
        public float clickedEffectTime = .2f;


        [Header("Constraints")]
        // Considerar la distancia que tiene del click, o siempre aplicar la misma fuerza
        public bool considerXDistance = true;
        public bool considerYDistance = true;

        public bool denyXLeft = false;
        public bool denyXRight = false;
        public bool denyYUp = false;
        public bool denyYDown = false;

        #endregion



        #region REQS - RequiredComponents


        private Rigidbody2D rb;
        public PrimaryClickListener lm;


        #endregion



        #region PROPS-HIDDEN

        FastTimer timeterBetweenClicks;
        FastTimer timeterInvertTime;

        #endregion


        #region PROPS-PRIVATE

        Vector2 distanceVectorNormal;
        Vector2 distanceVectorNormalized;

        private bool isClicked;
        private Vector2 clickPoss;

        #endregion




        // Start is called before the first frame update
        void Start()
        {
            // REQS - Get required components
            rb = GetComponent<Rigidbody2D>();
            lm = GetComponent<PrimaryClickListener>();
            if (
                rb == null ||
                lm == null
                ) throw new System.Exception("InvertGravityOnHold on: " + gameObject.name + " need missing required components");


            //ADDS - Add componets
            timeterBetweenClicks = FastTimer.AddComponent(gameObject, new FastTimer.Properties
            {
                duration = timeBetweenClicks,
                loop = false,
            });
            timeterInvertTime = FastTimer.AddComponent(gameObject, new FastTimer.Properties
            {
                duration = clickedEffectTime,
                loop = false,
            });

        }


        private void LateUpdate()
        {
            // Detectar si hay clicks inicial
            if (lm.isClick)
            {
                isClicked = true;
                clickPoss = lm.lastClickPoss;
            }
        }



        private void FixedUpdate()
        {

            // If click
            if (isClicked && timeterBetweenClicks.IsCompleted)
            {
                //Debug.Log("CLICK");
                // Reinicia los timeters
                timeterBetweenClicks.Restart();
                timeterInvertTime.Restart();
                // Calcula el vector de la fuerza a aplicar
                Vector2 distanceVector = clickPoss.Distance(transform.position);
                //distanceVector = new Vector2(clickPoss.x - transform.position.x, clickPoss.y - transform.position.y);
                distanceVectorNormal = distanceVector.normalized;
                distanceVectorNormalized = Umath.UnitarizeVector2(distanceVector);
            }

            // Si debe moverse
            if (!timeterInvertTime.IsCompleted)
            {

                // El tipo de effecto que tendra en el objeto
                int effect = 0;
                if (effectOnObject == EffectOnObject.ATTRACT) effect = 1;
                if (effectOnObject == EffectOnObject.REPEL) effect = -1;

                // Vector de impulso
                Vector2 impulse = Vector2.zero;

                // Si considera la distancia en X
                if (considerXDistance)
                {
                    impulse.x = distanceVectorNormal.x * onClickSpeed.x * effect;
                }
                else
                {
                    impulse.x = distanceVectorNormalized.x * onClickSpeed.x * effect;
                }

                // Si considera la distancia en Y
                if (considerYDistance)
                {
                    impulse.y = distanceVectorNormal.y * onClickSpeed.y * effect;
                }
                else
                {
                    impulse.y = distanceVectorNormalized.y * onClickSpeed.y * effect;
                }


                // Denegar Y
                if (denyYUp && (impulse.y > 0)) impulse.y *= -1;
                if (denyYDown && (impulse.y < 0)) impulse.y *= -1;
                if (denyYUp && denyYDown) impulse.y = rb.velocity.y;

                // Denegar X
                if (denyXRight && (impulse.x > 0)) impulse.x *= -1;
                if (denyXLeft && (impulse.x < 0)) impulse.x *= -1;
                if (denyXLeft && denyXRight) impulse.x = rb.velocity.x;


                //Debug.Log(impulse);
                rb.velocity = impulse;
            }



            // Indica que se leyo el click
            isClicked = false;

        }


        #region ENUMS

        public enum EffectOnObject : ushort
        {
            ATTRACT,
            REPEL,
        }

        #endregion




        public class Properties
        {
            public Vector2 onClickSpeed = new Vector2(1, 1);
            public EffectOnObject effectOnObject = EffectOnObject.ATTRACT;
            public float timeBetweenClicks = .5f;
            public float clickedEffectTime = .2f;
            public bool considerXDistance = true;
            public bool considerYDistance = true;
            public bool denyXLeft = false;
            public bool denyXRight = false;
            public bool denyYUp = false;
            public bool denyYDown = false;
        }


        public static AddVelocityOnClick AddComponent(GameObject gameObject, Properties p)
        {
            var c = gameObject.AddComponent<AddVelocityOnClick>();

            c.onClickSpeed = p.onClickSpeed;
            c.effectOnObject = p.effectOnObject;
            c.timeBetweenClicks = p.timeBetweenClicks;
            c.clickedEffectTime = p.clickedEffectTime;
            c.considerXDistance = p.considerXDistance;
            c.considerYDistance = p.considerYDistance;
            c.denyXLeft = p.denyXLeft;
            c.denyXRight = p.denyXRight;
            c.denyYUp = p.denyYUp;
            c.denyYDown = p.denyYDown;

            return c;
        }


    }
}