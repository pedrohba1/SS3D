﻿using UnityEngine;
using System.Collections;

namespace Interactions.Custom
{
    /**
     * <summary>
     * Attach to the target, will allow object to open/close via an animation controller
     * </summary>
     * <remarks>
     * The animator should have an 'open' boolean variable, which will get set appropriately
     * on interaction.
     * 
     * The object starts closed by default
     * </remarks>
     * <inheritdoc cref="Core.Interaction"/>
     */
    [RequireComponent(typeof(Animator))]
    public class Openable : MonoBehaviour, Core.Interaction
    {
        public bool Open { get; private set; }
        public Core.InteractionEvent Event { get; set; }
        public string Name => "Open";

        public bool CanInteract() => Event.target == gameObject;

        public void Interact()
        {
            Open = !Open;
            // Start the animator on it's work
            animator.SetBool("open", Open);
        }

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        private Animator animator;
    }
}
