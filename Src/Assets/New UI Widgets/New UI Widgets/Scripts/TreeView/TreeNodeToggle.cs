namespace UIWidgets
{
	using UnityEngine.Events;
	using UnityEngine.EventSystems;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// Tree node toggle.
    /// </summary>
    public class TreeNodeToggle : UIBehaviour, IPointerUpHandler, IPointerDownHandler, IPointerClickHandler
	{
		/// <summary>
		/// OnClick event.
		/// </summary>
		public UnityEvent OnClick = new UnityEvent();

		/// <summary>
		/// Raises the pointer up event.
		/// </summary>
		/// <param name="eventData">Event data.</param>
		public void OnPointerUp(PointerEventData eventData)
		{
		}

		/// <summary>
		/// Raises the pointer down event.
		/// </summary>
		/// <param name="eventData">Event data.</param>
		public void OnPointerDown(PointerEventData eventData)
		{
		}

		/// <summary>
		/// Raises the pointer click event.
		/// </summary>
		/// <param name="eventData">Event data.</param>
		public void OnPointerClick(PointerEventData eventData)
		{
            
            
			if (eventData.button != PointerEventData.InputButton.Left)
			{
				return;
			}

			OnClick.Invoke();
		}
	}
}