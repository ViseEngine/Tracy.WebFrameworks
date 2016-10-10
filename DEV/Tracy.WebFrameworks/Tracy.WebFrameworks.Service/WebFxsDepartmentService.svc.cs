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
using Tracy.WebFrameworks.Entity.Enum;

namespace Tracy.WebFrameworks.Service
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    //[WcfServiceCounter(SystemCode = "WebFrameworks", Source = "Offline.Service")]
    public class WebFxsDepartmentService : IWebFxsDepartmentService
    {
        private static readonly IDepartmentRepository repository = Factory.GetDepartmentRepository();
        private static readonly ICorporationRepository corpRepository = Factory.GetCorporationRepository();

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
                ReturnCode = ReturnCodeType.Error,
                Content = new List<Department>()
            };

            var departments = repository.GetDepartmentByCorp(request);
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
                ReturnCode = ReturnCodeType.Error,
                Content = new PagingResult<User>()
            };

            var pagingUsers = repository.GetUserByDepartment(request);
            result.ReturnCode = ReturnCodeType.Success;
            result.Content = pagingUsers;

            return result;
        }

        /// <summary>
        /// 添加部门
        /// </summary>
        /// <param name="request"></param>
        /// <param name="loginUser"></param>
        /// <returns>true：成功,false:失败</returns>
        public WebFxsResult<bool> AddDepartment(AddDepartmentRQ request, User loginUser)
        {
            var result = new WebFxsResult<bool>
            {
                ReturnCode = ReturnCodeType.Error,
                Content = false
            };

            var department = new Department
            {
                Name = request.Name,
                Code = request.Code,
                ParentId = request.ParentId,
                CorporationId = request.CorpId,
                Sort = request.Sort,
                Enabled = true,
                CreatedBy = loginUser.UserId,
                CreatedTime = DateTime.Now
            };
            var rs = this.Insert(department);
            if (rs != null)
            {
                result.ReturnCode = ReturnCodeType.Success;
                result.Content = true;
            }

            return result;
        }

        /// <summary>
        /// 修改部门
        /// </summary>
        /// <param name="request"></param>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public WebFxsResult<bool> EditDepartment(EditDepartmentRQ request, User loginUser)
        {
            var result = new WebFxsResult<bool>
            {
                ReturnCode = ReturnCodeType.Error,
                Content = false
            };

            var department = new Department
            {
                Id = request.Id,
                Name = request.Name,
                Sort = request.Sort,
                LastUpdatedBy = loginUser.UserId,
                LastUpdatedTime = DateTime.Now
            };

            var rs = this.Update(department);
            if (rs == true)
            {
                result.ReturnCode = ReturnCodeType.Success;
                result.Content = true;
            }

            return result;
        }

        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public WebFxsResult<bool> DeleteDepartment(DeleteDepartmentRQ request)
        {
            var result = new WebFxsResult<bool>
            {
                ReturnCode = ReturnCodeType.Error,
                Content = false
            };

            var rs = repository.DeleteDepartment(request);
            if (rs == true)
            {
                result.ReturnCode = ReturnCodeType.Success;
                result.Content = true;
            }

            return result;
        }


    }
}
