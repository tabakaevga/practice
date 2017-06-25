﻿#region - Using -

using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text.RegularExpressions;

#endregion

namespace Circuit_impedance_calculating_model.Circuits
{
    /// <summary>
    /// Класс, описывающий параллельные цепи.
    /// </summary>
    class ParallelCircuit: ICircuit
    {
        #region - Private fields -

        /// <summary>
        /// Поле, содержащее наименование цепи.
        /// </summary>
        private string _name;

        /// <summary>
        /// Поле, содержащее список компонентов цепи.
        /// </summary>
        private List<IComponent> _circuit;

        #endregion

        #region - Events -

        /// <summary>
        /// Событие, срабатывающее на изменения в цепи.
        /// </summary>
        public event EventHandler CircuitChanged;

        #endregion

        #region - Constructors -

        /// <summary>
        /// Пустой конструктор.
        /// </summary>
        public ParallelCircuit() { }

        /// <summary>
        /// Конструктор с параметрами.
        /// </summary>
        /// <param name="name">Наименование цепи</param>
        public ParallelCircuit(string name)
        {
            Name = name;
        }

        #endregion

        #region - Public Properties -

        /// <summary>
        /// Свойство-аксессор для поля _name.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                string pattern1 = @"^circuit\d$";
                string pattern2 = @"^circuit\d{2}$";
                value = value.ToLower();
                if (value.Length > 9)
                {
                    throw new ArgumentException("Наименование цепи не должно" +
                        " превышать девяти символов. Наименование цепи должно начинаться" +
                        " со слова 'circuit' после которого должен идти порядковый номер цепи в схеме.");
                }
                if (!(Regex.IsMatch(value, pattern1) || Regex.IsMatch(value, pattern2)))
                {
                    throw new ArgumentException(" Наименование цепи должно начинаться" +
                        " со слова 'circuit' после которого должен идти порядковый номер цепи в схеме.");
                }
                _name = value;
            }
        }

        /// <summary>
        /// Свойство-аксессор для поля _circuit.
        /// </summary>
        public List<IComponent> Circuit { get; set; }

        #endregion

        #region - Public methods -

        /// <summary>
        /// Метод рассчета импеданса цепи.
        /// </summary>
        /// <param name="frequency">Входная частота</param>
        /// <returns>Импеданс цепи</returns>
        public Complex CalculateZ(double frequency)
        {
            Complex impedance = new Complex();
            foreach (IComponent component in _circuit)
            {
                impedance += 1 / component.CalculateZ(frequency);
            }
            return 1 / impedance;
        }

        #endregion
    }
}
