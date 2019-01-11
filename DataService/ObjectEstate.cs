namespace DataService
{
    public class ObjectEstate
    {
        /// <summary>
        /// Район
        /// </summary>
        public string District { get; set; }
        /// <summary>
        /// Адрес
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Локальный идентификатор
        /// </summary>
        public string LocalID { get; set; }
        /// <summary>
        /// Подъездов в доме
        /// </summary>
        public int? Porch { get; set; }
        /// <summary>
        /// Этажей в доме
        /// </summary>
        public int? Floor { get; set; }
        /// <summary>
        /// Количество квартир
        /// </summary>
        public int? Apartment { get; set; }
        /// <summary>
        /// Тип здания
        /// Обязательное свойство
        /// </summary>
        public TypeBuilding? TypeBuilding { get;set;}
        /// <summary>
        /// Тип сектора
        /// Обязательное свойство
        /// </summary>
        public TypeSector? TypeSector { get; set; }
        /// <summary>
        /// Вид застройки
        /// </summary>
        public TypeDevelopment? TypeDevelopment { get; set; }
        /// <summary>
        /// Глобальный идентификатор адреса
        /// Обязательное свойство
        /// </summary>
        public int? GlobalID { get; set; }
   }
}