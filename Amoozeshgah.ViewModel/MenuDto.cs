using System.Collections.Generic;

namespace Amoozeshgah.ViewModel
{
    public class MenuDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<MenuItemDto> MenuItems { get; set; }
    }
}
