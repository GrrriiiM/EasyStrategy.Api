using EasyStrategy.Api.Contracts.Groupers;
using EasyStrategy.Api.Data;
using EasyStrategy.Api.TransferObjects;
using EasyStrategy.Domain.Groupers;
using EFCore.BulkExtensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EasyStrategy.Api.Controllers
{
    [Route("api/Seed")]
    [ApiController]
    public class SeedApiController : ControllerBase
    {
        readonly EasyContext _easyContext;
        public SeedApiController(EasyContext easyContext)
        {
            _easyContext = easyContext;
        }


        [HttpGet("GrouperAggregations")]
        public async Task<ActionResult> GrouperAggregations()
        {
            var grouper = _easyContext.Groupers
                .Include(_ => _.Type)
                .Where(_ => !_.IsTotal);

            foreach (var grouperLevel1 in grouper.Where(_ => _.Type.Level == 1))
            {

                var grouperAggregation = new GrouperAggregation()
                {
                    Description = $"{grouperLevel1.Type.Name}: {grouperLevel1.Name};"
                };

                grouperAggregation.GrouperAggregationGroupers.Add(new GrouperAggregationGrouper()
                {
                    GrouperAggregation = grouperAggregation,
                    Grouper = grouperLevel1
                });

                _easyContext.GrouperAggregations.Add(grouperAggregation);

                foreach (var grouperLevel2 in grouper.Where(_ => _.Type.Level == 2))
                {
                    grouperAggregation = new GrouperAggregation()
                    {
                        Description = $"{grouperLevel2.Type.Name}: {grouperLevel2.Name};"
                    };

                    grouperAggregation.GrouperAggregationGroupers.Add(new GrouperAggregationGrouper()
                    {
                        GrouperAggregation = grouperAggregation,
                        Grouper = grouperLevel2
                    });

                    _easyContext.GrouperAggregations.Add(grouperAggregation);

                    grouperAggregation = new GrouperAggregation()
                    {
                        Description = $"{grouperLevel1.Type.Name}: {grouperLevel1.Name}; {grouperLevel2.Type.Name}: {grouperLevel2.Name};"
                    };
                    grouperAggregation.GrouperAggregationGroupers.Add(new GrouperAggregationGrouper()
                    {
                        GrouperAggregation = grouperAggregation,
                        Grouper = grouperLevel1
                    });

                    grouperAggregation.GrouperAggregationGroupers.Add(new GrouperAggregationGrouper()
                    {
                        GrouperAggregation = grouperAggregation,
                        Grouper = grouperLevel2
                    });

                    _easyContext.GrouperAggregations.Add(grouperAggregation);
                }
            }

            await _easyContext.SaveChangesAsync();

            return Ok();

        }

        [HttpGet("SalesHourToday")]
        public async Task<ActionResult> SalesHourToday()
        {

            var grouperAggregations = _easyContext.GrouperAggregations
                .Include(_ => _.GrouperAggregationGroupers)
                .ThenInclude(_1 => _1.Grouper)
                .ToList();
            var saleIntervalTypeHour = _easyContext.SaleIntervalTypes.FirstOrDefault(_ => _.Name == "HORA");
            var saleIntervalTypeDay = _easyContext.SaleIntervalTypes.FirstOrDefault(_ => _.Name == "DIA");

            var empresas = _easyContext.Groupers.Include(_ => _.Type).Where(_ => _.Type.Id == 3).ToList();
            var segmentos= _easyContext.Groupers.Include(_ => _.Type).Where(_ => _.Id == 19).ToList();
            var categorias = _easyContext.Groupers.Include(_ => _.Type).Where(_ => _.Type.Id == 5).ToList();

            var sales = new List<Domain.Sales.Sale>();
            var saleTargets = new List<Domain.Sales.SaleTarget>();

            foreach (var empresa in empresas)
            {
                foreach(var segmento in segmentos)
                {
                    var grouperIds = new long[] { empresa.Id, segmento.Id };
                    var grouperAggregation = grouperAggregations.FirstOrDefault(_ => _.GrouperAggregationGroupers.Count(_1 => grouperIds.Contains(_1.Grouper.Id)) == 2);

                    foreach (var categoria in categorias)
                    {
                        for (var i = 7; i <= 22; i++)
                        {
                            var day = DateTime.Today.AddHours(i);
                            var sale = new Domain.Sales.Sale()
                            {
                                GrouperAggregation = grouperAggregation,
                                GrouperType = categoria.Type,
                                Grouper = categoria,
                                ReferenceId = categoria.Id,
                                ReferenceDescription = categoria.Name,
                                IntervalType = saleIntervalTypeHour,
                                IntervalBegin = day,
                                IntervalEnd = day.AddHours(1).AddMinutes(-1),
                                Value = new Random().NextDouble() * 1800
                            };

                            sales.Add(sale);
                        }

                        var saleTarget = new Domain.Sales.SaleTarget()
                        {
                            GrouperAggregation = grouperAggregation,
                            GrouperType = categoria.Type,
                            ReferenceGrouperId = categoria.Id,
                            ReferenceGrouperDescription = categoria.Name,
                            IntervalType = saleIntervalTypeHour,
                            IntervalBegin = DateTime.Today,
                            IntervalEnd = DateTime.Today.AddDays(1).AddMinutes(-1),
                            Target = 17000
                        };

                        saleTargets.Add(saleTarget);

                    }
                }
            }

            using (var transaction = _easyContext.Database.BeginTransaction())
            {
                await _easyContext.Sales.AddRangeAsync(sales);
                await _easyContext.SaleTargets.AddRangeAsync(saleTargets);
                await _easyContext.SaveChangesAsync();
                transaction.Commit();
            }
                


            return Ok();
        }
    }
}
