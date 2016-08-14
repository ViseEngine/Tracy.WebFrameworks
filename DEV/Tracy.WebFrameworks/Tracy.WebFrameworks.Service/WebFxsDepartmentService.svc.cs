using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;
using Tracy.WebFrameworks.Entity;
using Tracy.WebFrameworks.Entity.CommonBO;
using Tracy.WebFrameworks.Entity.ViewModel;
using Tracy.WebFrameworks.IRepository;
using Tracy.WebFrameworks.IService;
using Tracy.WebFrameworks.RepositoryFactory;
using Tracy.Frameworks.Common.Extends;
using Tracy.Frameworks.Common.Result;

namespace Tracy.WebFrameworks.Service
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    //[WcfServiceCounter(SystemCode = "WebFrameworks", Source = "Offline.Service")]
    public class WebFxsDepartmentService: IWebFxsDepartmentService
    {
        private static readonly IDepartmentRepository repository = Factory.GetDepartmentRepository();

        #region IRepository
        /// <summary>
        /// 依据id查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Department GetById(int id)
        {
            return repository.GetById(id);
        }

        /// <summary>
        /// 依条件表达式查询
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderby"></param>
        /// <returns></returns>
        public IEnumerable<Department> GetByCondition(Expression<Func<Department, bool>> filter = null, Func<IQueryable<Department>, IOrderedQueryable<Department>> orderby = null)
        {
            return repository.GetByCondition(filter: filter, orderby: orderby);
        }

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Department Insert(Department item)
        {
            return repository.Insert(item);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Update(Department item)
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
        /// 获取指定公司下的部门
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public WebFxsResult<List<Department>> GetDepartmentByCorp(GetDepartmentByCorpRQ request)
        {
            var result = new WebFxsResult<List<Department>> 
            {
                ReturnCode= ReturnCodeType.Error,
                Content= new List<Department>()
            };

            var departments = this.GetByCondition(p => p.CorporationId == request.CorporationId).ToList();
            result.ReturnCode = ReturnCodeType.Success;
            result.Content = departments;

            return result;
        }

        /// <summary>
        /// 获取指定部门下的用户
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public WebFxsResult<PagingResult<User>> GetUserByDepartment(GetUserByDepartmentRQ request)
        {
            var result = new WebFxsResult<PagingResult<User>> 
            {
                ReturnCode= ReturnCodeType.Error,
                Content= new PagingResult<User>()
            };

            var pagingUsers = repository.GetUserByDepartment(request);
            result.ReturnCode = ReturnCodeType.Success;
            result.Content = pagingUsers;

            return result;
        }
    }
}
