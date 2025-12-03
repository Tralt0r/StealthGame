using System;
using UnityEngine;

namespace StealthGame
{
    public class Door : MonoBehaviour
    {
        public string KeyName = "key1";
    
        private void OnCollisionEnter(Collision other)
        {
            PlayerMovement1 player = other.gameObject.GetComponent<PlayerMovement1>();

            if (player == null)
                return;

            if (player.OwnKey(KeyName))
            {
                Destroy(gameObject);
            }
        }
    }
}