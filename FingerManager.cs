using UnityEngine;
using System.Collections.Generic;

namespace TryFinger
{
    [ConfigureSingleton(SingletonFlags.NoAutoInstance)]
    class FingerManager : MonoSingleton<FingerManager>
    {
        GunControl gc;
        public List<GameObject> fingerBox = new List<GameObject>();
        int idx;


        private void Start()
        {
            gc = this.gameObject.GetComponent<GunControl>();
            GameObject tf = Object.Instantiate<GameObject>(Plugin.fingerbundle.LoadAsset<GameObject>("TheFinger"), this.gameObject.transform);
            tf.AddComponent<WeaponPos>();
            tf.AddComponent<WeaponIdentifier>();
            tf.SetActive(false);

            gc.allWeapons.Add(tf);
            fingerBox.Add(tf);
            gc.slots.Add(fingerBox);
            gc.UpdateWeaponList();
            idx = gc.slots.IndexOf(fingerBox) + 1;
        }

        private void Update()
        {
            if (MonoSingleton<ModInput>.Instance && MonoSingleton<ModInput>.Instance.TryFinger.WasPerformedThisFrame)
            {
                if (gc.currentSlot != idx)
                {
                    gc.SwitchWeapon(idx, fingerBox, false, false);
                }
            }
        }
    }
}