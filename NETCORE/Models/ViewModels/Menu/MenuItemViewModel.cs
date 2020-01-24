using CORE.BL.Dto.Menu;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Target_NETCORE.Models.ViewModels.Menu
{
    public class MenuItemViewModel
    {
        public MenuItemViewModel()
        {
            children = new List<MenuItemViewModel>();
        }
        public string title { get; set; }
        public string icon { get; set; }
        public string link { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<MenuItemViewModel> children { get; set; }

    }
}