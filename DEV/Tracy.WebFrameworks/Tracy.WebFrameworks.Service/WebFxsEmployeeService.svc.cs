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
using Tracy.WebFrameworks.Entity.ViewModel;
using Tracy.WebFrameworks.IService;
using Tracy.WebFrameworks.IRepository;
using Tracy.WebFrameworks.RepositoryFactory;
using System.Linq.Expressions;
using Tracy.Frameworks.Common.Extends;

namespace Tracy.WebFrameworks.Service
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    //[WcfServiceCounter(SystemCode = "WebFrameworks", Source = "Offline.Service")]
    public class WebFxsEmployeeService : IWebFxsEmployeeService
    {
        private static readonly IEmployeeRepository repository = Factory.GetEmployeeRepository();

        #region IRepository
        /// <summary>
        /// 依据id查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Employee GetById(int id)
        {
            return repository.GetById(id);
        }

        /// <summary>
        /// 依条件表达式查询
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderby"></param>
        /// <returns></returns>
        public IEnumerable<Employee> GetByCondition(Expression<Func<Employee, bool>> filter = null, Func<IQueryable<Employee>, IOrderedQueryable<Employee>> orderby = null)
        {
            return repository.GetByCondition(filter: filter, orderby: orderby);
        }

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Employee Insert(Employee item)
        {
            return repository.Insert(item);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Update(Employee item)
        {
            return repository.Update(item);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            return repository.Delete(id);
        }

        #endregion

        /// <summary>
        /// 检查登录
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        public WebFxsResult<Employee> CheckLogin(CheckLoginRequest request)
        {
            var result = new WebFxsResult<Employee> 
            {
                ReturnCode= ReturnCodeType.Error,
                Content= new Employee()
            };

            var employee = GetByCondition(p=> p.UserId.Equals(request.loginName) && p.UserPwd.Equals(request.loginPwd)).FirstOrDefault();
            if (employee== null)
            {
                result.Message = "用户名或密码错误!";
                return result;
            }
            if (employee.Enabled.Value == false)
            {
                result.Message = "该用户已被禁用!";
                return result;
            }

            result.ReturnCode = ReturnCodeType.Success;
            result.Content = employee;

            return result;
        }
    }
}
