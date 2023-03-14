using MVC_CodeFirst.Models.ContextClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_CodeFirst.DesignPatterns.SingletonPattern
{
    public class DbTool
    {
        static MyContext _dbInstance;

        public static MyContext _DBInstance
        {
            get 
            {
                if (_dbInstance == null)
                {
                    _dbInstance = new MyContext();
                }
                return _dbInstance;
            }
        }
    }
}