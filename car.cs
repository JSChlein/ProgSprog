using System;
namespace Opg4Delegate
{
    public class FastCar
    {
        public delegate void CarValueChangedHandler(object sender, int oldValue, int newValue);
        public event CarValueChangedHandler SpeedChanged;
        public event CarValueChangedHandler FuelChanged;


        private int _speed;

        public int Speed
        {
            get { return _speed; }
            set
            {
                if(SpeedChanged != null)
                {
                    SpeedChanged(this, _speed, value);
                }
                _speed = value;


            }

        }

        private int _fuelLitersInTank;

        public int FuelLitersInTank
        {
            get { return _fuelLitersInTank; }
            set
            {
                if (FuelChanged != null)
                {
                    FuelChanged(this, _fuelLitersInTank, value);
                }
                _fuelLitersInTank = value;

            }
        }

        public FastCar(int speed, int fuelLitersInTank)
        {
            this._speed = speed;
            this._fuelLitersInTank = fuelLitersInTank;
        }


    }
}
