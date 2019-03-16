using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EasyStrategy.Api.Data;
using EasyStrategy.Domain.Sales;

namespace EasyStrategy.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class SalesApiController : ControllerBase
    {
        readonly EasyContext _context;
        public SalesApiController(EasyContext context)
        {
            _context = context;
        }


        //http://multivac:5000/api/Sales?AggregationGrouperIds=5&AggregationGrouperIds=19&IntervalTypeId=2&IntervalBegin=2019-03-14T00:00:00&IntervalEnd=2019-03-14T16:59:00
        [HttpGet("Sales")]
        public ActionResult<IEnumerable<Sale>> List([FromQuery]Parameters.SaleListParameter parameters)
        {
            var query = _context.Sales
                .Include(_ => _.GrouperAggregation)
                .Include(_ => _.GrouperType)
                .Include(_ => _.IntervalType).AsQueryable();
            if (parameters.AggregationGrouperIds != null && parameters.AggregationGrouperIds.Any())
            {
                var grouperAggregation = _context.GrouperAggregationGroupers
                    .Where(_ => parameters.AggregationGrouperIds.Contains(_.Grouper.Id))
                    .GroupBy(_ => _.GrouperAggregation)
                    .Where(_ => _.Count() == parameters.AggregationGrouperIds.Length)
                    .Select(_ => _.Key).FirstOrDefault();
                query = query.Where(_ => _.GrouperAggregation == grouperAggregation);
            }
            else
            {
                query = query.Where(_ => _.GrouperAggregation == null);
            }

            query = query.Where(_ => _.IntervalType.Id == parameters.IntervalTypeId);

            if (parameters.GrouperId.HasValue)
                query = query.Where(_ => _.Grouper.Id == parameters.GrouperId.Value);

            if (parameters.GrouperTypeId.HasValue)
                query = query.Where(_ => _.GrouperType.Id == parameters.GrouperTypeId.Value);

            if (parameters.IntervalBegin.HasValue)
                query = query.Where(_ => _.IntervalBegin >= parameters.IntervalBegin.Value);

            if (parameters.IntervalEnd.HasValue)
                query = query.Where(_ => _.IntervalEnd <= parameters.IntervalEnd.Value);

            query = query.Include(_ => _.Grouper);

            var sales = query.ToList();

            return Ok(sales.Select(_ => Helpers.Converters.ToTransferObject(_)));
        }
    }
}