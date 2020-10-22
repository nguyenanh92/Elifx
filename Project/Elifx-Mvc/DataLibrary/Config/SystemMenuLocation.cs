using System.Collections.Generic;

namespace DataLibrary.Config
{
    public class SystemMenuLocation
    {
        public const int MainMenu = 1;
        public const int SecondMenu = 2;

        public int LocationId { get; set; }
        public string AliasMenu { get; set; }
        public string TitleMenu { get; set; }
        

        public static  List<SystemMenuLocation> ListLocationMenu()
        {
            var listLocationMenu = new List<SystemMenuLocation>
                                       {
                                           new SystemMenuLocation
                                               {
                                                   LocationId = MainMenu,
                                                   TitleMenu = "Menu Chính",
                                                   AliasMenu = "MainMenu"
                                               },
                                           new SystemMenuLocation
                                               {
                                                   LocationId = SecondMenu,
                                                   TitleMenu = "Menu Chân Trang",
                                                   AliasMenu = "SecondMenu"
                                               },
                                       };

            return listLocationMenu;
        }
    }

}
