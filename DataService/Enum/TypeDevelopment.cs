namespace DataService
{
    /// <summary>
    /// Вид застройки 	
    /// Тип здания по архитектурному решению 	
    /// Необязательное поле
    /// Многоквартирный жилой фонд
    /// Объект индивидуального жилищного строительства
    /// Отдельно стоящее здание
    /// Частный сектор
    /// </summary>
    public enum TypeDevelopment
    {
        ResidentialHousingStock,
        IndividualHousing,
        DetachedBuilding,
        IndividualSector
    }
}