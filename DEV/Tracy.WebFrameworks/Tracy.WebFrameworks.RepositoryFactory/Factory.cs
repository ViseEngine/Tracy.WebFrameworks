using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracy.Frameworks.Common.Extends;
using Tracy.WebFrameworks.IRepository;

namespace Tracy.WebFrameworks.RepositoryFactory
{
    /// <summary>
    /// 仓储工厂
    /// 通过反射创建仓储实例
    /// </summary>
    public class Factory
    {
        private static object GetInstance(string name)
        {
            string configName = System.Configuration.ConfigurationManager.AppSettings["Tracy.WebFrameworks.RepositoryAccess"];
            if (configName.IsNullOrEmpty())
            {
                throw new Exception("还没有配置RepositoryAccess!");
            }
            string className = string.Format("{0}.{1}", configName, name);  //name:Tracy.WebFrameworks.Repository

            //加载程序集
            System.Reflection.Assembly assembly = System.Reflection.Assembly.Load(configName);
            //创建指定类型的对象实例
            return assembly.CreateInstance(className);
        }

        public static ICorporationRepository GetCorporationRepository()
        {
            return GetInstance("CorporationRepository") as ICorporationRepository;
        }

        public static IDepartmentRepository GetDepartmentRepository()
        {
            return GetInstance("DepartmentRepository") as IDepartmentRepository;
        }

        public static IUserRepository GetEmployeeRepository()
        {
            return GetInstance("EmployeeRepository") as IUserRepository;
        }

        public static IUserDepartmentRepository GetEmployeeDepartmentRepository()
        {
            return GetInstance("EmployeeDepartmentRepository") as IUserDepartmentRepository;
        }

        public static IRoleRepository GetRoleRepository()
        {
            return GetInstance("RoleRepository") as IRoleRepository;
        }

        public static IUserRoleRepository GetEmployeeRoleRepository()
        {
            return GetInstance("EmployeeRoleRepository") as IUserRoleRepository;
        }

        public static IMenuRepository GetMenuRepository()
        {
            return GetInstance("MenuRepository") as IMenuRepository;
        }

        public static IButtonRepository GetButtonRepository()
        {
            return GetInstance("ButtonRepository") as IButtonRepository;
        }

        public static IMenuButtonRepository GetMenuButtonRepository()
        {
            return GetInstance("MenuButtonRepository") as IMenuButtonRepository;
        }

        public static IRoleMenuButtonRepository GetRoleMenuButtonRepository()
        {
            return GetInstance("RoleMenuButtonRepository") as IRoleMenuButtonRepository;
        }

        public static ICommonRepository GetCommonRepository()
        {
            return GetInstance("CommonRepository") as ICommonRepository;
        }

    }
}
