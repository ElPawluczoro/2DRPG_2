using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

namespace RPG.Controll
{
    public class Roll : MonoBehaviour, IAction
    {
        float yRoll;
        float xRoll;
        public bool rolling = false;
        public float timeSienceLastRoll = Mathf.Infinity;

        public float rollCooldown = 3;
        [SerializeField] private float rollDistance = 5;
        [SerializeField] private float rollSpeed = 2;

        private void Update()
        {
            timeSienceLastRoll += Time.deltaTime;
            if (rolling)
            {
                transform.position += new Vector3(xRoll * Time.deltaTime * rollSpeed, yRoll * Time.deltaTime * rollSpeed, 0);
            }
        }
        public void Cancel()
        {
            GetComponent<Animator>().SetBool("Roll", false);
            rolling = false;
        }

        public void StartAction()
        {
            timeSienceLastRoll = 0;
            rolling = true;
            GetComponent<Animator>().SetBool("Roll", true);

            float fixedRollDDistance = rollDistance;
            if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)) && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
            {
                fixedRollDDistance = rollDistance / 1.5f;
            }

            if (Input.GetKey(KeyCode.W))
            {
                yRoll = fixedRollDDistance;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                yRoll = -fixedRollDDistance;
            }
            else yRoll = 0;

            if (Input.GetKey(KeyCode.D))
            {
                xRoll = fixedRollDDistance;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                xRoll = -fixedRollDDistance;
            }
            else xRoll = 0;

            StartCoroutine(waitTillRollEnds());
        }

        public IEnumerator waitTillRollEnds()
        {
            yield return new WaitForSeconds(0.5f);
            Cancel();
        }


    }
}