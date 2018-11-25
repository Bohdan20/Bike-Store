namespace StagesCycling.BLL.DTO
{
    using DAL.Entities.Base;
    using System.Collections.Generic;

    public class EditItem<T> where T : BaseEntity
    {
        public string ItemType { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}
