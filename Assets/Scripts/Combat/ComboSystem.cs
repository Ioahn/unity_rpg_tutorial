using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RPG.Combat
{
    public class ComboSystem : MonoBehaviour
    {
        [SerializeField] private Texture firstSkillLook;
        [SerializeField] private Texture secondSkillLook;
        private List<bool> _order = new List<bool>();
        
        public int AddToQueue(GrimoireOrder order)
        {
            _order.Add(order == GrimoireOrder.First);

            return _order.Count;
        }

        public void ClearQueue()
        {
            _order.Clear();   
        }

        private void Update()
        {
            if (_order.Count == 3)
            {
                var i = GetIntFromBitArray(new BitArray(_order.ToArray()));

                ClearQueue();
            }
        }
        
        private int GetIntFromBitArray(BitArray bitArray)
        {

            int[] array = new int[1];
            bitArray.CopyTo(array, 0);
            return array[0];

        }
    }
}