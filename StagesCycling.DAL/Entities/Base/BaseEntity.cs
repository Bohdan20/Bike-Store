namespace StagesCycling.DAL.Entities.Base
{
    using System.ComponentModel.DataAnnotations;

    public class BaseEntity
    {
        [Key]
        public virtual long Id { get; set; }
    }
}
