using System;
using System.Collections.Generic;
using UnityEngine;

namespace KuanMi
{
    public class Outline : MonoBehaviour
    {
        [SerializeField] private bool show;

        private Renderer _renderer;
        private Renderer[] _rendererList;

        public OutlineFeature.RenderLayer renderLayer;

        public bool containSub;

        public void Show()
        {
            show = true;
            SetLayer();
        }

        public void Hide()
        {
            show = false;
            SetLayer();
        }

        private void OnValidate()
        {
            SetLayer();
        }

        private void SetLayer()
        {
            if (!containSub)
            {
                if (_renderer == null)
                    _renderer = GetComponent<Renderer>();
                SetLayer(_renderer);
            }
            else
            {
                if (_rendererList == null)
                    _rendererList = GetComponentsInChildren<Renderer>();
                foreach (var renderer1 in _rendererList)
                {
                    SetLayer(renderer1);
                }
            }
        }

        private void SetLayer(Renderer renderer)
        {
            if (show)
                renderer.renderingLayerMask |= (uint)renderLayer;
            else
                renderer.renderingLayerMask &= ~(uint)renderLayer;
        }
    }
}