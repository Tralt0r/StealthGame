using System;
using UnityEngine;

namespace StealthGame
{
    public class Key : MonoBehaviour
    {
        public string KeyName = "key1";

        private void OnTriggerEnter(Collider other)
        {
            PlayerMovement1 player = other.gameObject.GetComponent<PlayerMovement1>();

            //this wasn't a player
            if (player == null)
                return;
        
            player.AddKey(KeyName);
            Destroy(gameObject);
        }
    }
}