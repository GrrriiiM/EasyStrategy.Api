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

            var saleIntervalTypeHour = _easyContext.SaleIntervalTypes.FirstOrDefault(_ => _.Name == "HORA");

            var now = DateTime.Now;

            await createSale(saleIntervalTypeHour, 7, 23, i => now.Date.AddHours(i), i => now.Date.AddHours(i + 1).AddMinutes(-1),
                i => (i < now.Hour ? Convert.ToDecimal(new Random().NextDouble()) * 1800M : 0M),
                i => 1600);

            return Ok();
        }


        [HttpGet("SalesDayMonth")]
        public async Task<ActionResult> SalesDayMonth()
        {

            var saleIntervalTypeHour = _easyContext.SaleIntervalTypes.FirstOrDefault(_ => _.Name == "DIA");

            var now = DateTime.Now;

            var month = new DateTime(now.Year, now.Month, 1);

            await createSale(saleIntervalTypeHour, 0, now.Date.Day - 1, i => month.AddDays(i), i => month.AddDays(i + 1).AddMinutes(-1),
                i => (i < now.Day ? Convert.ToDecimal(new Random().NextDouble()) * 27000M : 0M),
                i => 24000);

            return Ok();
        }



        private async Task createSale(Domain.Sales.SaleIntervalType intervalType, int initLoop, int endLoop, Func<int,DateTime> intervalBegin, Func<int, DateTime> intervalEnd, Func<int, decimal> value, Func<int, decimal> target)
        {
            var grouperAggregations = _easyContext.GrouperAggregations
                .Include(_ => _.GrouperAggregationGroupers)
                .ThenInclude(_1 => _1.Grouper)
                .ToList();
            

            var saleValueTypeValue = _easyContext.SaleValueTypes.FirstOrDefault(_ => _.Name == "VALUE");
            var saleValueTypeTarget = _easyContext.SaleValueTypes.FirstOrDefault(_ => _.Name == "TARGET");


            var groupers = _easyContext.Groupers.Include(_ => _.Type);
            var total = groupers.FirstOrDefault(_ => _.Id == 1);
            var segmento = groupers.FirstOrDefault(_ => _.Id == 19);

            var categorias = groupers.Where(_ => _.Type.Id == 5).ToList();

            var sales = new List<Domain.Sales.Sale>();

            var now = DateTime.Now;

            var totalSales = new List<Domain.Sales.Sale>();

            foreach (var grupoEmpresaria in total.Childrens)
            {

                var grupoEmpresariaSales = new List<Domain.Sales.Sale>();

                foreach (var empresa in grupoEmpresaria.Childrens)
                {
                    var grouperIds = new long[] { empresa.Id, segmento.Id };
                    var grouperAggregation = grouperAggregations.FirstOrDefault(_ => _.GrouperAggregationGroupers.Count(_1 => grouperIds.Contains(_1.Grouper.Id)) == 2);

                    for (var i = initLoop; i <= endLoop; i++)
                    {
                        var valueHourTotal = 0M;
                        var targetHourTotal = 0M;
                        var day = intervalBegin(i);
                        foreach (var categoria in categorias.Where(_ => !_.IsTotal))
                        {
                            var valueHour = value(i);
                            var targetHour = target(i);

                            valueHourTotal += valueHour;
                            targetHourTotal += targetHour;

                            grupoEmpresariaSales.Add(new Domain.Sales.Sale()
                            {
                                GrouperAggregation = grouperAggregation,
                                GrouperType = categoria.Type,
                                Grouper = categoria,
                                ReferenceId = categoria.Id,
                                ReferenceDescription = categoria.Name,
                                IntervalType = intervalType,
                                IntervalBegin = day,
                                IntervalEnd = intervalEnd(i),
                                Numbers = new List<Domain.Sales.SaleNumberValue>
                                {
                                    new Domain.Sales.SaleNumberValue { ValueType = saleValueTypeValue, Value = valueHour },
                                    new Domain.Sales.SaleNumberValue { ValueType = saleValueTypeTarget, Value = targetHour }
                                }
                            });
                        }

                        var categoriaTotal = categorias.FirstOrDefault(_ => _.IsTotal);

                        grupoEmpresariaSales.Add(new Domain.Sales.Sale()
                        {
                            GrouperAggregation = grouperAggregation,
                            GrouperType = categoriaTotal.Type,
                            Grouper = categoriaTotal,
                            ReferenceId = categoriaTotal.Id,
                            ReferenceDescription = categoriaTotal.Name,
                            IntervalType = intervalType,
                            IntervalBegin = day,
                            IntervalEnd = day.AddHours(1).AddMinutes(-1),
                            Numbers = new List<Domain.Sales.SaleNumberValue>
                            {
                                new Domain.Sales.SaleNumberValue { ValueType = saleValueTypeValue, Value = valueHourTotal },
                                new Domain.Sales.SaleNumberValue { ValueType = saleValueTypeTarget, Value = targetHourTotal }
                            }
                        });
                    }

                }


                sales.AddRange(grupoEmpresariaSales);

                {
                    var grouperIds = new long[] { grupoEmpresaria.Id, segmento.Id };
                    var grouperAggregation = grouperAggregations.FirstOrDefault(_ => _.GrouperAggregationGroupers.Count(_1 => grouperIds.Contains(_1.Grouper.Id)) == 2);

                    for (var i = initLoop; i <= endLoop; i++)
                    {
                        var day = intervalBegin(i);
                        foreach (var categoria in categorias)
                        {
                            var valueHour = grupoEmpresariaSales.Where(_ => _.Grouper == categoria && _.IntervalBegin == day).Sum(_ => _.Numbers.FirstOrDefault(_1 => _1.ValueType == saleValueTypeValue).Value);
                            var targetHour = grupoEmpresariaSales.Where(_ => _.Grouper == categoria && _.IntervalBegin == day).Sum(_ => _.Numbers.FirstOrDefault(_1 => _1.ValueType == saleValueTypeTarget).Value);

                            totalSales.Add(new Domain.Sales.Sale()
                            {
                                GrouperAggregation = grouperAggregation,
                                GrouperType = categoria.Type,
                                Grouper = categoria,
                                ReferenceId = categoria.Id,
                                ReferenceDescription = categoria.Name,
                                IntervalType = intervalType,
                                IntervalBegin = day,
                                IntervalEnd = intervalEnd(i),
                                Numbers = new List<Domain.Sales.SaleNumberValue>
                                {
                                    new Domain.Sales.SaleNumberValue { ValueType = saleValueTypeValue, Value = valueHour },
                                    new Domain.Sales.SaleNumberValue { ValueType = saleValueTypeTarget, Value = targetHour }
                                }
                            });
                        }
                    }
                }

            }




            {
                var grouperIds = new long[] { total.Id, segmento.Id };
                var grouperAggregation = grouperAggregations.FirstOrDefault(_ => _.GrouperAggregationGroupers.Count(_1 => grouperIds.Contains(_1.Grouper.Id)) == 2);

                for (var i = initLoop; i <= endLoop; i++)
                {
                    var day = intervalBegin(i);
                    foreach (var categoria in categorias)
                    {
                        var valueHour = totalSales.Where(_ => _.Grouper == categoria && _.IntervalBegin == day).Sum(_ => _.Numbers.FirstOrDefault(_1 => _1.ValueType == saleValueTypeValue).Value);
                        var targetHour = totalSales.Where(_ => _.Grouper == categoria && _.IntervalBegin == day).Sum(_ => _.Numbers.FirstOrDefault(_1 => _1.ValueType == saleValueTypeTarget).Value);

                        sales.Add(new Domain.Sales.Sale()
                        {
                            GrouperAggregation = grouperAggregation,
                            GrouperType = categoria.Type,
                            Grouper = categoria,
                            ReferenceId = categoria.Id,
                            ReferenceDescription = categoria.Name,
                            IntervalType = intervalType,
                            IntervalBegin = day,
                            IntervalEnd = intervalEnd(i),
                            Numbers = new List<Domain.Sales.SaleNumberValue>
                            {
                                new Domain.Sales.SaleNumberValue { ValueType = saleValueTypeValue, Value = valueHour },
                                new Domain.Sales.SaleNumberValue { ValueType = saleValueTypeTarget, Value = targetHour }
                            }
                        });
                    }
                }
            }

            sales.AddRange(totalSales);

            using (var transaction = _easyContext.Database.BeginTransaction())
            {
                _easyContext.Sales.RemoveRange(_easyContext.Sales.Where(_ => _.IntervalType == intervalType));

                await _easyContext.Sales.AddRangeAsync(sales);
                await _easyContext.SaveChangesAsync();
                transaction.Commit();
            }
        }

    }
}
