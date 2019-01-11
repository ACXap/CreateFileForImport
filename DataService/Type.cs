using System.Collections.Generic;

namespace DataService
{
    public static class СheckType
    {
        private static Dictionary<string, TypeBuilding> _dicTypeBuilding = new Dictionary<string, TypeBuilding>()
        {
            { "Жилое", TypeBuilding.Residential },
            { "Нежилое", TypeBuilding.NonResidential },
            { "Административное", TypeBuilding.Administrative }
        };

        private static Dictionary<string, TypeSector> _dicTypeSector = new Dictionary<string, TypeSector>()
        {
            { "Частный", TypeSector.Individual },
            { "Не частный", TypeSector.NonIndividual }
        };

        private static Dictionary<string, TypeDevelopment> _dicTypeDevelopment = new Dictionary<string, TypeDevelopment>()
        {
            { "Многоквартирный жилой фонд", TypeDevelopment.ResidentialHousingStock },
            { "Объект индивидуального жилищного строительства", TypeDevelopment.IndividualHousing },
            { "Отдельно стоящее здание", TypeDevelopment.DetachedBuilding},
            { "Частный сектор", TypeDevelopment.IndividualSector}

        };

        public static TypeBuilding? GetTypeBuilding(string str)
        {
            // return _dicTypeBuilding.Where(x => x.Key == str)?.Select(x => x.Value).FirstOrDefault();

            if (_dicTypeBuilding.TryGetValue(str, out TypeBuilding tb))
            {
                return tb;
            }
            return null;
        }

        public static TypeSector? GetTypeSector(string str)
        {
            //return _dicTypeSector.Where(x => x.Key == str)?.Select(x => x.Value).FirstOrDefault();

            if (_dicTypeSector.TryGetValue(str, out TypeSector ts))
            {
                return ts;
            }
            return null;
        }

        public static TypeDevelopment? GetTypeDevelopment(string str)
        {
            // return _dicTypeDevelopment.Where(x => x.Key == str)?.Select(x => x.Value).FirstOrDefault();

            if (_dicTypeDevelopment.TryGetValue(str, out TypeDevelopment td))
            {
                return td;
            }
            return null;
        }
    }
}