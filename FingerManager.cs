using UnityEngine;
using System.Collections.Generic;

namespace TryFinger
{
    [ConfigureSingleton(SingletonFlags.NoAutoInstance)]
    class FingerManager : MonoSingleton<FingerManager>
    {
        GunControl gc;
        GameObject tf;


        private void Start()
        {
            gc = this.gameObject.GetComponent<GunControl>();
            this.GrantFinger();
        }

        private void Update()
        {
            if (MonoSingleton<ModInput>.Instance && MonoSingleton<ModInput>.Instance.TryFinger.WasPerformedThisFrame)
            {
                if (gc.currentWeapon.activeSelf)
                {
                    gc.NoWeapon();
                    tf.SetActive(true);
                } 
                else
                {
                    if (tf.activeSelf) {
                        gc.YesWeapon();
                        tf.SetActive(false);
                    }
                }
            }
        }

        public void GrantFinger()
        {
            tf = Object.Instantiate<GameObject>(Plugin.fingerbundle.LoadAsset<GameObject>("TheFinger"), this.gameObject.transform);
            tf.SetActive(false);
        }
    }
}