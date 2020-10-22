using System.Collections.Generic;

namespace DataLibrary.Config
{
    public class SystemMenuType
    {
        public const int Home = 1;

        public const int Article = 2;

        public const int Contact = 3;

        public const int Location = 4;

        public const int OutSite = 5;

        public const int About = 6;

        public const int Register = 7;

        public const int Product = 8;

        public const int Gallery = 9; 


        public static Dictionary<int, string> CategoryType = new Dictionary<int, string>()
        {
            {Home, "Trang Chủ"},

            {Article, "Trang Bài Viết"},

            {Contact, "Trang Liên Hệ"},

            {Location, "Trang Vị Trí"},

            {OutSite, "Trang Link"},

            {About, "Trang Giới Thiệu"},

            {Register, "Trang Nhận Báo Giá"},

            {Product, "Trang Sản Phẩm"},

            {Gallery, "Trang Gallery"},
             
        };
    }
}
