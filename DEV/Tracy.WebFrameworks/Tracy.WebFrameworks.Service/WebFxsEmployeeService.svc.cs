using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;
using Tracy.WebFrameworks.Common.Helper;
using Tracy.WebFrameworks.Data;
using Tracy.WebFrameworks.Entity;
using Tracy.WebFrameworks.Entity.CommonBO;
using Tracy.WebFrameworks.IService;

namespace Tracy.WebFrameworks.Service
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    //[WcfServiceCounter(SystemCode = "WebFrameworks", Source = "Offline.Service")]
    public class WebFxsEmployeeService: IWebFxsEmployeeService
    {
        #region IRepository
        /// <summary>
        /// 依据id查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public WebFxsResult<Employee> GetById(int id)
        {
            var result = new WebFxsResult<Employee>()
            {
                ReturnCode = ReturnCodeType.Error,
                Content = new Employee()
            };
            Employee employee = null;
            DBHelper.NoLockInvokeDB(() =>
            {
                using (var db = new WebFrameworksDB())
                {
                    employee = db.Employee.FirstOrDefault(p => p.EmployeeID == id);
                    //Employee = db.Employee.Find(id);//或者

                    if (employee != null)
                    {
                        result.ReturnCode = ReturnCodeType.Success;
                        result.Content = employee;
                    }
                }
            });

            return result;
        }

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public WebFxsResult<Employee> Insert(Employee item)
        {
            var result = new WebFxsResult<Employee>()
            {
                ReturnCode = ReturnCodeType.Error,
                Content = new Employee()
            };

            //CRUD Operation in Connected mode
            using (var db = new WebFrameworksDB())
            {
                var employee = db.Employee.Add(item);
                if (db.SaveChanges() > 0)
                {
                    result.ReturnCode = ReturnCodeType.Success;
                    result.Content = employee;
                }
            }

            return result;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public WebFxsResult<bool> Update(Employee item)
        {
            var result = new WebFxsResult<bool>()
            {
                ReturnCode = ReturnCodeType.Error,
                Content = false
            };

            //CRUD Operation in Connected mode
            using (var db = new WebFrameworksDB())
            {
                var employee = db.Employee.FirstOrDefault(p => p.EmployeeID == item.EmployeeID);
                if (employee != null)
                {
                    employee.CorporationID = item.CorporationID;
                    employee.DepartmentID = item.DepartmentID;
                    employee.RoleIDs = item.RoleIDs;
                    employee.EmployeeName = item.EmployeeName;
                    employee.LoginName = item.LoginName;
                    employee.Password = item.Password;
                    employee.PwdExpiredTime = item.PwdExpiredTime;
                    employee.Sex = item.Sex;
                    employee.Phone = item.Phone;
                    employee.Email = item.Email;
                    employee.Status = item.Status;
                    employee.LoginCount = item.LoginCount;
                    employee.LastLoginTime = item.LastLoginTime;
                    employee.LastLoginIP = item.LastLoginIP;
                    employee.Enabled = item.Enabled;
                    employee.CreatedBy = item.CreatedBy;
                    employee.CreatedTime = item.CreatedTime;
                    employee.LastUpdatedBy = item.LastUpdatedBy;
                    employee.LastUpdatedTime = item.LastUpdatedTime;
                }
                if (db.SaveChanges() > 0)
                {
                    result.ReturnCode = ReturnCodeType.Success;
                    result.Content = true;
                }
            }

            return result;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public WebFxsResult<bool> Delete(int id)
        {
            var result = new WebFxsResult<bool>()
            {
                ReturnCode = ReturnCodeType.Error,
                Content = false
            };

            //CRUD Operation in Connected mode
            using (var db = new WebFrameworksDB())
            {
                var employee = db.Employee.FirstOrDefault(p => p.EmployeeID == id);
                if (employee!= null)
                {
                    db.Employee.Remove(employee);
                }
                if (db.SaveChanges()> 0)
                {
                    result.ReturnCode = ReturnCodeType.Success;
                    result.Content = true;
                }
            }

            return result;
        }
        #endregion
    }
}
