//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using EasyStrategy.Api.Data;
//using Microsoft.AspNet.OData;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace EasyStrategy.Api.Controllers
//{
//    [Route("api")]
//    [ApiController]
//    public class ApiController : ControllerBase
//    {
//        readonly EasyContext _easyContext;

//        public ApiController(
//            EasyContext easyContext)
//        {
//            _easyContext = easyContext;
//        }

//        [EnableQuery]
//        [Route("{entity}")]
//        public IActionResult Get([FromRoute]string entity)
//        {
//            var entityProperty = _easyContext.GetType().GetProperties().FirstOrDefault(_ => _.Name.ToUpper() == entity.ToUpper());
//            if (entityProperty != null)
//            {
//                return Ok(entityProperty.GetValue(_easyContext));
//            }

//            return NotFound();
//        }

//    }
//}