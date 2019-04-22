using System;
namespace Amoozeshgah.Domain.Entities
{
  public  interface IBaseEntity
    {
        int Id { get; set; }
        string CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        string CreatedDateJalali { get; set; }
        //byte[] TimeStamp { get; set; }

    }
}
