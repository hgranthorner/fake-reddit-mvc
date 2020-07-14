using System.Collections;
using System.Collections.Generic;

namespace MVC.Models
{
    public class DataViewModel
    {
        public List<MyData> Datas { get; set; }
        public MyData NewMyData { get; set; }
    }
}