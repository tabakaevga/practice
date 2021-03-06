﻿#region - Using -

using System;

#endregion

namespace Circuit_impedance_calculating_model.Elements
{
    /// <summary>
    /// Интерфейс, описывающий простейшие элементы цепи.
    /// </summary>
    public interface IElement: IComponent
    {
        #region - Fields - 

        /// <summary>
        /// Значение элемента.
        /// </summary>
        double Value { get; set; }

        #endregion

        #region - Events -

        /// <summary>
        /// Событие, срабатывающее на изменеие значения элемента.
        /// </summary>
        event EventHandler ValueChanged;

        #endregion

        #region - Public methods -

        /// <summary>
        /// Вызывает событие ValueChanged, если оно не пустое.
        /// </summary>
        void OnValueChanged();

        #endregion
    }
}
