using System;
using System.Collections.Generic;
using System.Linq;

namespace DataService
{
    public class DataService : IDataService
    {
        private const char SplitChar = ';';
        private const int countColumn = 10;

        private string _columnName = $"Район{SplitChar}Адрес{SplitChar}Локальный идентификатор{SplitChar}Подъездов в доме{SplitChar}" +
            $"Этажей в доме{SplitChar}Количество квартир{SplitChar}Тип здания{SplitChar}Тип сектора{SplitChar}Вид застройки{SplitChar}Глобальный идентификатор адреса";

        public void GetDataFromStings(Action<IEnumerable<ObjectEstate>, Exception> callback, IEnumerable<string> data)
        {
            List<ObjectEstate> listObjectEstates = new List<ObjectEstate>();
            Exception error = null;

            if (data.Count(x => x == _columnName) > 0)
            {
                data = data.Skip(1);
            }

            foreach (var item in data)
            {
                ObjectEstate oe = new ObjectEstate();
                string[] s = item.Split(SplitChar).Select(x => x.Trim()).ToArray();

                if (s.Length != countColumn)
                {
                    throw new Exception();
                }

                oe.District = s[0];
                oe.Address = s[1];
                oe.LocalID = s[2];

                if (int.TryParse(s[3], out int porch))
                {
                    oe.Porch = porch;
                }
                if (int.TryParse(s[4], out int floor))
                {
                    oe.Floor = floor;
                }
                if(int.TryParse(s[5], out int apartment))
                {
                    oe.Apartment = apartment;
                }
                oe.TypeBuilding = СheckType.GetTypeBuilding(s[6]);
                oe.TypeSector = СheckType.GetTypeSector(s[7]);
                oe.TypeDevelopment = СheckType.GetTypeDevelopment(s[8]);
                if(int.TryParse(s[9], out int id))
                {
                    oe.GlobalID = id;
                }

                listObjectEstates.Add(oe);

            }
        }
    }
}