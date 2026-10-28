using System;

namespace ProgrammingBasicsLab.Exercise06
{
    /// <summary>
    /// Exercise 6: a Car class with a user-defined constructor, a read-only
    /// property, a property that only accepts a value with something in it, and a
    /// method that returns the data about a car as a string.
    /// </summary>
    public class Car
    {
        // Data members. They are private, so the properties below are the only way
        // in from outside the class.
        private string _make;
        private string _model;
        private string _colour;
        private readonly string _registrationNumber;

        // A user-defined constructor that sets every data member of the new object.
        public Car(string make, string model, string colour, string registrationNumber)
        {
            _make = make;
            _model = model;
            _colour = colour;
            _registrationNumber = registrationNumber;
        }

        // Read-only property: there is a get accessor and no set accessor, so the
        // registration number can be read from an object but never written to.
        public string RegistrationNumber
        {
            get { return _registrationNumber; }
        }

        public string Model
        {
            get { return _model; }
        }

        public string Colour
        {
            get { return _colour; }
        }

        // The make can be set, but only to a value that has something in it. An
        // empty string, spaces, or null is ignored and the old make is kept.
        public string Make
        {
            get { return _make; }

            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _make = value;
                }
            }
        }

        // The behaviour the lab asks for: the data about a car as one string.
        public string Describe()
        {
            return _make + " " + _model + ", " + _colour
                   + ", registration " + _registrationNumber;
        }
    }
}
